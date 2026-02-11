#include <Servo.h>

// SERVO ROTOR
const int servoRotorPin = 2;
Servo servoRotor;

// SERVO ROJO
const int servoRojoPin = 3;
Servo servoRojo;

// SERVO VERDE
const int servoVerdePin = 4;
Servo servoVerde;

// DETECTOR DE COLOR
const int colorS0 = 8;  
const int colorS1 = 9;  
const int colorS2 = 10;  
const int colorS3 = 11;  
const int colorOut = 12; 

// COLORES
const String colorRojo = "ROJO";
const String colorVerde = "VERDE";
const String colorAzul = "AZUL";

// CONFIGURACION
void setup() {
  Serial.begin(9600);
  configurarServo360();
  configurarServoRojo();
  configurarServoVerde();
  configurarColor();
}

// LOGICA

void loop() {
  String color = leerColor();

  if (color == colorRojo) {
    delay(1000); // 1000 milisegundos es 1 segundo
    seleccionarRojo();
  } else if (color == colorVerde) {
    delay(1000);
    seleccionarVerde();
  }

}

// CONFIGURACION

void configurarServo360() {
  servoRotor.attach(servoRotorPin);
  servoRotor.write(100);
}

void configurarServoRojo() {
  servoRojo.attach(servoRojoPin);
  servoRojo.write(0);
}

void configurarServoVerde() {
  servoVerde.attach(servoVerdePin);
  servoVerde.write(180);
}

void configurarColor() {
  pinMode(colorS0, OUTPUT);  
  pinMode(colorS1, OUTPUT);  
  pinMode(colorS2, OUTPUT);  
  pinMode(colorS3, OUTPUT);  
  pinMode(colorOut, INPUT);

  digitalWrite(colorS0, HIGH);
  digitalWrite(colorS1, HIGH);
  delay (4000);
}

// FUNCIONALIDAD

void seleccionarRojo() {
  int pos = 0;

  // Gira el servo de 0 a 180 grados
  for (pos = 0; pos <= 90; pos += 1) {
    servoRojo.write(pos);  // Indica al servo que vaya a la posición 'pos'
    delay(15);  // Espera 15 milisegundos para que el servo alcance la posición
  } 
  // Gira el servo de 180 a 0 grados
  for (pos = 90; pos >= 0; pos -= 1) {
    servoRojo.write(pos);  // Indica al servo que vaya a la posición 'pos'
    delay(15);  // Espera 15 milisegundos para que el servo alcance la posición
  }
}

void seleccionarVerde() {
  int pos = 0;
  // Gira el servo de 180 a 0 grados
  for (pos = 180; pos >= 90; pos -= 1) {
    servoVerde.write(pos);  // Indica al servo que vaya a la posición 'pos'
    delay(15);  // Espera 15 milisegundos para que el servo alcance la posición
  }

  // Gira el servo de 0 a 180 grados
  for (pos = 90; pos <= 180; pos += 1) {
    servoVerde.write(pos);  // Indica al servo que vaya a la posición 'pos'
    delay(15);  // Espera 15 milisegundos para que el servo alcance la posición
  }
}

String leerColor() {
  int rojo = leerRojo();
  // Delay para estabilizar el sensor
  delay(200);
  int verde = leerVerde();
  // Delay para estabilizar el sensor
  delay(200);
  int azul = leerAzul(); 
  // Delay para estabilizar el sensor
  delay(200);
  String color = "NO_COLOR";

  if (rojo < azul && verde > azul && rojo < 35) {  
    color = colorRojo;   
  } else if (azul < rojo && azul < verde && verde < rojo) {  
    color = colorAzul;        
  } else if (rojo > verde && azul > verde ) {  
    color = colorVerde;
  }  
  imprimirColores(rojo, verde, azul, color);
  return color;
}

int leerRojo() {
  digitalWrite(colorS2, LOW);
  digitalWrite(colorS3, LOW);
  //count OUT, pRed, RED
  return pulseIn(colorOut, digitalRead(colorOut) == HIGH ? LOW : HIGH);  
}

int leerVerde() {
  digitalWrite(colorS2, HIGH);
  digitalWrite(colorS3, HIGH);
  return pulseIn(colorOut, digitalRead(colorOut) == HIGH ? LOW : HIGH);
}

int leerAzul() {
  digitalWrite(colorS2, LOW);
  digitalWrite(colorS3, HIGH);
  return pulseIn(colorOut, digitalRead(colorOut) == HIGH ? LOW : HIGH);
}

void imprimirColores(int rojo, int verde, int azul, String color) {
  Serial.print("R =");
  Serial.print(rojo, DEC);
  Serial.print(" G = ");
  Serial.print(verde, DEC);
  Serial.print(" B = ");
  Serial.print(azul, DEC);
  Serial.print("\t");
  Serial.println(color);
}

