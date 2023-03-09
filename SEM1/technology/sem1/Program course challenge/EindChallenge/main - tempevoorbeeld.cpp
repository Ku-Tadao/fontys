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
const int Potmeter = 14;
const int NTC = A1;
const int LDRPIN = 16;
int teller = 0;
int OFFSET = 0;
int index = 0;
int index2 = 0;
int KeyState1;
int KeyState2;
int lastKeyState1 = HIGH; // previous state of button1
int lastKeyState2 = HIGH; // previous state of button2
bool togglekey1 = LOW;
bool togglekey2 = LOW;
bool toggleled = LOW;
unsigned long timeelapsed;
unsigned long DebounceTimeKey1 = 0; // the last time the output pin was toggled
unsigned long DebounceTimeKey2 = 0; // the last time the output pin was toggled
unsigned long prevmeasureTime = 0;
unsigned long previousTime = 0;
unsigned long prevHLightsTime = 0;


unsigned long prev_millis =0;
unsigned long curr_millis =0;
const int MEAS_UPDATEFREQ = 5000;
const int SERIAL_SEND_INTERVAL = 5000;
const int DEBOUNCEDELAY = 50;
const int MAXLEFT = -120; //
const int MAXRIGHT = 120; //
const int NTC_MAT_CONSTANT = 3950;
//====
// Functie prototypen
void ClearLeds(void);
//==

void setup()
{
  // put your setup code here, to run once:
  pinMode(LDRPIN, INPUT);
  pinMode(Potmeter, INPUT);
  pinMode(NTC,INPUT);
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
  // instelling voor serieele communicatie
  Serial.println(Serial.getTimeout());
  Serial.setTimeout(10000); // Timeout serieele verbining verlengen
}

void loop()
{
//  Serial Comando 

///============NON BLOCKING DELAY of 5 seconds ===========================
curr_millis = millis();
 if (curr_millis - prev_millis > SERIAL_SEND_INTERVAL) {
   toggleled =!toggleled;
   digitalWrite(ledYellow,toggleled);
   
    float resistance   = (float)analogRead(NTC) * 10000 / (1024 - analogRead(NTC));
    float temperature  = 1 / (log(resistance / 10000) /  NTC_MAT_CONSTANT + 1 / 298.15) - 273.15;
    if (toggleled) {
      float temp = DHT11.getTemperature();
       Serial.println("DHT temperature = "+String(temp)+" degrees");
       float humid = DHT11.getHumidity();
      Serial.println("Humidity = "+String(humid)+" %");
       Display.show(temp);
    }else{
       Serial.println("NTC temperature = " +String(temperature));
        Display.show(temperature);
    }

   
   
    prev_millis = curr_millis;
  }




//=====================================
  // Handling key 1
  int readState2 = digitalRead(KeyPin2);
  if (readState2 != lastKeyState2)
  {
    // reset the debouncing timer
    DebounceTimeKey2 = millis();
  }
  if ((millis() - DebounceTimeKey2) > DEBOUNCEDELAY)
  {
    if (readState2 != KeyState2)
    {
      KeyState2 = readState2;
      if (KeyState2 == 0)
      {
        ClearLeds(); // Eigen functie
        index = teller % 3;
        teller++;
        if (teller > 1000)
       {
          teller = 0;
        }
        digitalWrite(ledRed+ index, HIGH);
      }
    }
  } //----- end of if-statement  ----
  lastKeyState2 = readState2;
  
}
//====

// End of loop function

// Mijn eigen function
void ClearLeds(void)
{
  int i = 0;
  for (i = 0; i < 3; i++)
  {
    digitalWrite(ledRed + i, LOW);
  }
}
