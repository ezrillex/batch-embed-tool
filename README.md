# batch-embed-tool
 A prototype tool for batch creation of embed links

This program looks for your client id in a file named "clientid.txt"

To get a client id follow the steps in the documentation article:

Register an app using the link specified in:
https://docs.microsoft.com/en-us/onedrive/developer/rest-api/getting-started/app-registration?view=odsp-graph-online

When creating the app, make sure to select "Personal Microsoft Accounts only..."

Once created go to Authentication > Add a Platform > Select "Mobile and Desktop applications" > Select the first link "https://login.microsoftonline.com/common/oauth2/nativeclient"

Save your changes and go to the overview section and copy the "Application (client) id"

 Create a "clientid.txt" in the program folder and paste your id into the text file.

 If all goes well you should be able to launch the app now,
 take into account that this is a prototype and has no error handling when you max the api rate limit,
 the program may crash and loose the work so try to do small batches while I get around to doing that. 