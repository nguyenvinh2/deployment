# Piranha Deployment

## Cannot Deploy to AWS

## List of problems

- Piranha apps use ASP.NET CORE 2.2, AWS Codebuild uses 2.1
- Attempting to downgrade to 2.1 creates a whole list of dependency problems, as dependencies use 2.2
- This causes a chain breakdown which causes application misconfiguration
- Elastic Beanstalk supposedly supports 2.2
- Steps to upload to Elastic Beanstalk
  - Within the root repo:
  - enter "dotnet run" in the CLI to ensure it locally works
  - After verifying it runs locally, enter "dotnet build -o site" to publish the DLL files into the "site" directory
  - Create a aws-windows-deployment-manifest.json with the following
---
      {
        "manifestVersion": 1,
        "deployments": {
            "aspNetCoreWeb": [{
                    "name": "deployment",
                    "parameters": {
                        "appBundle": "./site",
                        "iisPath": "/",
                        "iisWebSite": "Default Web Site"
                    }
                }
            ]
        }
      }


---

  - Compress the "site" directory with the json file into a zip file
  - On Elastic Beanstalk, create a new application with a IIS/.NET environment and upload your zip file for deployment

- However, it still won't deploy because SQLite cannot open the .db file embedded within the application, causing the application to crash.

- Further troubleshooting reveals that EB instances are meant to be immuteable; it's files cannot be modify. Because the SQLite database is located in that .db file, which is generated within the application, this application is incompatible with EB with the current set up.

- Possible follow up is to switch to MS SQL Server it's database.
