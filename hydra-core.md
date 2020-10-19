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
