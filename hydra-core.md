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
### How to use specification patttern
This project contains a folder called Specification, that is a easy way to implement the specification pattern. To use it you only need to create a class that implements the abstract class ```Specification<T>```.

Example of the usage: Class for validation, for each item you will need to create a new specification.
```c#
 public class VoucherActiveSpecification : Specification<Voucher>
{
        public override Expression<Func<Voucher, bool>> ToExpression() => voucher => voucher.Active == true;
}
```

and then in you can use in your class:
```c#
  var spec = new VoucherActiveSpecification();
  return spec.IsSatisfiedBy(this);
```

#### Composing the Specification:
You can create a composite of Specification by following this example:
```c#
 var spec = new VoucherActiveSpecification()
                            .And(new VoucherDataSpecification())
                            .And(new VoucherQuantitySpecification());
return spec.IsSatisfiedBy(this);                      
```
