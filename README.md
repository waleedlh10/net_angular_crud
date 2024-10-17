````markdown
# Net 8 / Angular Ticket management

## Introduction

Welcome to the Net Angular CRUD project! This application allows you to manage data using Create, Read, Update, and Delete (CRUD) operations. It's built using .NET for the backend and Angular for the frontend, making it a perfect example for learning full-stack development.

## Key Features

- Simple and clean interface for managing records.
- Interactive API for performing CRUD operations.
- Responsive design that works on various devices.

## Technologies Used

- Backend: C# (.NET) for server-side logic.
- Frontend: TypeScript and Angular for user interface.
- Styling: SCSS for modern and responsive design.

## Getting Started

### Prerequisites

To run this project, you'll need the following installed on your computer:

- .NET SDK: This is required to run the backend.
- Node.js: This will help you run the frontend.
- Angular CLI: This command-line tool helps in managing Angular applications.
- Database: A SQL Server database is recommended.

### Connecting to the Database

1. Create a Database:
   Open SQL Server Management Studio (SSMS) and create a new database. You can name it `TicketDb`.

2. Configure Connection String:
   In the backend project, locate the `appsettings.json` file. Update the `ConnectionStrings` section with your database connection details:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=TicketDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```
````

Replace `YOUR_SERVER` with the name of your SQL Server instance.

3. Migrate Database:
   In the terminal, navigate to the backend directory and run the following command to create the necessary tables in your database:
   ```bash
   dotnet ef database update
   ```

### Installation Steps

1. Clone the Repository:
   Open your terminal and run the following command:

   ```bash
   git clone https://github.com/waleedlh10/net_angular_crud.git
   ```

   Change into the project directory:

   ```bash
   cd net_angular_crud
   ```

2. Install Backend Dependencies:
   Navigate to the backend folder and restore the packages:

   ```bash
   cd back_api
   dotnet restore
   ```

3. Install Frontend Dependencies:
   Change to the frontend directory and install the required packages:
   ```bash
   cd ../front_app
   npm install
   ```

### Running the Application

- Start the Backend:
  In the terminal, make sure you're in the `back_api` directory and run:

  ```bash
  dotnet run
  ```

- Start the Frontend:
  Open a new terminal window, navigate to the `front_app` directory, and run:
  ```bash
  ng serve
  ```

### Accessing the Application

Open your web browser and go to `http://localhost:4200`. You should see the application running!
