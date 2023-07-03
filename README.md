# Comments System
Using Asp.net MVC Core 3.1 And Identity 

### Getting Started and Installation

1. Creat .NET Core 3.1 project in Visual Studio
2. Install the EF NuGet package  
   ```sh
   NuGet\Install-Package EntityFramework 
   ```
3. Create Sql Database and insert the data in `appsettings.json`
   ```json
   "ConnectionStrings": {
    "DefaultConnection": "Server=xxx;Database=DbName;User ID=xxx;Password=xxx",
    }
  
   ```
4. Create a class model name "Comment" and DBContext class to call this.
5. Use Code First EF approach (to create the tables in Sql Database), 
migration commands =>
Add-Migration
Update-Database
6. Define In the controller "CreateComments" function to add the comments in the database.


<p align="right">(<a href="#readme-top">back to top</a>)</p>

