#include <Arduino.h>


int val1, val2, result;

void setup() {
  Serial.begin(9600);
  
  // change the values of val1 and val2 to see what the
  // conditional expression does
  val1 = 2;
  val2 = 5;
  // if val1 is bigger than val2, return val1
  // else if val1 is less than val2, return val2
  result = (val1 > val2) ? val1 : val2;
  
  // show result in serial monitor window
  Serial.print("The bigger number is: ");
  Serial.println(result);
}

void loop() {
}