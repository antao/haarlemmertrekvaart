
# haarlemmertrekvaart [![Build status](https://ci.appveyor.com/api/projects/status/aowu3evc5c24lqay?svg=true)](https://ci.appveyor.com/project/antao/haarlemmertrekvaart) [![NuGet](https://img.shields.io/badge/nuget-1.1.0-blue.svg)](https://www.nuget.org/packages/haarlemmertrekvaart/1.1.0)

Unofficial .NET client for accessing the [NS](https://www.ns.nl/en) (Nederlandse Spoorwegen) API.

## Installation
This package is available on NuGet Gallery. To install the [haarlemmertrekvaart package](http://www.nuget.org/packages/haarlemmertrekvaart) run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console).

    PM> Install-Package haarlemmertrekvaart

## Using haarlemmertrekvaart

### General
Getting data from NS API is pretty straightforward and hopefully this client will make your life easier. Create a NsClient object and pass a valid ConnectionConfiguration object with your username and developer key.

```cs
ConnectionConfiguration connectionConfiguration = new ConnectionConfiguration("joaoantao", "myawesomekey");
NsClient nsClient = new NsClient(connectionConfiguration);
```

You can request your developer key to NS [here](https://www.ns.nl/ews-aanvraagformulier/).
The NS API only supports [Basic Access Authentication](https://en.wikipedia.org/wiki/Basic_access_authentication) __I would not recommend the use of it in any production environment__.

### Examples

#### Stations
```cs
var stations = await client.Station.GetAll();
```

#### Travel recommendations
Can be used to employ the NS Travel planner for a train journey from one station to another. A travel recommendation consists of multiple travel options, so that the passenger can make a choice. A travel recommendation includes both planned and up to date information.
Takes a departure station name and a destination station name as arguments.

```cs
var recommendations = await client.TravelPlanner.GetAll("Rotterdam+Centraal", "Amsterdam+Centraal");
```

#### Departures
Up to date departure times allows users to request an up to date overview for a station which shows all departing trains for the next hour in a specific station. Takes a departure station name as argument.

```cs
var departures = await client.Departure.GetAll("Amsterdam+Centraal");
```

#### Disruptions/Engineering works

```cs
var disruptions = await client.Disruption.GetAll("Amsterdam+Centraal", true);
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

More documentation can be found [here](http://www.ns.nl/reisinformatie/ns-api).
