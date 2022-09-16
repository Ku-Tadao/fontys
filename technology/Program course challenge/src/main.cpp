#include <Arduino.h>

#include "Display.h"

void setup() {
  Serial.begin(9600);
  pinMode(4, OUTPUT);  // LED on pin 4 of UNO
  pinMode(5, OUTPUT);  // LED on pin 4 of UNO
  pinMode(6, OUTPUT);  // LED on pin 4 of UNO
  pinMode(7, OUTPUT);  // LED on pin 4 of UNO
}

void loop() {
  char rx_byte;
  
  if (Serial.available() > 0) {    // is a character available?
    rx_byte = Serial.read();
    if (rx_byte == 'a') {
      // switch the LED on if the character 'a' is received
      digitalWrite(4, HIGH);
      digitalWrite(5, LOW);
    }
    else {
      // switch the LED off if any character except 'a' is received
      digitalWrite(4, LOW);
      digitalWrite(5, HIGH);

    }
  }
}