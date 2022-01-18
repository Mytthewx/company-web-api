# Company Web API!

Application written in C# (.NET Core) storing in a selected database information about companies including a list of employees and with the possibility of
management via RESTful Web API. The entire application was created by Mateusz Domagała as part of a recruiting project.


# Endpoints

|  HTTP          |  Authorization |Route                          |Description|
|--------------|--|-------------------------------|-----------------------------|
|POST		|	Required|`company/create`            |'Endpoint to create a company with employees.'            |
|POST     | Not required |`company/search`            |'Endpoint that allows to search by job title and keywords (company name, employee name or surname) in the specific date range.'          |
|PUT       | Required  |`company/update/{id}`|'Endpoint to update a company with employees.'|
|DELETE     |  Required   |`company/delete/{id}`|'Endpoint to delete a company with employees.'|

![Endpoint on the swagger](https://i.imgur.com/b1XUfKO.png)

## Authentication

As intended by the project, a method of Basic Authentication was used in the application. The user data are hardcoded in the **UserService.cs** class.
Additionally, swagger settings have been added to enable an authentication feature where you can enter a login and password. The method used to search for companies does not require authorization. The password and username are encoded in Base64.

Default name and password:
|  Username          |  Password |
|----------------|----------------|
|PumoxUser		|	PumoxPassword|

![Swagger authorization](https://i.imgur.com/Vvv9zNq.png)

## Settings/Database connection string

The file named "appsettings.json" stores the connection information to the database. 
