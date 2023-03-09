#include <Arduino.h>
#include "Display.h"

const int PIN_LED_RED = 4;    // The Number of the red LED pin.
const int PIN_LED_GREEN = 5;  // The Number of the green LED pin.
const int PIN_LED_YELLOW = 7; // The Number of the yellow LED pin.
const int PIN_BUTTON_1 = 8;   // The number of the button 1 (KEY1) pin.
const int PIN_BUTTON_2 = 9;   // The number of the button 2 (KEY2) pin.

int buttonState_1 = 0; // Keep track of the button 1 state.
int buttonState_2 = 0; // Keep track of the button 2 state.
int amountOfPeople = 0;
int maxPeople = 0;
int checker = 0;

void setup() {
  // put your setup code here, to run once:
    Serial.begin(9600); // Initialize serial port.
    pinMode(PIN_LED_RED, OUTPUT);
    pinMode(PIN_LED_GREEN, OUTPUT);
    pinMode(PIN_LED_YELLOW, OUTPUT);
    pinMode(PIN_BUTTON_1, INPUT_PULLUP); // Internal pullup as there is no pullup resistor on the Rich Shield. 
    pinMode(PIN_BUTTON_2, INPUT_PULLUP); // Internal pullup as there is no pullup resistor on the Rich Shield. 

    digitalWrite(PIN_LED_YELLOW, HIGH);
    amountOfPeople = 0;
    maxPeople = 10;

    Display.show(maxPeople);
    delay(2000);
    Display.show(amountOfPeople);
    digitalWrite(PIN_LED_YELLOW, LOW);
    digitalWrite(PIN_LED_GREEN, HIGH);
}

void loop() {
  // put your main code here, to run repeatedly:

    buttonState_1 = digitalRead(PIN_BUTTON_1);
    buttonState_2 = digitalRead(PIN_BUTTON_2);

    if (buttonState_1 == LOW)
    {
        // Turn the led on (the button is active LOW).
        amountOfPeople++;
        Display.show(amountOfPeople);
        delay(250);
    }

    //===== Loop =====
    if (amountOfPeople == maxPeople)
    {

      digitalWrite(PIN_LED_GREEN, LOW);

      for (int i = 0; i < 3; i++)
      {
        delay(500);
        digitalWrite(PIN_LED_RED, HIGH);
        delay(500);
        digitalWrite(PIN_LED_RED, LOW);
      }
      
      digitalWrite(PIN_LED_YELLOW, HIGH);
      amountOfPeople = 0;
      Display.show(amountOfPeople);
      delay(2000);
      digitalWrite(PIN_LED_YELLOW, LOW);
      digitalWrite(PIN_LED_GREEN, HIGH);      
    }
    //===== loop =====

    //===== while =====
    while (amountOfPeople == maxPeople)
      if (checker <= 2)
      {
        //delay(500);
        //digitalWrite(PIN_LED_RED, HIGH);
        //delay(500);
        //digitalWrite(PIN_LED_RED, LOW);
        //checker++;
      }
      else
      {
        //digitalWrite(PIN_LED_YELLOW, HIGH);
        //amountOfPeople = 0;
        //Display.show(amountOfPeople);
        //delay(2000);
        //digitalWrite(PIN_LED_YELLOW, LOW);
        //digitalWrite(PIN_LED_GREEN, HIGH);
        //checker = 0;
      }
      //===== while =====
    }