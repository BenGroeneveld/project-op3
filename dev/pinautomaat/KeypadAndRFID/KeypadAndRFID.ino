#include <AddicoreRFID.h>
#include <SPI.h>

//4 bytes tag serial number, the first 5 bytes for the checksum byte
unsigned char serNumA[5];
unsigned char fifobytes;
unsigned char fifoValue;

AddicoreRFID myRFID;

const int chipSelectPin = 10;
const int NRSTPD = 9;
int maxLength = 16;

/*
const int pasBen = 107;
const int pasRemco = 182;
const int pasOsman = 231;
*/

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
      
      if (status == MI_OK)
      {
            Serial.println("RFID tag detected");
            Serial.print(str[0],BIN);
            Serial.print(" , ");
            Serial.print(str[1],BIN);
            Serial.println(" ");
      }
      
      status = myRFID.AddicoreRFID_Anticoll(str);
      
      if (status == MI_OK)
      {
            checksum1 = str[0] ^ str[1] ^ str[2] ^ str[3];
            Serial.println("The tag's number is  : ");
            Serial.print(str[0]);
            Serial.print(" , ");
            Serial.print(str[1]);
            Serial.print(" , ");
            Serial.print(str[2]);
            Serial.print(" , ");
            Serial.print(str[3]);
            Serial.print(" , ");
            Serial.print(str[4]);
            Serial.print(" , ");
            Serial.println(checksum1);

            /*
            if(str[0] == pasBen)
            {
                  Serial.print("Hoi Ben! :D\n");
            }
            else if(str[0] == pasRemco)
            {
                  Serial.print("Hoi Remco! :'D\n");
            }
            else if(str[0] == pasOsman)
            {
                  Serial.print("Hoi Osman! :'D\n");
            }
            */
            Serial.println();
            delay(1000);
      }
      
      myRFID.AddicoreRFID_Halt();
}

