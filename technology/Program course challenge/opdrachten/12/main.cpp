#include <Arduino.h>


void setup() {
  Serial.begin(9600);
  pinMode(13, OUTPUT);  // LED on pin 13 of UNO
}

char first_char = 0;

void loop() {
  char rx_byte;
  
  if (Serial.available() > 0) {    // is a character available?
    rx_byte = Serial.read();       // read the character
    if ((first_char == 'c') && (rx_byte == 'd')) {
      digitalWrite(13, HIGH);
    }
    else {
      first_char = rx_byte;        // save the character for next comparison
      digitalWrite(13, LOW);
    }
  }
}