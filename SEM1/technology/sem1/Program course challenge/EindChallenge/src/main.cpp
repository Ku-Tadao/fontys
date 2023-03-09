#include <Arduino.h>
#include "Display.h"
#include "DHT11.h"
//
const int Buzzer = 3;
const int ledRed = 4;
const int ledGreen = 5;
const int ledBlue = 6;
const int ledYellow = 7;
const int KeyPin1 = 8;
const int KeyPin2 = 9;
const int knobPin = 14;
const int LDRPIN = 16;
const int NTC = A1;
int teller = 0;
int OFFSET = 0;
int index = 0;
int KeyState1;
int KeyState2;
int lastKeyState1 = HIGH; // previous state of button1
int lastKeyState2 = HIGH; // previous state of button2
bool togglekey1 = LOW;
bool togglekey2 = LOW;
int toggleTemperature = 0;
int toggleHumidity = 0;
int buttonstate1 = 0;

unsigned long timeelapsed;
unsigned long DebounceTimeKey1 = 0; // the last time the output pin was toggled
unsigned long DebounceTimeKey2 = 0; // the last time the output pin was toggled
unsigned long prevmeasureTime = 0;
unsigned long previousTime = 0;
unsigned long prevHLightsTime = 0;
const int MEAS_UPDATEFREQ = 5000;
const int DEBOUNCEDELAY = 50;
const int MAXLEFT = -120; //
const int MAXRIGHT = 120; //
const int NTC_MAT_CONSTANT = 3950;
//====

void setup()
{
  // put your setup code here, to run once:
  pinMode(LDRPIN, INPUT);
  pinMode(knobPin, INPUT);
  pinMode(KeyPin1, INPUT_PULLUP);
  pinMode(KeyPin2, INPUT_PULLUP);
  pinMode(ledRed, OUTPUT);
  pinMode(ledGreen, OUTPUT);
  pinMode(ledBlue, OUTPUT);
  pinMode(ledYellow, OUTPUT);
  pinMode(Buzzer, OUTPUT);
  Display.clear();
  Display.show("-88-");
  Serial.begin(9600);
}

void lightPattern1(void);
void lightPattern2(void);
void lightPattern3(void);
void lightPattern4(void);
void lightPatternAll(void);
void lightshow(void);
int option = 0;

void loop()
{
  
  int readState2 = digitalRead(KeyPin2);
  if (readState2 != lastKeyState2)
  {
    // reset the debouncing timer
    DebounceTimeKey1 = millis();
    DebounceTimeKey2 = millis();
  }
  if ((millis() - DebounceTimeKey2) > DEBOUNCEDELAY)
  {
    if (readState2 != KeyState2)
    {
      KeyState2 = readState2;
      if (KeyState2 == 0)
      {
       option++;
       if (option == 4)
       {
        option = 0;
       }



      }
    }
  } //----- end of if-statement  ----


  buttonstate1 = digitalRead(KeyPin1);

  if (buttonstate1 == LOW)
    {
      toggleTemperature = 0;
      toggleHumidity = 0;
    }

  //Option 0 = Temperature
  if (option == 0)
  {
    digitalWrite(ledYellow, HIGH);
    digitalWrite(ledRed, LOW);
    toggleHumidity = 0;
    


    
    if (toggleTemperature == 0)
    {

      Display.clear();
      float resistance   = (float)analogRead(NTC) * 10000 / (1024 - analogRead(NTC));
      float temperature  = 1 / (log(resistance / 10000) /  NTC_MAT_CONSTANT + 1 / 298.15) - 273.15;
      Serial.println("temperatuur = " + String(temperature) + " Celsius");
      Display.show(temperature);
      toggleTemperature++;
      delay(500);
    }
  }

  //option 1 = Humidity
  if (option == 1)
  {
    
    digitalWrite(ledBlue, HIGH);
    digitalWrite(ledYellow, LOW);
    
    
    if (toggleHumidity == 0)
    {
      Display.clear();
      float humidity = DHT11.getHumidity();
      Serial.println("Relatieve vochtigheidsgraad: " + String(humidity) + " % ");
      Display.show(humidity);
      toggleHumidity++;
      delay(500);
    }
    
    

  }

  // option 2 = Lightshow
  if (option == 2)
  {
    
    Display.clear();
    digitalWrite(ledGreen, HIGH);
    digitalWrite(ledBlue, LOW);

    if (buttonstate1 == LOW)
    {
      lightshow();
    }


  }
  if (option == 3)
  {
    digitalWrite(ledRed, HIGH);
    digitalWrite(ledGreen, LOW);
    toggleTemperature = 0;

    

  }


  lastKeyState2 = readState2;
}

void lightshow(void)
{
  digitalWrite(ledYellow, LOW);
  digitalWrite(ledBlue, LOW);
  digitalWrite(ledGreen, LOW);
  digitalWrite(ledRed, LOW);

  delay(250);

  lightPattern1();
  lightPattern2();
  lightPatternAll();
  lightPattern3();
  lightPattern4();
  lightPattern1();
  lightPattern1();
  lightPattern3();
  lightPatternAll();
  lightPattern2();
  lightPattern2();
  lightPattern3();
  lightPattern1();
  lightPattern4();
  lightPatternAll();
  lightPattern4();
  lightPattern3();
  lightPattern2();
  lightPattern1();
  lightPatternAll();
  

  delay(1000);
}

void lightPattern1(void)
{
  digitalWrite(ledYellow, HIGH);
  delay(100);
  digitalWrite(ledYellow, LOW);
  digitalWrite(ledBlue, HIGH);
  delay(100);
  digitalWrite(ledBlue, LOW);
  digitalWrite(ledGreen, HIGH);
  delay(100);
  digitalWrite(ledGreen, LOW);
  digitalWrite(ledRed, HIGH);
  delay(100);
  digitalWrite(ledRed, LOW);
}

void lightPattern2(void)
{
  digitalWrite(ledRed, HIGH);
  delay(100);
  digitalWrite(ledGreen, HIGH);
  digitalWrite(ledRed, LOW);
  delay(100);
  digitalWrite(ledBlue, HIGH);
  digitalWrite(ledGreen, LOW);
  delay(100);
  digitalWrite(ledYellow, HIGH);
  digitalWrite(ledBlue, LOW);
  delay(150);
  digitalWrite(ledYellow, LOW);
}

void lightPattern3(void)
{
  digitalWrite(ledYellow, HIGH);
  digitalWrite(ledRed, HIGH);
  delay(100);
  digitalWrite(ledYellow, LOW);
  digitalWrite(ledRed, LOW);
  digitalWrite(ledBlue, HIGH);
  digitalWrite(ledGreen, HIGH);
  delay(100);
  digitalWrite(ledBlue, LOW);
  digitalWrite(ledGreen, LOW);
}

void lightPattern4(void)
{
  digitalWrite(ledBlue, HIGH);
  digitalWrite(ledGreen, HIGH);
  delay(100);
  digitalWrite(ledBlue, LOW);
  digitalWrite(ledGreen, LOW);
  digitalWrite(ledYellow, HIGH);
  digitalWrite(ledRed, HIGH);
  delay(100);
  digitalWrite(ledYellow, LOW);
  digitalWrite(ledRed, LOW);
}

void lightPatternAll(void)
{
  digitalWrite(ledBlue, HIGH);
  digitalWrite(ledGreen, HIGH);
  digitalWrite(ledYellow, HIGH);
  digitalWrite(ledRed, HIGH);
  delay(100);
  digitalWrite(ledBlue, LOW);
  digitalWrite(ledGreen, LOW);
  digitalWrite(ledYellow, LOW);
  digitalWrite(ledRed, LOW);

}