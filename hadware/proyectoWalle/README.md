# Proyecto wall-e
Este es un proyecto de aruino donde se simula el movimiento de un robot con dos motores.
Los motores se controlan mediante un puente H L298N.
Se utiliza la aplicacion [Arduino Car](https://play.google.com/store/apps/details?id=com.electro_tex.bluetoothcar&pcampaignid=web_share) para controlar el robot mediante bluetooth.
Si el ultrasonido detecta un objeto a menos de 15 cm, el robot se detiene, se enciende el led rojo y se emite un sonido de alerta.
Si no hay obstaculos, el led verde se enciende, se deja de emitir el sonido de alerta y el robot se puede mover libremente.
El robot tiene un pala que se puede subir y bajar mediante un servo motor, este se controla con el boton de la aplicacion X y Y.
