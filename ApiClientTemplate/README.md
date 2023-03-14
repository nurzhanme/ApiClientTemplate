# ApiClientTemplate

ApiClientTemplate is a RESTful APIs client in C# applications.

If you like this project please give a star and a cup of coffee =)

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/nurzhanme)

## Installation

[![NuGet Badge](https://buildstats.info/nuget/ApiClientTemplate)](https://www.nuget.org/packages/ApiClientTemplate/)

To install ApiClientTemplate, you can use the NuGet package manager in Visual Studio. Simply search for "ApiClientTemplate" and click "Install".

Alternatively, you can install ApiClientTemplate using the command line:

```
Install-Package ApiClientTemplate
```

## Getting Started

Firstly obtain valid ApiClientTemplate API key if it is required.

### Without using dependency injection:

```c#
var apiClient = new ApiClientTemplateClient(new ApiClientTemplateOptions()
{
    ApiKey = Environment.GetEnvironmentVariable("MY_API_KEY")
});
```

### Using dependency injection:

In your secrets.json or other settings.json

```json
"ApiClientTemplateOptions": {
  //"ApiKey": "Your api key goes here",
  //"ApiBaseAddress": "Your api base address goes here"
},
```

#### Program.cs

```c#
serviceCollection.AddApiClientTemplateClient();
```

or using Environment Variable

```c#
serviceCollection.AddApiClientTemplateClient(settings => { settings.ApiKey = Environment.GetEnvironmentVariable("MY_API_KEY"); });
```

NOTE: do NOT put your API key directly to your source code.

After injecting your service you will be able to get it from service provider

```c#
var apiClient = serviceProvider.GetRequiredService<ApiClientTemplateClient>();
```

or injecting in the constructor of your class

```c#
public class MyService
{
    private readonly ApiClientTemplateClient _apiClient;

    public NewsService(ApiClientTemplateClient apiClient)
    {
        _apiClient = apiClient;
    }
}
```

## Logging and Exception handling

For diagnostic there are 'DelegatingHandler'-s such as 'LoggingHandler' and 'ExceptionHandler'. You can always extend them