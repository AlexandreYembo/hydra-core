# Hydra Core

This is used as a common shared library across the bounded context.


#### How to use
Instantiate via Reference, by using git submodule to create a project link in the specific bounded context.

In the bounded context folder you are working on, if there is no submodule defined, you can run this command
```git submodule add https://github.com/AlexandreYembo/hydra-core```

If there is a submodule created, but you want to get the latest version of the library you can run:
```git submodule update --remote```


#### Registering DomainNotification Mediator
In the startup file, before call the method to register the depedency injection, you may register the MediatR.

```c#
services.AddMediatR(typeof(Startup));
```

##### Configuring Dependency injection in your application.
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

##### Setup the Host Environment

On the constructor of your Startup file you have to add this line:
```c#
Configuration = HostEnvironmentConfiguration.AddHostEnvironment(hostEnvironment);
```

##### Setup Swagger to the API

On this sector you can simply pass through the configuration few informations from your API:

Example:
```c#
services.AddSwaggerConfiguration(new SwaggerConfig{Title = "Hydra Customer API", 
                        Description = "This API can be used as part of an ecommerce or any other type of enterprise application", 
                        Version = "v1"});
```
and also you have to use the configuration:
```c#
app.UseSwaggerConfiguration(new SwaggerConfig{Version = "v1"});
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

#### Register Http Client on Dependency Injection
```c#
services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
```
Where use ```AddTransient``` because it is working on the scope of the request.

Also you need to register the HttpMessageHandler to the HttpClient.

Example
```c#
services.AddHttpClient<ICatalogService, CatalogService>()
        .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>(); 
// It will use this delegating Handler to manipulate the request when you use the httpclient
```
All requests coming from a service registred by using ```AddHttpClient``` will be intercepted by the Delegating Handler once you register as ```AddHttpMessageHandler```

Also you can add Certificate configuration if you are gonna have a comunication beetween apis.
```c#
services.AddHttpClient<ICatalogService, CatalogService>()
        .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
        .AllowSelfSignedCertificate(); -> this will self assign the certificate to prevent SSL certificate error
```
In addition on this section you can complete this configuration adding policy of retry and circuit breaker.

This is the complete configuration:
```c#
 services.AddHttpClient<ICatalogService, CatalogService>()
         .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
         .AllowSelfSignedCertificate()
         .AddPolicyHandler(PollyExtensions.WaitAndRetry())
         .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
```


# Hydra Core MessageBus
This project is used to implement message Bus, by using EasynetQ library and RabbitMQ implementation.

#### Register on Dependency Injection
```c#
services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
```

