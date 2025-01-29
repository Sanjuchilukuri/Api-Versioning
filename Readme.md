## Overview
This project demonstrates API versioning in an ASP.NET Core application using `Asp.Versioning`. API versioning allows clients to access different versions of an API while maintaining backward compatibility.

## Why API Versioning?
- Ensures backward compatibility for existing clients.
- Enables gradual updates and deprecations.
- Supports multiple API versioning strategies (query parameters, headers, media types, and URL versioning).
- Provides better API management and documentation.

## Dependencies
To use API versioning in an ASP.NET Core application, install the following NuGet package:
```sh
 dotnet add package Asp.Versioning.Mvc
```
To use extra options in API Explorer, install this package:
```sh
dotnet add package Asp.Versioning.Mvc.ApiExplorer
```
Additionally, install Swagger for API documentation:
```sh
 dotnet add package Swashbuckle.AspNetCore
```

## Versioning Strategies
This project supports multiple ways to specify API versions:
- **Query Parameter**: `?api-version=1.0`
- **Header**: `X-Version: 2.0`
- **Media Type**: `Accept: application/json; version=3.0`
- **URL**: `https://domain:port/api/v1/resource`

## Implementation
API versioning is configured in `Program.cs` by setting a default version, enabling version reporting, and defining multiple version readers.

### Configuring API Versioning
```csharp
builder.Services.AddApiVersioning(options => {
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
```

## Defining API Versions
Each controller is assigned an API version, allowing different implementations based on the version number.

### Example API Versions
#### Version 1 (`V1`)
Handles requests to `/api/v1/StringList` and filters data starting with `B`.
```csharp
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class StringListController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get() => Data.Summaries.Where(x => x.StartsWith("B"));
}
```
#### Version 2 (`V2`)
Handles requests to `/api/v2/StringList` and filters data starting with `S`.
```csharp
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class StringListController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get() => Data.Summaries.Where(x => x.StartsWith("S"));
}
```
#### Version 3 (`V3`)
Handles requests to `/api/v3/StringList` and filters data starting with `C`.
```csharp
[ApiVersion("3.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class StringListController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get() => Data.Summaries.Where(x => x.StartsWith("C"));
}
```

## Swagger Integration
Swagger is enabled for better API documentation and testing. Run the application and access Swagger UI at:
```
https://localhost:<port>/swagger
```
It allows selecting different API versions from a dropdown to test their responses.


## Screenshots

### Default API Version
![default-api-version](https://github.com/Sanjuchilukuri/Api-Versioning/blob/master/Images/v1-default-version.png?raw=true)

### API Versioning through Query Params
![api-version-query-params](https://github.com/Sanjuchilukuri/Api-Versioning/blob/master/Images/v1-query-params.png?raw=true)

### API Versioning through Header
![api-version-header](https://github.com/Sanjuchilukuri/Api-Versioning/blob/master/Images/header-parameter.png?raw=true)

### API Versioning through Media Type
![api-version-media-type](https://github.com/Sanjuchilukuri/Api-Versioning/blob/master/Images/mediatype.png?raw=true)

### API Versioning through URL
![api-version-url](https://github.com/Sanjuchilukuri/Api-Versioning/blob/master/Images/url.png?raw=true)


## Conclusion
API versioning is essential for maintaining API stability while rolling out new features. Using `Asp.Versioning`, multiple versions can coexist seamlessly. This approach provides flexibility, backward compatibility, and a structured way to manage API changes.

## Contact
For any questions or contributions, feel free to reach out!
