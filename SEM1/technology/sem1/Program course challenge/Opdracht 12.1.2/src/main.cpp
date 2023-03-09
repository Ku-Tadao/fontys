#include <Arduino.h>

const int ledred = 4;
const int ledblue = 6;
const int button1 = 8;
const int button2 = 9;
int my_array[] = {0,0,0,0};
const int maxCount = 4;
int count = 0;

void checkcount()
{
  count++;
  if (count == maxCount)
  {
    for (size_t i = 0; i < 4; i++)
    {
      digitalWrite(my_array[i],HIGH);
      delay(150);
      digitalWrite(my_array[i],LOW);
      delay(150);
    }
    count = 0;
  }
}
void setup()
{
  pinMode(button1, INPUT_PULLUP);
  pinMode(button2, INPUT_PULLUP);

  pinMode(ledred, OUTPUT);
  pinMode(ledblue, OUTPUT);
}

void loop() 
{
 int buttonpressed1 = digitalRead(button1);
 int buttonpressed2 = digitalRead(button2);

 if (buttonpressed1 == LOW)
 {
  my_array[count] = ledred;
  digitalWrite(ledred, HIGH);
  delay(150);
  digitalWrite(ledred, LOW);
  delay(150);
  checkcount();
 }
 if (buttonpressed2 == LOW)
 {
    my_array[count] = ledblue;
    digitalWrite(ledblue, HIGH);
    delay(150);
    digitalWrite(ledblue, LOW);
    delay(150);
    checkcount();
 }
  delay(150);
}
