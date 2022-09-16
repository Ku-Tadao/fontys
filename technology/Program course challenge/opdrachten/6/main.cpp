#include <Arduino.h>

void setup() {
  int count = 0;
  
  Serial.begin(9600);
  
  Serial.println(count++);
  Serial.println(count++);
  Serial.println(count++);
  
  Serial.println(count);
}

void loop() {
}