#include <Arduino.h>

void setup() {
  int i;
  
  Serial.begin(9600);
  
  for (i = 0; i < 10; i++) {
    Serial.print("i = ");
    Serial.println(i);
  }
}

void loop() {
}