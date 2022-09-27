## Criando o Projeto

* ```dotnet new sln --name solution_name```
* ```dotnet new grpc -o solution_name.template_project --no-https true```
* ```dotnet sln solution_name.sln add ./solution_name.template_project/solution_name.template_project.csproj```
* ```dotnet new gitignore```

## Packages

* ```cd ./solution_name.template_project/solution_name.template_project.csproj```
* ```dotnet add package Npgsql```
* ```dotnet add package Dapper```
* ```dotnet add package Grpc.AspNetCore```
* ```dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection```