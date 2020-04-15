# uProx
 Check the correct operation of a list of proxies (proxylist.json). 
 
 ## Usage:
 open proxylist.json and add to the file all the proxies you want to test. Then run with the **dotnet run** command. 
 For each proxy it will respond with the html of the target url; otherwise, the operation error returns.
 
 ### Increase / test analitycs
 uProx can used to the same time increases the requests of a certain site and test if the analytics are correctly configured.

 ### Important
 This can not be used to increase the visits in google analytics. The returned code its not interpreted or excecuted by the browser; only for testing purposes.

### Get a proxy list
You can get a fresh proxy list in any site such as: https://free-proxy-list.net/, use a scrapper to convert the list to the uProx format json.