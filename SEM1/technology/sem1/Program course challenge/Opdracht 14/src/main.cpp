#include <Arduino.h>


String message;


void setup() {

  Serial.begin(9600);
}



void loop() {
  if (Serial.available() > 0)
  {
    int input = Serial.parseInt();  // keep other operations outside the sq function
    int inputSquared = sq(input);
    Serial.println(inputSquared);
  }
}