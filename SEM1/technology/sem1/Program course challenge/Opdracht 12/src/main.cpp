#include <Arduino.h>
#include <display.h>
const int button1 = 8;
const int button2 = 9;
int i;
int my_array[5];
int count;

void setup()
{
  pinMode(button1, INPUT_PULLUP);
  Display.show(0);


  Serial.begin(9600);
  my_array[0] = 5;
  my_array[1] = 10;
  my_array[2] = 6;
  my_array[3] = 2;
  my_array[4] = 9;

  count = my_array[0] + my_array[1] + my_array[2] + my_array[3] + my_array[4];
}

void loop() 
{
  int buttonpressed = digitalRead(button1);

  if (buttonpressed == LOW)
  {
    Serial.println((String)my_array[0] + " + " + my_array[1] + " + " + my_array[2] + " + " + my_array[3] + " + " + my_array[4] + " = ");
    Serial.println(count);
    Display.show(count);
    delay(200);
  }

}