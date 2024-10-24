#Region Game API Details

Project Name: GameHub API

 Welcome to the GameHub API! This API allows you to manage a catalog of computer games, supporting basic CRUD operations 
 as well as listing and pagination for improved user experience. 

Features:

- **CRUD Operations** for the `Game` entity
- **Pagination** for listing games
- Unit tests for all endpoints
- Clean, maintainable code following .NET best practices
- Well-documented API

Table of Contents:
  - Installation
  - Usage
  - Endpoint Information
  - Contributing
  - License

  Installation:
   1. Clone the respository: 'https://github.com/Akhilesh2690/GameApp.git'
   2. Install .Net SDK 6.0.400 on your machine (https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
   3. Open the project in your prefered IDE(e.g. Visual Studio)
   4. Build the solution to restore nuget packages.
   5.Open appsettings.json and update the connection string to point to your SQL Server instance.
   6 In Visual Studio Go to Tools - NugetPackageManager- PackageManager Console  and execute below commands
      Add-Migration InitalMigration
      Update-Database
   

  Endpoint Information:
   
    
      Request Type: Post
      Request endpoint: /api/Games/
      Endpoint Information: This endpoint allows clients to create a new game entry in the game catalog. 
      The client must provide the necessary details of the game in the request body. 
      Upon successful creation, the API will return the newly created game object along with a 201 Created status.


      Request Type: GET
      Request endpoint: /api/Games/?pageNumber=1&pageSize=10
      Endpoint Information: This endpoint retrieves a list of all games available in the game catalog. 
      It supports optional pagination parameters to enhance performance and usability when dealing with large datasets.

      Request Type: GET
      Request endpoint: /api/Games/{id}
      Endpoint Information: This endpoint retrieves detailed information about a specific game identified by its unique ID.

      Request Type: PUT
      Request endpoint: /api/Games/{id}
      Endpoint Information: This endpoint allows clients to update the details of an existing game identified by its unique ID. It requires the complete game data in the request body.
      Upon successful update, the API returns the updated game object along with a 200 OK status.

      Request Type: Delete
      Request endpoint: /api/Games/{id}
      Endpoint Information: This endpoint allows clients to delete a specific game identified by its unique ID from the game catalog. 
                            
  Contributing:
      1. Fork the repository
      2. Create new branch
      3. Make your changes and commit them.
      4. Push to branch.
      5. Submit pull request which needs to point out to master branch.

 

#EndRegion

#Region Release Versions
   * Release 1.0.0
       The 1.0.0 release of the GameHub API marks the first stable version of our online gaming store's backend service. 
      - This version introduces a fully functional API for managing our game catalog, supporting essential CRUD operations, pagination, and comprehensive error handling.
#EndRegion

