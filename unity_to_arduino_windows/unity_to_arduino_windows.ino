int i;
int val = 0;
int ledPin = 13;
char byte_val;

int motorPin = 3;

void setup() {
  pinMode(motorPin, OUTPUT);
  Serial.begin(9600);
  
}




void loop() {
  
  int speed = 254;
  int sword_strike_feed_delay = 500;
  int sword_touch_feed_delay = 50;

  byte_val = Serial.read();
  
  if(byte_val == '1')
  {
        analogWrite(motorPin, speed);
        //delay(sword_strike_feed_delay);
        delay(sword_touch_feed_delay);  
         analogWrite(motorPin, 0);

  } else if (byte_val == '0'){

     analogWrite(motorPin, 0);

  } 
  
  
  
}
