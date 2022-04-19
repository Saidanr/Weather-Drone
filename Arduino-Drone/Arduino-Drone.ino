#include <Adafruit_Sensor.h>
#include <DHT.h>
#include <DHT_U.h>
#define DHTPIN 8
#define DHTTYPE DHT11

// Define Variables
float hum; // Stores humidity value in percent
float temp; // Stores temperature value in Celsius

int ledPin6 = 6;
int ledPin5 = 5;
int ledPin7 = 7;
int ledPin4 = 4;

int LDRPin = A0;
int lightVal = 0;
float x = 0.0;
float r1 = 0.0;
float lux = 0.0;

const int flamePin = 11;
int Flame = HIGH;

DHT dht(DHTPIN, DHTTYPE);

void setup() {

Serial.begin(9600);
dht.begin();
pinMode(flamePin, INPUT);
pinMode(ledPin4, OUTPUT);
pinMode(ledPin5, OUTPUT);
pinMode(ledPin6, OUTPUT);
pinMode(ledPin7, OUTPUT);
 


}
void loop()
{
hum = dht.readHumidity(); // Get Humidity value
temp= dht.readTemperature(); // Get Temperature value
temp = temp*1.8+32;

lightVal = analogRead(LDRPin);
x = map(lightVal,0,1023,1,5);
r1 = 1*((5/x)- 1);
lux = 631*pow(r1,-1.25);

Flame = digitalRead(flamePin);
if(Flame == LOW)
{
  //Serial.print("Flame: ");
  Serial.print("Yes!");
  Serial.print(",");
}
else
{
  //Serial.print("Flame: ");
  Serial.print("No!");
  Serial.print(",");
}
//Serial.print("Lux: ");
Serial.print(lux);
Serial.print(",");

//Serial.print("Humidity: ");
Serial.print(hum);
Serial.print(",");
//Serial.print("Temp: ");
Serial.print(temp);

Serial.println("");

digitalWrite(ledPin4, HIGH);
digitalWrite(ledPin5, HIGH);
digitalWrite(ledPin6, HIGH);
digitalWrite(ledPin7, HIGH);
delay(200);
digitalWrite(ledPin4, LOW);
digitalWrite(ledPin5, LOW);
digitalWrite(ledPin6, LOW);
digitalWrite(ledPin7, LOW);
delay(500);
}
