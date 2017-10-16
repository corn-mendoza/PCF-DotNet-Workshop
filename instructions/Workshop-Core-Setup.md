## Set up  for .NET Core Workshops
We’ll set up our workstation and cloud environment so that we’re ready to build and run modern .NET Core applications. 
Create Pivotal Web Services account Here we set up an account on the hosted version of Pivotal Cloud Foundry, called Pivotal Web Services.  
1. Install Cloud Foundry command line interface You can interact with Cloud Foundry via Dashboard, REST API, or command line interface. Here, we install the CLI and ensure it’s configured correctly. 

2. Go to https://github.com/cloudfoundry/cli/releases and find the installer for your workstation. Note that for Mac users, you can download this script (http://bit.ly/2stikFz) that installs all the prerequisites via Homebrew! 

3. Download the installer and run it. 

4. Confirm that it installed successfully by going to a command line, and typing in cf -v

Install .NET Core and Visual Studio Code .NET Core represents a modern way to build .NET apps, and here we make sure we have everything needed to build ASP.NET Core apps. 

1. Visit https://www.microsoft.com/net/core and choose the .NET Core download for your machine. 

2. Install .NET Core. 

3. Confirm that it installed correctly by opening a command line and typing dotnet --version 

4. Go to https://code.visualstudio.com/ and download the Visual Studio Code editor to your workstation. Run the installer. 

5. Open Visual Studio Code and go to View → Extensions 6. Search for “C#” and choose the top “C# for Visual Studio Code” option and click “Install.” This gives you type-ahead support for C#.
