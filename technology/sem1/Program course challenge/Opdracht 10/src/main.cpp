#include <Arduino.h>

const int PIN_BUTTON_1 = 8;   // The number of the button 1 (KEY1) pin.
const int PIN_BUTTON_2 = 9;   // The number of the button 2 (KEY2) pin.
const int PIN_LED_RED = 4; // The Number of the yellow LED pin.
int buttonState_1 = 0; // Keep track of the button 1 state.
int buttonState_2 = 0; // Keep track of the button 2 state.
const int i = 3;
int blink (int count)  {
      int i;
       for (i = 0; i < count; i++)
       {
       digitalWrite(PIN_LED_RED, HIGH);
       delay(500);
       digitalWrite(PIN_LED_RED, LOW);
       delay(500);
       }

}
void setup() {
  // put your setup code here, to run once:
    pinMode(PIN_LED_RED, OUTPUT);
    digitalWrite(PIN_BUTTON_1, INPUT_PULLUP);
    pinMode(PIN_BUTTON_2, INPUT_PULLUP); // Internal pullup as there is no pullup resistor on the Rich Shield.
     // put your main code here, to run repeatedly:
    buttonState_1 = digitalRead(PIN_BUTTON_1);
    buttonState_2 = digitalRead(PIN_BUTTON_2);
 if (i == 3)
    {
      blink(3);
    }
}
void loop() {
}