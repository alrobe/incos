int lectura;
int const pinLetRojo = 9;

void setup() {
  Serial.begin(9600);
  pinMode(pinLedRojo, OUTPUT);
}

void loop() {
  int lectura = analogRead(A0);
  Serial.println(lectura);
  delay(500);
  int brillo = lectura/4;
  analogWrite(pinLedRojo, brillo);
}
