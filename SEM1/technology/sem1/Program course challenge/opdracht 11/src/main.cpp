#include <Arduino.h>
 
int state;
const int blinkState = 1;
const int blinkstate2 = 2;
const int shuffleState = 3;
const int buttonLeft = 9;
const int buttonRight = 8;
const int ledRed = 4;
int previousLeftButtonState = HIGH;
int previousRightButtonState = HIGH;
 void LedOn(int led)
{
  digitalWrite(led,HIGH);
}
 void LedOff(int led)
{
  digitalWrite(led,LOW);
} 
void BlinkLed(int led)
{
  LedOn(led);
  delay(100);
  LedOff(led);
  delay(100);
}
void BlinkLed(int led, int nrOfTimes)
{
  for (int i = 0; i < nrOfTimes; i++)
  {
    BlinkLed(led);
  } 
}
 void HandleState()
{
  switch (state)
  {
  case blinkState:
    BlinkLed(ledRed,3);
    break;
  case blinkstate2:
    BlinkLed(ledRed,5);
    break;
  }
  
}
 
void SwitchState()
{
  switch (state)
  {
  case blinkState:
    state = blinkstate2;
    break;
  case blinkstate2:
    state = shuffleState;
    break;
  }
  
}
void setup() {
  // put your setup code here, to run once:
  pinMode(buttonLeft,INPUT_PULLUP);
  pinMode(buttonRight,INPUT_PULLUP);
 
  pinMode(ledRed, OUTPUT);
  state = blinkState;
}
void loop() {
  // put your main code here, to run repeatedly:
  int leftButtonState = digitalRead(buttonLeft);
  int rightButtonState = digitalRead(buttonRight);
  if (leftButtonState == LOW && previousLeftButtonState != leftButtonState)
  {
    SwitchState();
  }
 
  if (rightButtonState == LOW && previousRightButtonState != rightButtonState)
  {
    HandleState();
  }
 
  previousLeftButtonState = leftButtonState;
  previousRightButtonState = rightButtonState; 
}