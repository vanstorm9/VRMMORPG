#include <Wire.h>
#include <Adafruit_MotorShield.h>
#include "utility/Adafruit_PWMServoDriver.h"

Adafruit_MotorShield AFMSbot(0x61); // Rightmost jumper closed

// And a DC Motor to port M1
Adafruit_DCMotor *myMotor1 = AFMSbot.getMotor(1);

int i;
int val = 0;
int ledPin = 13;
char byte_val;

void setup() {
  while (!Serial);
  Serial.begin(9600);           // set up Serial library at 9600 bps
  Serial.println("MMMMotor party!");

  AFMSbot.begin(); // Start the bottom shield
   
  // turn on the DC motor
  myMotor1->setSpeed(250);
  
  pinMode(ledPin, OUTPUT);
  
}




void loop() {
  
  digitalWrite(ledPin, HIGH);

  byte_val = Serial.read();
  
  if(byte_val == '1')
  {
    
    
    //Start motor movement -- 
     myMotor1->run(FORWARD);
     
    /*
     for (i=0; i<255; i++) {
      myMotor1->setSpeed(i);  
  
      delay(3);
     }
   
     for (i=255; i!=0; i--) {
       myMotor1->setSpeed(i);  
  
       delay(3);
     }
     */
    //End motor movement --
    
    
    //val = Serial.read();

    
    //Serial.println(":D  :D  :D");
    //Serial.println(val);
  } else if (byte_val == '0'){
    myMotor1->run(RELEASE);
    val = 0;
    //Serial.println("Nope");
    //Serial.println(val);
  } 
  
  
  
}
