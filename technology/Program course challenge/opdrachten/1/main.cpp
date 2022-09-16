#include <Arduino.h>

void setup() {
  Serial.begin(9600);
  Serial.println("Hello world | Boot");
}

void loop() {
  Serial.println("Hello world | Loop");
}