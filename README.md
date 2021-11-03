# Stocks
<img src="https://img.shields.io/github/license/adamjedrzejewski/stocks">

<!-- About -->
## About the project

## Getting started
### Prerequisites
You will need [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0) and running instance of [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
### Installation
Clone the repository
```
git clone https://github.com/adamjedrzejewski/stocks.git
```
Restore dependencies
```
```
### Configuration
Put configuration options in _Server/appsettings.json_, consider using secrets if for other purposes than testing.<br>
You will need:
1. SQL Server connection string
```json
"ConnectionStrings": {
  "default": "{your connection string}"
}
```

2. Alpha Vantage API key. Get one [_here_](https://www.alphavantage.co/support/#api-key).
```json
"AlphaVantageApiKey": "{your api key}"
```

### Running
```
```

<!-- Built with -->
## Built with
* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
* [ASP.NET Core](https://github.com/dotnet/aspnetcore)
* [Entity Framework Core](https://github.com/dotnet/efcore)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2019)
* [Alpha Vantage Stock API](https://www.alphavantage.co/)

<!-- LICENSE -->
## License
Distributed under the BSD-3-Clause License. See `LICENSE` for more information.
