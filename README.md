# haarlemmertrekvaart

*Work in progress*

## Request you developer key to the NS API
https://www.ns.nl/ews-aanvraagformulier/

## Installation
*Work in progress*

## Using Haarlemmertrekvaart

### General 
Getting data from NS pretty straightforward. Create a NsClient object and enter a valid username and password.

```cs
NsClient client = new NsClient("username", "password");
```

### Examples
*Work in progress*

#### Stations
```cs
var stations = await client.StationService.GetStations();
```

### Limits
A maximum of 50,000 requests per day can be made for each service to the NS API.

## Notes
### A short summary of the NS API conditions:

+ Respect the capacity of the NS servers; try to make proper use of the capacity made available to you. If NS expects abuse, you may be immediately cut off.
+ The API is a beta-service. NS can make adjustments (sometimes technical in nature) or terminate the service at any time.
+ The developer who is given access to the API is responsible for what is done with his/her connection.
+ You are not permitted to use the NS logo in applications that you develop.
+ It is forbidden to use the API in such a way that false information is broadcast.
