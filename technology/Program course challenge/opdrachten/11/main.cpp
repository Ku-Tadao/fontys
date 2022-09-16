#include <Arduino.h>


void setup() {
  Serial.begin(9600);
  pinMode(4, OUTPUT);  // LED on pin 4 of UNO
}

char rx_byte = 0;

void loop() {
  if (Serial.available() > 0) {    // is a character available?
    rx_byte = Serial.read();
  }
  if (rx_byte == 'a') {
    digitalWrite(4, HIGH);
    delay(500);
    digitalWrite(4, LOW);
    delay(500);
  }
  else if (rx_byte == 'b') {
    digitalWrite(4, HIGH);
    delay(200);
    digitalWrite(4, LOW);
    delay(200);
  }
}