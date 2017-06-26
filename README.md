# PCF-DotNet-Workshop
## Pivotal Cloud Native Applications .NET Workshop
This one day hands-on classroom style session will provide developers with hands on experience building .NET Core 1.1 and .NET 4.6 applications for Pivotal Cloud Foundry. The session includes presentations, demos and hands on labs.

Note: You may need to follow these instructions here to set your proxy settings for the CLI: [Using the cf CLI with an HTTP Proxy Server](https://docs.cloudfoundry.org/cf-cli/http-proxy.html).

This workshop requires participants to have Visual Studio 2017 installed.  Visual Studio Code can be used for the .NET Core portion of the workshop.  Use the Windows instructions for the CF CLI.  
- [Download Visual Studio 2017 Community Edition](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15)
- [Download Visual Studio Code](https://code.visualstudio.com/?wt.mc_id=vscom_downloads)
- [Download Windows Cloud Foundry CLI](https://cli.run.pivotal.io/stable?release=windows64&source=github)
- - -

#### Agenda
##### Introductions, Purpose, and Objectives 

##### Overview: Pivotal Cloud Foundry 

##### Session 1: Cloud Native Design, Domain Driven Design, & Microservices

##### Session 2: Introduction to the CF CLI
-	Lab 2: [Instructions](./Labs/Lab2.md)
-   Lab 2.1: Introduction to Orgs, Spaces, and Roles
-   Lab 2.2: Pushing a .NET Core Application
-   Lab 2.3: Pushing a .NET Classic Application
-   Lab 2.4: Scaling an Application
-   Lab 2.5: Creating and Binding to Services
-   Lab 2.6: Mapping Routes
  
##### Session 3: .NET Core and PCF 
-	Lab 3: [Instructions](./Labs/Lab3.md)
-   Lab 3.1: Building and pushing .Net Core MVC Application
-   Lab 3.2: Integrating SQL Server using Service Tiles
  
##### Session 4: .NET Classic and PCF 
-	Lab 4: [Instructions](./Labs/Lab4.md)
-   Lab 4.1: Building and pushing .Net 4.6 MVC Application
-   Lab 4.2: Integrating SQL Server using Service Tiles

##### Session 5 (Optional): Advancing .NET Core with Steeltoe 
-	Lab 5: [Instructions](./Labs/Lab5.md)
-   Lab 5.1: Implementing Pivotal Config Server
-   Lab 5.2: Implementing Service Discovery

##### Session 6 (Optional - Requires SSO Tile to be installed): Single Sign-On
-	Lab 6: [Instructions](./Labs/Lab6.md)
-   Lab 6.1: Integrating Pivotal SSO with .NET Core using Steeltoe
-   Lab 6.2: Integrating Pivotal SSO with .NET 4.6x

##### Session 7: CI-CD Pipelines with Team Services (Demos)
-   Demo 7.1: Setting Up Endpoints for Services
-   Demo 7.2: Creating a .NET Core Build Job for PCF
-   Demo 7.3: Creating a .NET Classic Build Job for PCF
-   Demo 7.4: Creating a Deployment Definition for PCF
-   Demo 7.5: Creating a Blue-Green Deployment Definition for PCF
-	Implementation Guide: [CI/CD Pipelines for VSTS/TFS]()  
--	[Sample Builds](./vsts/builds/)
--	[Sample Deployments](./vsts/deployments/)
- - -
