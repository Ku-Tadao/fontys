#include <Arduino.h>
#include <Display.h>

const int PIN_LED_GREEN = 5;  // The Number of the green LED pin.
const int PIN_LED_BLUE = 6;   // The Number of the blue LED pin.
const int PIN_LED_YELLOW = 7; // The Number of the yellow LED pin.
const int PIN_LED_RED = 4; // The Number of the yellow LED pin.
const int PIN_BUTTON_1 = 8;   // The number of the button 1 (KEY1) pin.
const int PIN_BUTTON_2 = 9;   // The number of the button 2 (KEY2) pin.
int buttonState_1 = 0; // Keep track of the button 1 state.
int buttonState_2 = 0; // Keep track of the button 2 state.
int active = PIN_LED_YELLOW;
int count = 0;
 
void setup() {
  
    Serial.begin(9600); // Initialize serial port.
    pinMode(PIN_LED_GREEN, OUTPUT);
    pinMode(PIN_LED_BLUE, OUTPUT);
    pinMode(PIN_LED_YELLOW, OUTPUT);
    pinMode(PIN_LED_RED, OUTPUT);
    pinMode(PIN_BUTTON_1, INPUT);
 
    pinMode(PIN_BUTTON_2, INPUT_PULLUP); // Internal pullup as there is no pullup resistor on the Rich Shield. 
    digitalWrite(PIN_LED_YELLOW, HIGH);
    digitalWrite(PIN_BUTTON_1, INPUT_PULLUP);
    digitalWrite(PIN_LED_YELLOW, HIGH);

    }

void loop() { 
  buttonState_1 = digitalRead(PIN_BUTTON_1);
  buttonState_2 = digitalRead(PIN_BUTTON_2);

    if (buttonState_1 == LOW)
    {
      count++;
      Display.show(count);

      if (active == PIN_LED_YELLOW)
      {
        digitalWrite(PIN_LED_YELLOW, LOW);
        delay (400);
        digitalWrite(PIN_LED_BLUE, HIGH);
        delay (400);
        active = PIN_LED_BLUE;
      }

      else if (active == PIN_LED_BLUE)
      {
        digitalWrite(PIN_LED_BLUE, LOW);
        delay (400);
        digitalWrite(PIN_LED_GREEN, HIGH);
        delay (400);
        active = PIN_LED_GREEN;
      }

      else if (active == PIN_LED_GREEN)
      {
        digitalWrite(PIN_LED_GREEN, LOW);
        delay (400);
        digitalWrite(PIN_LED_YELLOW, HIGH);
        delay (400);
        active = PIN_LED_YELLOW;
      }
    } 

    //low

    else if (buttonState_2 == LOW && count > 0)
    {
      count--;
      Display.show(count);
      delay(400);

       if (active == PIN_LED_GREEN)
      {
        digitalWrite(PIN_LED_GREEN, LOW);
        delay (400);
        digitalWrite(PIN_LED_BLUE, HIGH);
        delay (400);
        active = PIN_LED_BLUE;
      }

      else if (active == PIN_LED_BLUE)
      {
        digitalWrite(PIN_LED_BLUE, LOW);
        delay (400);
        digitalWrite(PIN_LED_YELLOW, HIGH);
        delay (400);
        active = PIN_LED_GREEN;
      }

      else if (active == PIN_LED_YELLOW)
      {
        digitalWrite(PIN_LED_YELLOW, LOW);
        delay (400);
        digitalWrite(PIN_LED_GREEN, HIGH);
        delay (400);
        active = PIN_LED_YELLOW;
      }
    } 
}
