# Hydra Core MessageBus
This project is used to implement message Bus, by using EasynetQ library and RabbitMQ implementation.

#### Registering on Dependency Injection
```c#
services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
```
