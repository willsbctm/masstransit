# Masstransit 
https://masstransit-project.com/MassTransit/

## MassTransitWorker

Worker que recebe todas as mensagens do t�pico

## MassTransitConsole

Console que envia mensagens para o t�pico utilizando as bibliotecas do masstransit

## MassTransitConcolserServiceBus

Console que envia mensagens para o t�pico utilizando as bibliotecas do azure service bus

OBS: � necess�rio seguir o envelopamento do masstransit para o consumidor conseguir interpretar a mensagem
https://masstransit-project.com/MassTransit/advanced/interoperability.html#example-message
Tamb�m � preciso respeitar o content type
https://masstransit-project.com/MassTransit/advanced/interoperability.html#jsonbsonxml




Em todas os casos � necess�rio respeitar o Message Type que deve corresponder ao namespace da interface que representa a mensagem:
https://masstransit-project.com/MassTransit/usage/message-contracts.html
Para isso, foi utilizada uma biblioteca compartilhada de contratos

