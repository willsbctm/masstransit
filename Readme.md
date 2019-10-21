# Masstransit 
https://masstransit-project.com/MassTransit/

## MassTransitWorker

Worker que recebe todas as mensagens do tópico

## MassTransitConsole

Console que envia mensagens para o tópico utilizando as bibliotecas do masstransit

## MassTransitConcolserServiceBus

Console que envia mensagens para o tópico utilizando as bibliotecas do azure service bus

OBS: é necessário seguir o envelopamento do masstransit para o consumidor conseguir interpretar a mensagem
https://masstransit-project.com/MassTransit/advanced/interoperability.html#example-message
Também é preciso respeitar o content type
https://masstransit-project.com/MassTransit/advanced/interoperability.html#jsonbsonxml




Em todas os casos é necessário respeitar o Message Type que deve corresponder ao namespace da interface que representa a mensagem:
https://masstransit-project.com/MassTransit/usage/message-contracts.html
Para isso, foi utilizada uma biblioteca compartilhada de contratos

