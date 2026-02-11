#include <SoftwareSerial.h>
#include <Servo.h>

// BLUETOOTH
// RX y TX del Arduino conectados al Bluetooth
SoftwareSerial BT(10,11);
int senialBT = 0; 

// PUENTE H
// pines de señales PWM Velocidad desactivados
// const int ena = 4;
// const int enb = 5;
const int en = 0;
// pines de control de dirección
// Motor derecha A
const int in1 = 9;
const int in2 = 8;
// Motor izquierda B
const int in3 = 7;
const int in4 = 6;

// ULTRASONICO
const int trigPin = 12;
const int echoPin = 13;

// SERVO
const int servoPin = 5;
// Crear el objeto Servo
Servo myServo;

// BUZZER
const int buzzerPin = 2;

// LED
const int greenLEDPin = 3;
const int redLEDPin = 4;

void setup() {
  setupMotor(en, in1, in2);
  setupMotor(en, in3, in4);
  setupUltrasonico();
  setupBT();
  setupServo();
  setupLed();
  // Configurar Buzzer como salida
  pinMode(buzzerPin, OUTPUT);

  Serial.begin(9600);
}

void loop() {
  if (hayObstaculo()) {
    tone(buzzerPin, 3000);
    digitalWrite(greenLEDPin, LOW);
    digitalWrite(redLEDPin, HIGH);
  } else {
    noTone(buzzerPin);
    digitalWrite(greenLEDPin, HIGH);
    digitalWrite(redLEDPin, LOW);
  }
  
  if(BT.available()) 
  {
    senialBT = BT.read();
    Serial.println(senialBT);
    if (senialBT==70 && !hayObstaculo()) { 
      avanzar();
    } else if (senialBT==66) {
      retroceder();
    } else if (senialBT==82) {
      derecha();
    } else if (senialBT==76) {
      izquierda();
    } else if (senialBT==83) {
      detener();
    } else if (senialBT==88) {
      subirPala();
    } else if (senialBT==89) {
      bajarPala();
    }
  }
}

//CONFIGURACION

void setupMotor(int en, int in1, int in2) {
  // configurar los pines de control de motores como salidas

  // pines de control del motor
  // pin de control de velocidad motor
  // pinMode(en, OUTPUT);
  // control de dirección motor
  pinMode(in1, OUTPUT);
  pinMode(in2, OUTPUT);

  // configurar el estado de las salidas del puente H para detener los
  // motores y en caso de que tengamos conectados los pines EN,
  // habilitar los puentes H colocando las señales correspondientes en
  // nivel alto. En este ejemplo las señales EN no se usarán
  // para el control de velocidad.
  // digitalWrite(en, HIGH);
  digitalWrite(in1, LOW);
  digitalWrite(in2, LOW);
}

void setupUltrasonico() {
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
}

void setupBT() {
  BT.begin(9600);
}

void setupServo() {
  myServo.attach(servoPin);
  myServo.write(15);
}

void setupLed() {
  pinMode(greenLEDPin, OUTPUT);
  pinMode(redLEDPin, OUTPUT);
}

// FUNCIONALIDAD

void avanzar() {
  // motor A adelante
  digitalWrite(in1, LOW);
  digitalWrite(in2, HIGH);
  // motor B adelante
  digitalWrite(in3, HIGH);
  digitalWrite(in4, LOW);
}

void retroceder() {
  // motor A atras
  digitalWrite(in1, HIGH);
  digitalWrite(in2, LOW);
  // motor B atrás
  digitalWrite(in3, LOW);
  digitalWrite(in4, HIGH);
}

void izquierda() {
  // motor A adelante
  digitalWrite(in1, LOW);
  digitalWrite(in2, HIGH);
  // motor B detenido
  digitalWrite(in3, LOW);
  digitalWrite(in4, LOW);
}

void derecha() {
  // motor A detenido
  digitalWrite(in1, LOW);
  digitalWrite(in2, LOW);
  // motor B adelante
  digitalWrite(in3, HIGH);
  digitalWrite(in4, LOW);
}

void detener() {
  // motor A detenido
  digitalWrite(in1, LOW);
  digitalWrite(in2, LOW);
  // motor B detenido
  digitalWrite(in3, LOW);
  digitalWrite(in4, LOW); 
}

float ultrasinicoDistanciaCm() {
  long duration;
  float distance;

  // Generar un pulso de 10 microsegundos en el pin de trig
  digitalWrite(trigPin, LOW);
  delayMicroseconds(5);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);

  // Medir el tiempo del pulso en el pin de echo
  duration = pulseIn(echoPin, HIGH);

  // Calcular la distancia en cm
  distance = (duration / 2) / 29.1;
  //Serial.print("La distancia es: ");
  //Serial.println(distance);
  return distance;
}

bool hayObstaculo() {
  float distancia = ultrasinicoDistanciaCm();
  return distancia > 0 && distancia < 15;
}

void subirPala() {
  myServo.write(45);
}

void bajarPala() {
  myServo.write(15);
}

