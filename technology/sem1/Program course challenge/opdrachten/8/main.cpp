#include <Arduino.h>

void setup() {
  int i = 0;
  
  Serial.begin(9600);
  
  while (i < 10) {
    Serial.print("i = ");
    Serial.println(i);
    i++;
  }
}

void loop() {
}