#include <Arduino.h>
#include <Display.h>

const int buttonPin = 8;  
const int buttonPin1 = 9;  

const int ledPin =  4;    

int buttonState = 0;   
int buttonState1 = 0;    

int count = 0;

void setup() {
  pinMode(ledPin, OUTPUT);
  pinMode(buttonPin, INPUT_PULLUP);
    pinMode(buttonPin1, INPUT_PULLUP);

}

void loop() {
  buttonState = digitalRead(buttonPin);
    buttonState1 = digitalRead(buttonPin1);


  if (buttonState == LOW) {
    count++;
    delay(400);
    Display.show(count);
  } else {
  }
  if (buttonState1 == LOW) {
    count--;
    delay(400);
    Display.show(count);
  } else {
  }
}
