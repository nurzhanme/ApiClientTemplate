# ApiClientTemplate

ApiClientTemplate is a dotnet project template that provides a simple way to create RESTful APIs client in C# applications.

If you like this project please give a star or a cup of coffee =)

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/nurzhanme)

## Installation

[![NuGet Badge](https://buildstats.info/nuget/ApiClientTemplate)](https://www.nuget.org/packages/ApiClientTemplate/)

To install use dotnet cli:

```
dotnet tool install --global ApiClientTemplate
```

now you can create a new project using the template

```
dotnet new apiclient -n <ProjectName>
```

## Getting Started

Write your request methods in 'YourApiClient (<ProjectName>Client)' class

Below examples how to use your client

### Without using dependency injection:

```c#
var yourApiClient = new YourApiClient(new YourApiClientOptions()
{
    ApiKey = Environment.GetEnvironmentVariable("MY_API_KEY")
});
```

### Using dependency injection:

In your secrets.json or other settings.json

```json
"YourApiClientOptions": {
  //"ApiKey": "Your api key goes here",
  //"ApiBaseAddress": "Your api base address goes here"
},
```

#### Program.cs

```c#
serviceCollection.AddYourApiClient();
```

or using Environment Variable

```c#
serviceCollection.AddYourApiClient(settings => { settings.ApiKey = Environment.GetEnvironmentVariable("MY_API_KEY"); });
```

NOTE: do NOT put your API key directly to your source code.

After injecting your service you will be able to get it from service provider

```c#
var yourApiClient = serviceProvider.GetRequiredService<YourApiClient>();
```

or injecting in the constructor of your class

```c#
public class MyService
{
    private readonly YourApiClient _apiClient;
    
    public NewsService(YourApiClient apiClient)
    {
        _apiClient = apiClient;
    }
}
```

## Logging and Exception handling

For diagnostic there are 'DelegatingHandler'-s such as 'LoggingHandler' and 'ExceptionHandler'. You can always extend them