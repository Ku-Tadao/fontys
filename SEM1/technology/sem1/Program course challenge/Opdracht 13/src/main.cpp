#include <Arduino.h>

int ledPin = 6;   
int analogPin = A0; 
int val = 0;  

void setup() {
  pinMode(ledPin, OUTPUT);
}

void loop() {
  val = analogRead(analogPin); 
  analogWrite(ledPin, val / 4);
}
