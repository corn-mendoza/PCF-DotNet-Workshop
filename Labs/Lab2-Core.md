# Lab 2 : .NET Core Application

## Preparations
This lab demonstrates the capabilities of Pivotal Cloud Foundry using the Command Line Interface. 

### Requirements
This lab requires that the Cloud Foundry CLI and .NET Core is installed and can be found in the path.

### Workshop Details

#### Demo App Repo: https://github.com/corn-pivotal/DotNetCoreWorkshop-MVC
#### API URL: https://api.run.haas-101.pez.pivotal.io
#### Apps Manager UI: https://apps.run.haas-101.pez.pivotal.io
#### Workshop SQL Connection String: 
	Server=tcp:pa-workshop.database.windows.net,1433;Initial Catalog=AttendeeDB-S1;Persist Security Info=False;User ID=dbadmin;Password=PCF!Password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
    
#### Org: student-{#}
#### Space: student-{#}

## Instructions
#### Cloud Foundry CLI Basics
1. Login to Cloud Foundry API Endpoint

	`> cf login -a https://{yourapiendpoint} --skip-ssl-validation`
 
2. Set org and space target using CLI

	`> cf target -o {yourorg} -s {yourspace}`
 

#### Lab 2.2: Pushing a .NET Core Application
1. Create a new directory and create a new .NET Core MVC Application

	`> dotnet new mvc`
 
2. Build the application

	`> dotnet build`

3. Run the application locally to validate the application will run correctly

	`> dotnet run`

4. Publish the source using the Release configuration

	`> dotnet publish -c Release`

5. Push the source code to your API Endpoint

	`> cf push {yourappname} -b https://github.com/cloudfoundry/dotnet-core-buildpack.git -p bin\Release\netcoreapp2.0\publish\`
 
#### Lab 2.3: Scaling an Application
1. Scale the number of instances of an application

	`> cf scale {yourappname} -i 2`

2. Scale the memory and disk space of an application

	`> cf scale {yourappname} -m 1G -k 1G`

#### Lab 2.4: Mapping Routes
1. Map a simulated production route to the application

	`> cf map-route {yourappname} {domainname} --hostname {yourappname}-prod`

#### Lab 2.5: Set Environment Variables
1. Set environment variable for PROD_MODE to BLUE 

	`> cf se {yourappname} PROD_MODE BLUE`

#### Lab 2.6: Creating and Binding Services
1. List the available services in the marketplace

	`> cf m`

2. Create a User Provided Service for AttendeeContext - use connection string provided in workshop instructions for {workshop-connectionstring}

	`> cf create-user-provided-service AttendeeContext -p "{\"connectionstring\":\"{workshop-connectionstring}\"}"`

3. Create a User Provided Service for the DefaultConnection - use connection string provided in workshop instructions for {workshop-connectionstring}

	`> cf create-user-provided-service DefaultConnection -p "{\"connectionstring\":\"{workshop-connectionstring}\"}"`

4. Bind to the user provided services

	`> cf bind-service {yourappname} AttendeeContext`

5. Restart the application

	`> cf restart {yourappname}`

6. View your app in the Application Manager and, under Services, verify that the Attendees User Provided Service is correctly configured and bound to your application

#### Lab 2.7: Setting up for Blue/Green Deployment
1. Push this .NET application to a second application

	`> cf push {appname2} -b https://github.com/cloudfoundry/dotnet-core-buildpack.git -p bin\Release\netcoreapp2.0\publish\`

2. Scale the application to 2 instances

	`> cf scale {appname2} -i 2`

3. Set environment variables

	`> cf se {appname2} PROD_MODE GREEN`

4. Bind services to the 2nd application

    `> cf bind-service {appname2} AttendeeContext`

5. Restart the 2nd application

	`> cf restart {appname2}`

6. Map the second applicaton to the same production route

	`> cf map-route {appname2} {domainname} --hostname {appname}-prod`

7. Unmap the first applicaton from the production route

	`> cf unmap-route {appname} {domainname} --hostname {appname}-prod`

8. View application in browser and verify the production url points to the GREEN instance of the application

#### Lab 2.8: View the Application Log
1. View the application log in the app manager UI

2. View the application log using the command line

	`> cf logs {yourappname} --recent`

#### Lab 2.9: View the Application Metrics
1. View the application metrics in the app manager UI if it is available
