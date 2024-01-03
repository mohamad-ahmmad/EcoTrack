# EcoTrack
## Architecture:
![image](https://github.com/mohamad-ahmmad/EcoTrack/assets/98047574/c869d090-7f96-411e-8a61-161abb60cb57)

----

### API & Business logic Service: 
[Click here for code](src/)

**Configurations:**
[Click here for config](src/EcoTrack.API/appsettings.Development.json)

**Default:**
```JSON
"RabbitMq": {
    "IpAddress": "localhost",
    "ExchangeName":  "EcoTrack"
  }
```

----

### Processing service:
[Click here for code](Report_Processor_Service/)

**Configurations:**
[Click here for config](src/EcoTrack.API/appsettings.Development.json)

**Default:**
```JSON
"RabbitMq": {
    "IpAddress": "localhost",
    "ExchangeName": "EcoTrack",
    "RoutingKey": "EnviromentalReport"
  }
```

---

### RabbitMQ:
You can use the following docker image for rabbitmq instance:
```
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.12-management
```


