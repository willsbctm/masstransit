# Mass Transit e Azure Service Bus 
https://masstransit-project.com/MassTransit/

A solu��o permite enviar mensagens � um t�pico do azure service bus atrav�s da bibliteca do mass transit e sem a mesma.

## MassTransitWorker

Worker que recebe todas as mensagens do t�pico

## MassTransitConsole

Console que envia mensagens para o t�pico utilizando as bibliotecas do mass transit

## MassTransitConsoleServiceBus

Console que envia mensagens para o t�pico utilizando as bibliotecas do azure service bus

OBS: 
- � necess�rio seguir o envelopamento do mass transit para o consumidor conseguir interpretar a mensagem
https://masstransit-project.com/MassTransit/advanced/interoperability.html#example-message
- Tamb�m � preciso respeitar o content type
https://masstransit-project.com/MassTransit/advanced/interoperability.html#jsonbsonxml


## Importante

- Em todas os casos � necess�rio respeitar o Message Type que deve corresponder ao namespace da interface que representa a mensagem:
https://masstransit-project.com/MassTransit/usage/message-contracts.html
Para isso, foi utilizada uma biblioteca compartilhada de contratos


- � necess�rio que a conta presente na connection string do azure service bus tenha permiss�o de adminstrador porque o mass transit cria os recursos necess�rios para seu funcionamento
http://masstransit-project.com/MassTransit/understand/under-the-hood.html#starting-a-bus

