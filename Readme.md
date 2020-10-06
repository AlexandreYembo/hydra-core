# Hydra Core

This is used as a common shared library across the bounded context.


#### How to use
Instantiate via Reference, by using git submodule to create a project link in the specific bounded context.

In the bounded context folder you are working on, if there is no submodule defined, you can run this command
```git submodule add https://github.com/AlexandreYembo/hydra-core```

If there is a submodule created, but you want to get the latest version of the library you can run:
```git submodule update --remote```

#### Configuring Dependency injection in your application.

#### Registering DomainNotification
```c# 
    services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
```

# Hydra WebApi Core
This project contains configuration for WebAapi

#### Adding to Startup.cs

Adding as Service Collection
```c#
 services.AddJwtConfiguration(Configuration);
```

Using in the Application Builder
```c#
 app.UseAuthConfiguration();
```

### Using Claims Authorize
This attribute is used to allow the user to have few permission, based on claim type and value. To implement you need to use it on the controller method:

Example:
```c#
[ClaimsAuthorize("Catalog", "Read")]
[HttpGet()]
```
This also needs to be inserted on the table: ```AspNetUserClaims``` where you validate the user are defined on this table.

### Using HttpClientAuthorizationDelegatingHandler
This class overrides the SendAsyc method of HttpClient. You can pass the token through the Header, by intercepting the request.

###### Register on Dependency Injection
```c#
    services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
```
Where use ```AddTransient``` because it is working on the scope of the request.

Also you need to register the HttpMessageHandler to the HttpClient.

Example
```c#
    services.AddHttpClient<ICatalogService, CatalogService>()
            .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>(); // It will use this delegating Handler to manipulate the request when you use the httpclient
```
