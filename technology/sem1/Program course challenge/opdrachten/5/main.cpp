#include <Arduino.h>

void setup() {
  Serial.begin(9600);
  
  Serial.print("Is 7 greater than 5? ");
  Serial.println(7 > 5);
  
  Serial.print("Is 7 less than 5? ");
  Serial.println(7 < 5);
}

void loop() {
}