# RabbitMQ

`Note:`

* Have docker installed
* RabbitMQ configuration data is in `appsettings.json` file and `appsettings.Development.json` file


### Clone the project and in the terminal run:

 ``` 
   docker-compose up
   dotnet build
   dotnet run --project Airline.API/Airline.API.csproj
   dotnet run --project Airline.Ticket.Processing/Airline.Ticket.Processing.csproj
 ```

### Access RabbitMQ in the browser: [http://localhost:15672/#/](http://localhost:15672/#/)
     
     
 ``` 
  login: user
  password: mypass
 ```
     
### Access Swagger in the browser: [https://localhost:7085/swagger/index.html](https://localhost:7085/swagger/index.html)
