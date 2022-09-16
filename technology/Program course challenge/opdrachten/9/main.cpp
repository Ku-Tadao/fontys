#include <Arduino.h>

void setup() {
  Serial.begin(9600);
}

void loop() {
  char rx_byte;
  
  if (Serial.available() > 0) {    // is a character available?
    rx_byte = Serial.read();       // get the character
    Serial.print("You typed: ");
    Serial.println(rx_byte);
  }
}