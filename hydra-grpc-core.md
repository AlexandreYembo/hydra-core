# Hydra gRPC Core
This repository contains the library to create a new gRPC service.

### gRPC Interceptor
This function is used to intercept and override the header parameters of request by adding the authentication token in the header options.

#### How to use?
You might have to register in the startup or any configuration file, by following the code:

##### Dependency Injection
```cs
  services.RegisterInterceptor();
```

##### Adding the interceptor
To add the interceptor ```AddgGRPCInterceptor``` after declaring the client factory ```AddGrpcClient``` with options, you simply define the interceptor:
```cs
   services.AddGrpcClient<BasketGrpc.BasketClient>(options => 
            {
                options.Address = new Uri(configuration["BasketUrl"]);
   }).AddgGRPCInterceptor();
```
