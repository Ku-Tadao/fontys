#include <Arduino.h>
#include "Display.h"

const int PIN_BUTTON_1 = 8;  
int buttonState_1 = 0; 
int In = 1;

void setup()
{
    Serial.begin(9600); 
      pinMode(PIN_BUTTON_1, INPUT_PULLUP);
}
void loop()
{
  if (buttonState_1 == LOW)
    {
      In++;
    Serial.println(In);
    delay(1000);
    }
    else
    {
    }
} 