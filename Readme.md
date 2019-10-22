# Mass Transit e Azure Service Bus 
https://masstransit-project.com/MassTransit/

A solução permite enviar mensagens à um tópico do azure service bus através da bibliteca do mass transit e sem a mesma.

## MassTransitWorker

Worker que recebe todas as mensagens do tópico

## MassTransitConsole

Console que envia mensagens para o tópico utilizando as bibliotecas do mass transit

## MassTransitConsoleServiceBus

Console que envia mensagens para o tópico utilizando as bibliotecas do azure service bus

OBS: 
- É necessário seguir o envelopamento do mass transit para o consumidor conseguir interpretar a mensagem
https://masstransit-project.com/MassTransit/advanced/interoperability.html#example-message
- Também é preciso respeitar o content type
https://masstransit-project.com/MassTransit/advanced/interoperability.html#jsonbsonxml


## Importante

- Em todas os casos é necessário respeitar o Message Type que deve corresponder ao namespace da interface que representa a mensagem:
https://masstransit-project.com/MassTransit/usage/message-contracts.html
Para isso, foi utilizada uma biblioteca compartilhada de contratos


- É necessário que a conta presente na connection string do azure service bus tenha permissão de adminstrador porque o mass transit cria os recursos necessários para seu funcionamento
http://masstransit-project.com/MassTransit/understand/under-the-hood.html#starting-a-bus

