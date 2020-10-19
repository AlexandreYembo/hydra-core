
1- [Hydra Core](https://github.com/AlexandreYembo/hydra-core/blob/master/hydra-core.md) 
1- [Hydra Core WebApi](https://github.com/AlexandreYembo/hydra-core/blob/master/hydra-core-webapi.md) 
1- [Hydra Core MessageBus](https://github.com/AlexandreYembo/hydra-core/blob/master/hydra-core-messagebus.md) 


# Hydra Core MessageBus
This project is used to implement message Bus, by using EasynetQ library and RabbitMQ implementation.

#### Registering on Dependency Injection
```c#
services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
```

