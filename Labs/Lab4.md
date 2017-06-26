# Lab 4: .NET 4.6x Application

## Preparations
This lab requires that Visual Studio 2017 and the Cloud Foundry CLI is installed and can be found in the path.

## Instructions
#### Lab 4.1: Building and pushing .Net 4.6 MVC Application
1. Create a new .NET 4.6x Web MVC project in Visual Studio 2017
2. Publish the source using a Folder profile
3. Navigate to the folder where the source ocde was published
4. Push the source code to your API Endpoint

 `> cf push {yourappname} -b hwc_buildpack -s windows2012R2`
 