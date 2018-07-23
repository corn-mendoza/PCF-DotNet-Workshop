# Lab 2 : .NET Framework Application

## Preparations
This lab demonstrates the capabilities of Pivotal Cloud Foundry using the Command Line Interface. 

### Details
The application is a default .NET 4.6x MVC application.  The web.config will be transformed during publishing to replace the LocalDB connection support with the standard SQL Sever connection support.  The published connection strings in the web.config are designed to be used with token replacement in a CI/CD pipeline.  These connection strings can be manually updated prior to pushing to PCF with the workshop database connection strings.  The database code has been updated to use the user provided service if it is found that has a corresponding name in the web.config (AttendeeContext, DefaultConnection).

### Requirements
This lab requires that the Cloud Foundry CLI is installed and can be found in the path, Visual Studio 2017 with SQL Server Express LocalDB option to run locally.

## Instructions
#### Cloud Foundry CLI Basics
1. Login to Cloud Foundry API Endpoint

	`> cf login -a https://{yourapiendpoint}`
 
2. Set org and space target using CLI

	`> cf target -o {yourorg} -s {yourspace}`
 
#### Lab Step 1: Create a new Web application using Visual Studio and push into your space
1. Create a new project in Visual Studio for a new .NET Framework Web Application
2. Run the application locally to ensure the application does run
3. Publish the application using the Folder Profile
4. Open a command window at the publish location and push the application

	`> cf push {yourappname} -b hwc_buildpack -s windows2016`
5. Verify the application was pushed correctly by navigating to the application URL
6. Log into the Apps Manager portal and view the application details and settings

#### Lab Step 2: Scaling an Application
1. Scale the number of instances of an application

	`> cf scale {yourappname} -i 2`

2. Scale the memory and disk space of an application

	`> cf scale {yourappname} -m 1G -k 1G`

3. Scale the application in the Apps Manager portal
4. Turn on auto-scaling for the application in the Apps Manager portal

#### Lab Step 3: Mapping Routes
1. Map a simulated production route to the application

	`> cf map-route {yourappname} {domainname} --hostname {yourappname}-prod`

#### Lab Step 4: View the Application Logs
1. View the application log in the app manager UI

2. View the application log using the command line

	`> cf logs {yourappname} --recent`

#### Lab Step 5: Set Environment Variables
1. Set environment variable to display on Home Page
	`> cf se {yourappname} PROD_MODE BLUE`

2. Set environment variable to set Apps Manager URL on Home Page
	`> cf se {yourappname} ASPNETCORE_ENVIRONMENT "development"`

#### Lab Step 6: Setting up for Blue/Green Deployment
1. Push this .NET Framework application to a second application

	`> cf push {appname2} -b hwc_buildpack -s windows2016`

2. Scale the application to 2 instances

	`> cf scale {appname2} -i 2`

3. Map the second applicaton to the same production route

	`> cf map-route {appname2} {domainname} --hostname {appname}-prod`

4. Unmap the first applicaton from the production route

	`> cf unmap-route {appname} {domainname} --hostname {appname}-prod`

8. View application in browser and verify the production url points to the GREEN instance of the application

#### Lab Step 7: Steeltoe Management Enhancements
1. Locate the .NET solution in the sources folder 

2. Open the solution in Visual Studio

3. Compile the application to validate the application will build correctly

3. Publish the source using a Folder profile

4. Navigate to the folder where the source code was published

5. Push the source code to your API Endpoint

	`> cf push {yourappname} -b hwc_buildpack -s windows2016`
 
6. Goto the Apps Manager Portal, select your application, and click on View Application  

7. Hard refresh the apps manager portal (F5)

8. Review the Steeltoe enhancements to the application portal

9. In the apps manager portal click on Trace to view the trace information related to your application

#### Lab Step 8: Creating and Binding Services
1. List the available services in the marketplace

	`> cf m`

2. Create a User Provided Service for AttendeeContext - use connection string provided in workshop instructions for {workshop-connectionstring}

	`> cf create-user-provided-service AttendeeContext -p "{\"connectionstring\":\"{workshop-connectionstring}\"}"`

3. Bind to the user provided services

	`> cf bind-service {yourappname} AttendeeContext`
    
4. Restart the application

	`> cf restart {yourappname}`

5. View the application to verify that the Attendees page loads using the user provided service

#### Lab Step 9: Creating a Console Application
1. Create a new console application with the following in the main loop:

	`Console.Writeline("Here's a message");`
	`Console.Readln();`
	
2. Build the application and locate the executable in the bin\debug directory

3. Navigate to the folder and push the console application with the following:

	`> cf push {yourappname} -b binary_buildpack -s windows2016`
	
4. SSH into the new application and look around

	`> cf ssh push {yourappname}`
