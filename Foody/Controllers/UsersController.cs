using Foody.Data;
using Foody.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Foody.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbcontext _applicationDbcontext;

        private readonly IWebHostEnvironment _webHostEnvironment; //for file saving path
        public UsersController(ApplicationDbcontext applicationDbcontext, IWebHostEnvironment webHostEnvironment)
        {
            _applicationDbcontext = applicationDbcontext;
            _webHostEnvironment = webHostEnvironment;
        }
        public static class PasswordHelper
        {
            public static string HashPassword(string password)
            {
                using (var sha256 = SHA256.Create())
                {
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    return Convert.ToBase64String(hashedBytes);
                }
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //first i see if there is such an email
                var user = _applicationDbcontext.Users.FirstOrDefault(u => u.Email == model.Email);

                //if there is actually a user with that email i start to check the password but remember that you stored the password hashed in the database
                if (user != null)
                {
                    var hashedPassword = PasswordHelper.HashPassword(model.Password);
                    if (user.Password == hashedPassword)
                    {
                        // Store the user ID in the session for later use
                        HttpContext.Session.SetInt32("UserId", user.Id);

                        return RedirectToAction("Profile");
                    }
                    else
                    {
                        //here the password is not the same, but we don't say that in case a hacker is trying to enter
                        ModelState.AddModelError("", "Invalid Email or Password");
                    }
                }
                else
                {
                    //there is np such email!
                    ModelState.AddModelError("", "Invalid Email or Password");
                }
            }
            return View(model);
        }


        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel model, IFormFile ProfilePicture)
        {

            // Check if the model state is valid (data validation for required fields, email format, etc.)
            if (ModelState.IsValid)
            {
                // Check if the email already exists in the database
                if (_applicationDbcontext.Users.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("", "Email is already registered.");
                    return View(model);  // Return with an error message
                }

                string ProfilePictureFileName = null;
                if (ProfilePicture != null)
                {
                    ProfilePictureFileName = Guid.NewGuid().ToString() + "_" + ProfilePicture.FileName;

                    string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", ProfilePictureFileName);

                    using (var fileStream = new FileStream(FilePath, FileMode.Create))
                    {
                        await ProfilePicture.CopyToAsync(fileStream);
                    }
                }

                // Hash the password before saving it
                var hashedPassword = PasswordHelper.HashPassword(model.Password);

                // Create a new user object
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = hashedPassword,  // Store the hashed password
                    Created_at = DateTime.Now,
                    Description = model.Description,
                    ProfilePicture = ProfilePictureFileName,
                };

                // Add the user to the database and save changes
                _applicationDbcontext.Users.Add(user);
                await _applicationDbcontext.SaveChangesAsync();

                // Redirect to the login page after successful signup
                return RedirectToAction("Login");
            }

            // If we get here, something went wrong with validation
            return View(model);
        }
        public IActionResult Profile()
        {
            // Retrieve the user ID from the session
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                // If no user is logged in, redirect to the login page
                return RedirectToAction("Login");
            }

            // Query the database to get the user by their ID
            var user = _applicationDbcontext.Users.FirstOrDefault(u => u.Id == userId.Value);

            if (user == null)
            {
                // If user not found, redirect to login
                return RedirectToAction("Login");
            }
            //i think we shouldn't pass the whole user to the view?
            // Pass the user data to the view
            return View(user);

        }
      

        [HttpGet]
        public IActionResult EditProfile()
        {
            // i should ensure firstt that any data is changed, if not then  nothing to save!
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                RedirectToAction("Login");
            }
            var user = _applicationDbcontext.Users.FirstOrDefault(u => u.Id == userId.Value);
            if (user == null)
            {
                RedirectToAction("Login");
            }
            var model = new EditProfileViewModel
            {
                Name = user.Name,
                Email = user.Email,
                Description = user.Description,

            };
            /*
              var model = new EditProfileViewModel
            {
                model.Name = user.Name,

            };
             */
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            if(ModelState.IsValid)
            {
                RedirectToAction("Login");
            }
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                RedirectToAction("Login");
            }

            var user = _applicationDbcontext.Users.FirstOrDefault(u =>u.Id == userId.Value);

            if (user == null)
            {
                RedirectToAction("Login");
            }

            user.Name = model.Name;
            user.Email = model.Email;
            user.Description = model.Description;

            string ProfilePictureFileName = null;
            if (model.ProfilePicture !=null)
            {
                //var fileName = Path.GetFileNameWithoutExtension(model.ProfilePicture.FileName);
                //var extension = Path.GetExtension(model.ProfilePicture.FileName);
                // var filePath = Path.Combine("wwwroot/uploads", fileName + extension);
                ProfilePictureFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;

                string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", ProfilePictureFileName);

                using (var fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    await model.ProfilePicture.CopyToAsync(fileStream);
                }
                user.ProfilePicture = ProfilePictureFileName;
            }

            _applicationDbcontext.Users.Update(user);
            await _applicationDbcontext.SaveChangesAsync();
            return RedirectToAction("Profile");
                
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear all session data
            return RedirectToAction("Login"); // Redirect back to login page
        }
    }
}
