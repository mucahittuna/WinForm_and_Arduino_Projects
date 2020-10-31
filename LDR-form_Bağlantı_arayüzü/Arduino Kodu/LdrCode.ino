#define led 3


void setup() 
{
  pinMode(led,OUTPUT);
  Serial.begin(9600);
}

void loop() 
{
 int sensor=analogRead(A0);
 Serial.println(sensor);
 delay(50);
if(sensor<100)
{
 digitalWrite(led,HIGH);
}
else
digitalWrite(led,LOW);
}
