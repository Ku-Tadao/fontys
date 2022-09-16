#include <Arduino.h>


void setup() {
  Serial.begin(9600);
  
  DashedLine();
  Serial.println("| Program Menu |");
  DashedLine();
}

void loop() {
}

void DashedLine()
{
  Serial.println("----------------");
}
