#include <Arduino.h>
const int LedGreen = 5;
const int LedBlue = 6;


void setup() {
  Serial.begin(9600);
  pinMode(LedGreen, OUTPUT);

  digitalWrite(LedGreen,LOW);
  pinMode(LedBlue, OUTPUT);

  digitalWrite(LedBlue,LOW);
}

// the loop function runs over and over again forever
void loop() {


  digitalWrite(LedBlue, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(100);                       // wait for a second
  digitalWrite(LedBlue, LOW);    // turn the LED off by making the voltage LOW
  delay(100);                       // wait for a second
    digitalWrite(LedGreen, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(50);                       // wait for a second
  digitalWrite(LedGreen, LOW);    // turn the LED off by making the voltage LOW
  delay(50);  
}
