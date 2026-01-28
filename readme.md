# OpenAPI demo for AI agents

This demo shows how to build a simple OpenAPI serivce (with Swagger) for use in AI agents. All necessary NuGet libraries referenced within the project file. You can locate the tools in the Controllers library, including a functional tool that retrieves both the service version and service name. 

This demo is compatible with [Copilot Studio](https://learn.microsoft.com/en-us/microsoft-copilot-studio/agent-extend-action-rest-api) and [Microsoft Foundry](https://learn.microsoft.com/en-us/azure/ai-foundry/agents/how-to/tools-classic/openapi-spec-samples?view=foundry-classic&viewFallbackFrom=foundry&pivots=portal). Please refer to the official documentation links for integration details. 

## Deployment

To begin deployment, access the OpenAPI document (https://domain-name/swagger/v1/swagger.json) to download and save the specification file locally before uploading it to your preferred AI platform.

Please note that the OpenAPI specification includes the **server** URL, which directs Copilot and AI Foundry to your specific web API endpoints. To ensure this URL is accurate, you must first deploy the service to Azure App Service. Once the deployment is live, download the OpenAPI document from the hosted environment to ensure all metadata is correctly configured for your AI platform.