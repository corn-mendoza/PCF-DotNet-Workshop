# Lab 3: .NET Core Application

## Preparations
This lab requires that .NET Core 1.1.x and the Cloud Foundry CLI is installed and can be found in the path.
## Instructions

#### Lab 3.1: Building and pushing .Net Core MVC Application
1. Create a new project using the Dotnet CLI

 `> dotnet new mvc`

2. Open a Command Window or Powershell Window in the cloned directory
3. Restore references using the Dotnet CLI

 `> dotnet restore`
 
4. Publish the source code using the *Release Configuration*

`> dotnet publish -c Release`

5. Navigate to the folder where the source ocde was published

 `> cd bin\Release\netapp1_1\publish`
 
6. Login to your API Endpoint

 `> cf login`
 
7. Push the source code to your API Endpoint

 `> cf push {yourappname} -b dotnet_core_buildpack`
 




