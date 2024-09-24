# Foody

Foody is a recipe management web application that allows users to sign up, log in, manage their profiles, and add, search, rate, and comment on recipes. Users can also save recipes for later use and view top-rated meals on the homepage.

## Features

### Implemented Functionalities
1. User Registration (Signup):
   - New users can register using their name, email, and password.
   - Basic validation to prevent duplicate email registration.
   - Passwords are stored securely (hashing is applied using SHA256).

2. User Login:
   - Users can log in using their registered email and password.
   - Model binding is used to retrieve the form data.
   - Error handling is included for incorrect login credentials.

3. Profile Management:
   - Users can view their profile information after logging in.
   - Users can upload a profile picture during registration.
   - Profile picture is stored on the server and its path is saved in the database.
   - 
4. Profile Editing:
   - Users are able to edit their profile information (e.g., name, email, profile picture).
   - An edit icon is added to the profile page, which will redirect users to an edit form.

5. Recipe Management:
   - Users can add their own recipes.
   - Recipes are stored in a database and linked to the user's profile.
   - Users can search for recipes by name or ingredients.

### Planned Functionalities

1. Recipe Rating and Commenting:
   - Users will be able to rate and comment on recipes.
   - A recipe's rating will be displayed, and top-rated recipes will be highlighted on the homepage.

2. 'Cook Later' Feature:
   - Users will be able to save recipes they wish to try later into a personalized list.

3. Top-Rated Meals:
   - The homepage will display the highest-rated meals of the week based on user feedback.

## Installation and Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/Soha2Mohamed/Foody.git
   ```

2. Install the necessary packages:
   ```bash
   dotnet restore
   ```

3. Update the connection string in `appsettings.json` to match your SQL Server setup.

4. Run database migrations:
   ```bash
   dotnet ef database update
   ```

5. Run the application:
   ```bash
   dotnet run
   ```

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server

  
## Contribution
Feel free to fork this repository and make contributions! If you encounter any issues or have suggestions, please open an issue or submit a pull request.
