# uProx
 Allows to check the correct operation of a list of ip/port proxy's (proxylist.json). 
 
 ## Usage:
 Edit proxylist.json and add all the proxy's you want to test; Then run with the **dotnet run** command. 
 For each proxy in the list it will respond with the html returned of the target url, otherwise, the operation return an error and checked as an invalid/banned proxy.
 
 ### Increase / test analytics
 uProx can be used to increases the requests of a certain url-site and test if the logs/analytics are correctly configured in the server; As it goes through a proxy, all calls will be interpreted as coming from different sources.

 ### Important
 This can not be used to increase the visits in google analytics. The returned html respone its not interpreted by any browser 
that is why the javascript code is not executed. If your purpose is this, i recommend you use Tor (https://www.torproject.org/).

### Get a proxy list
You can get a fresh proxy list in any site such as: https://free-proxy-list.net/, use a scraper to convert the list to the uProx format json.