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
