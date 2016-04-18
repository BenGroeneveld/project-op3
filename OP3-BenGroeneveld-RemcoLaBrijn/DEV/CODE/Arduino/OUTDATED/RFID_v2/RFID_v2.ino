#include <AddicoreRFID.h>
#include <SPI.h>

AddicoreRFID myRFID;
const int chipSelectPin = 10;
const int NRSTPD = 9;
int maxLength = 16;

void setup()
{                
      Serial.begin(9600);
      SPI.begin();
      pinMode(chipSelectPin,OUTPUT);
      digitalWrite(chipSelectPin, LOW);
      pinMode(NRSTPD,OUTPUT);
      digitalWrite(NRSTPD, HIGH);
      myRFID.AddicoreRFID_Init();  
}

void loop()
{
      unsigned char i, tmp, checksum1;
      unsigned char status;
      unsigned char str[maxLength];
      unsigned char RC_size;
      unsigned char blockAddr;
      String mynum = "";
      str[1] = 0x4400;

      status = myRFID.AddicoreRFID_Request(PICC_REQIDL, str); 
      status = myRFID.AddicoreRFID_Anticoll(str);
      if(status == MI_OK)
      {
            Serial.print("The tag's ID = ");
            Serial.println(str[0]);
            delay(1000);
      }
      
      myRFID.AddicoreRFID_Halt();
}
