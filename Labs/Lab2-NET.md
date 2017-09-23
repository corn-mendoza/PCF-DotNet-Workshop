# Lab 2 : .NET Framework Application

## Preparations
This lab demonstrates the capabilities of Pivotal Cloud Foundry using the Command Line Interface. The source code allows the application to run using SQL Server Express LocalDB. 

### Details
The application is a default .NET 4.61 MVC application with SQL Server targeted for the user security database and the attendee sampple database.  The web.config will be transformed during publishing to replace the LocalDB connection support with the standard SQL Sever connection support.  The published connection strings in the web.config are designed to be used with token replacement in a CI/CD pipeline.  These connection strings can be manually updated prior to pushing to PCF with the workshop database connection strings.  The database code has been updated to use the user provided service if it is found that has a corresponding name in the web.config (AttendeeContext, DefaultConnection).

### Requirements
This lab requires that the Cloud Foundry CLI is installed and can be found in the path, Visual Studio 2017 with SQL Server Express LocalDB option to run locally.

## Instructions
#### Cloud Foundry CLI Basics
1. Login to Cloud Foundry API Endpoint

	`> cf login -a https://{yourapiendpoint}`
 
2. Set org and space target using CLI

	`> cf target -o {yourorg} -s {yourspace}`
 

#### Lab 2.2: Pushing a .NET Classic Application
1. Clone the .NET application [DotNetWorkshop-MVC](https://github.com/corn-pivotal/DotNetWorkshop-MVC)

	`> git.exe clone https://github.com/corn-pivotal/DotNetWorkshop-MVC`
 
2. Open the solution in Visual Studio

3. Run the application locally to validate the application will run correctly

3. Publish the source using a Folder profile

4. Navigate to the folder where the source code was published

5. Push the source code to your API Endpoint

	`> cf push {yourappname} -b hwc_buildpack -s windows2012R2`
 
#### Lab 2.3: Scaling an Application
1. Scale the number of instances of an application

	`> cf scale {yourappname} -i 2`

2. Scale the memory and disk space of an application

	`> cf scale {yourappname} -m 1G -k 1G`

#### Lab 2.4: Mapping Routes
1. Map a simulated production route to the application

	`> cf map-route {yourappname} {domainname} --hostname {yourappname}-prod`

#### Lab 2.5: Set Environment Variables
1. Set environment variable to display on Home Page
	`> cf se {yourappname} PROD_MODE BLUE`

2. Set environment variable to set Apps Manager URL on Home Page
	`> cf se {yourappname} WORKSHOP_URL {workshop-apps-url}`

#### Lab 2.6: Creating and Binding Services
1. List the available services in the marketplace

	`> cf m`

2. Create a User Provided Service for AttendeeContext - use connection string provided in workshop instructions for {workshop-connectionstring}

	`> cf create-user-provided-service AttendeeContext -p "{\"connectionstring\":\"{workshop-connectionstring}\"}"`

3. Create a User Provided Service for the DefaultConnection - use connection string provided in workshop instructions for {workshop-connectionstring}

	`> cf create-user-provided-service DefaultConnection -p "{\"connectionstring\":\"{workshop-connectionstring}\"}"`

4. Bind to the user provided services

	`> cf bind-service {yourappname} AttendeeContext`
    
    `> cf bind-service {yourappname} DefaultConntection`

5. Restart the application

	`> cf restart {yourappname}`

6. View the application to verify that the Attendees page loads using the user provided service

#### Lab 2.7: Setting up for Blue/Green Deployment
1. Push this .NET Framework application to a second application

	`> cf push {appname2} -b hwc_buildpack -s windows2012R2`

2. Scale the application to 2 instances

	`> cf scale {appname2} -i 2`

3. Set environment variables

	`> cf se {appname2} PROD_MODE GREEN`
    
    `> cf se {appname2} WORKSHOP_URL {workshop-apps-url}`

4. Bind services to the 2nd application

	`> cf bind-service {appname2} DefaultConnection`
    
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
