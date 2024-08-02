// Declaramos la intensidad del brillo
int BRILLO = 0;
// Pin de entrada del potenciometro
int pinPot=34;
// Pin de salida al led
int pinLed=2;
//Características del PWM
const int frecuencia = 1000;
const int canal = 0;
const int resolucion = 10;
void setup()
{
  //Inicializamos las características del pwm
  ledcSetup(canal, frecuencia, resolucion);
  // Definimos que el pin 2 sacara el voltaje
  ledcAttachPin(pinLed, OUTPUT);
  // ledcAttach(pinLed, frecuencia, resolucion)
  delay(1000);
}
void loop()
{
  //Obtenemos la señal del potenciometro
  BRILLO = analogRead(pinPot);
  //Mostramos la señal del potenciometro
  //desde 0 a 4095
  //Dividimos la señal en entre 16
  BRILLO = (4095 / 16.2);
  //Encendemos el led
  //ledcWrite(pinLed, BRILLO);
  analogWrite(pinLed, BRILLO);
  delay(1000);
  analogWrite(pinLed, 0);
}