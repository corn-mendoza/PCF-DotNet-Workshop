# Setting up Azure Broker Tile - Service Principals

This quick guide is designed to assist operators setup Azure Service Principals for configuring the Azure Service Broker tile in Pivotal Cloud Foundry.  This version of the document utilizes the latest Azure CLI 2.0 commands.

## Creating a Service Principal

Powershell, Azure CLI 2.0, and a Microsoft Azure Subscription is required to complete these configuration steps.

### Login to Azure
	PS C:\scripts> az login

This command will create the following output.  Open a browser and enter the code returned in the console.


**Output:**

To sign in, use a web browser to open the page https://aka.ms/devicelogin and enter the code XXXXXXXX to authenticate.
[
  {
    "cloudName": "AzureCloud",
    "id": "870f8bc3-1111-0000-8789-4b25984d8d05",
    "isDefault": true,
    "name": "username",
    "state": "Enabled",
    "tenantId": "29248f74-1111-0000-9a50-c62a6877a0c1",
    "user": {
      "name": "email@pivotal.io",
      "type": "user"
    }
  }


***The id is the SUBSCRIPTION_ID and the tenantId is the TENANT_ID for the tile configuration.***


### Application and Account Configuration
The following commands will create the Service Principal Application and Account.
#### Create the Application in AzureAD
The following command will create the Azure AD application instance for the Azure Service Broker.  The identifier URIs need to be unique for the subscription but fake URIs can be used.

	PS C:\scripts> az ad app create --display-name "BOSH Service Principal - CM" --password "<password>" --homepage "http://BOSHAzureCPI" --identifier-uris "http://BOSHAzureCPI"

**Output:**

{
  "appId": "b29050bf-1111-4e2d-816d-2c3f5b46c1cd",
  "appPermissions": null,
  "availableToOtherTenants": false,
  "displayName": "BOSH Service Principal",
  "homepage": "http://BOSHAzureCPI",
  "identifierUris": [
    "http://UniqueBOSHAzureCPIUri"
  ],
  "objectId": "e05e29f4-66e7-4d9a-ad4f-83eff15bf859",
  "objectType": "Application",
  "replyUrls": []
}

***The appId is your CLIENT_ID and the password is your CLIENT_SECRET for the tile configuration***

#### Create the Service Principal
The following command will create the Service Principal.  User the appId created in the previous step to execute.  Make note of the Service Principal Name as this will be used to configure permissions.

	PS C:\scripts> az ad sp create --id <appId>

**Output:**

{
  "appId": "b29050bf-1111-4e2d-816d-2c3f5b46c1cd",
  "displayName": "BOSH Service Principal - CM",
  "objectId": "8e7cfae7-b9c0-4f6f-8da8-aeacf2b12b5e",
  "objectType": "ServicePrincipal",
  "servicePrincipalNames": [
    "b29050bf-1111-4e2d-816d-2c3f5b46c1cd",
    "http://MendozaBOSHAzureCPI"
  ]
}

### Setting Up Broker Priviledges
Service Principals can have limited or full access to Azure resources. You must assign a set of priviledges to the Service Broker in order to successfully complete the configuration.  

#### Allow default priviledges to Azure Broker
These commands will allow the Service Principal to have default access to resources on Azure

	PS C:\scripts> az role assignment create --assignee "<service-principal-name>" --role "Virtual Machine Contributor"

**Output:**

{
  "id": "/subscriptions/870f8bc3-4f64-4684-8789-4b25984d8d05/providers/Microsoft.Authorization/roleAssignments/143bd3bf-31ae-4024-b8f8-3e02d2e5e961",
  "name": "143bd3bf-31ae-1111-b8f8-3e02d2e5e961",
  "properties": {
    "principalId": "8e7cfae7-1111-4f6f-8da8-aeacf2b12b5e",
    "roleDefinitionId": "/subscriptions/870f8bc3-4f64-4684-8789-4b25984d8d05/providers/Microsoft.Authorization/roleDefinitions/9980e02c-1111-4d73-94e8-173b1dc7c
f3c",
    "scope": "/subscriptions/870f8bc3-1111-4684-8789-4b25984d8d05"
  },
  "type": "Microsoft.Authorization/roleAssignments"
}

	PS C:\scripts> az role assignment create --assignee "<service-principal-name>" --role "Network Contributor"

**Output:**

{
  "id": "/subscriptions/870f8bc3-1111-4684-8789-4b25984d8d05/providers/Microsoft.Authorization/roleAssignments/1f59bce3-b3aa-4554-8431-36a9b65f8516",
  "name": "1f59bce3-1111-4554-8431-36a9b65f8516",
  "properties": {
    "principalId": "8e7cfae7-1111-4f6f-8da8-aeacf2b12b5e",
    "roleDefinitionId": "/subscriptions/870f8bc3-4f64-4684-8789-4b25984d8d05/providers/Microsoft.Authorization/roleDefinitions/4d97b98b-1d4f-4787-a291-c67834d21
2e7",
    "scope": "/subscriptions/870f8bc3-1111-4684-8789-4b25984d8d05"
  },
  "type": "Microsoft.Authorization/roleAssignments"
}

#### Allow full priviledges to Azure Broker
This command will allow the Service Principal to have full access to resources on Azure

	PS C:\scripts> az role assignment create --assignee "<service-principal-name>" --role "Contributor"

**Output:**

{
  "id": "/subscriptions/870f8bc3-4f64-4684-8789-4b25984d8d05/providers/Microsoft.Authorization/roleAssignments/738e4a4d-b303-469b-9cc9-741259b26fdd",
  "name": "738e4a4d-b303-469b-9cc9-741259b26fdd",
  "properties": {
    "principalId": "8e7cfae7-1111-4f6f-8da8-aeacf2b12b5e",
    "roleDefinitionId": "/subscriptions/870f8bc3-1111-4684-8789-4b25984d8d05/providers/Microsoft.Authorization/roleDefinitions/b24988ac-1111-42a0-ab88-20f7382dd
24c",
    "scope": "/subscriptions/870f8bc3-1111-4684-8789-4b25984d8d05"
  },
  "type": "Microsoft.Authorization/roleAssignments"
}