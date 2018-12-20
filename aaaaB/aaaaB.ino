
int led1 = 11; int led2=12; int led3=2; int led4=4; int led5=5; int led6=6; int led7=7; int led8=8; int led9=9 ;
int A,B,C,D,E,F,G,H,I,X=0;

void setup() {             
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  pinMode(led3, OUTPUT);
  pinMode(led4, OUTPUT);
  pinMode(led5, OUTPUT);
  pinMode(led6, OUTPUT);
  pinMode(led7, OUTPUT);
  pinMode(led8, OUTPUT);
  pinMode(led9, OUTPUT);
  Serial.begin(9600); 


      digitalWrite(led1, LOW);
      digitalWrite(led2, LOW);
      digitalWrite(led3, LOW);
      digitalWrite(led4, LOW);
      digitalWrite(led5, LOW);
      digitalWrite(led6, LOW);
      digitalWrite(led7, LOW);
      digitalWrite(led8, LOW);
      digitalWrite(led9, LOW);
}
void loop() {
  if(Serial.available()){
    X=Serial.read();
    if(X=='A'){
      digitalWrite(led1, HIGH);
      digitalWrite(led2, LOW);
      digitalWrite(led3, LOW);
      digitalWrite(led4, LOW);
      digitalWrite(led5, LOW);
      digitalWrite(led6, LOW);
      digitalWrite(led7, LOW);
      digitalWrite(led8, LOW);
      digitalWrite(led9, LOW);
    }
    if(X=='B'){
       digitalWrite(led2, HIGH);
      digitalWrite(led1, LOW);
      digitalWrite(led3, LOW);
      digitalWrite(led4, LOW);
      digitalWrite(led5, LOW);
      digitalWrite(led6, LOW);
      digitalWrite(led7, LOW);
      digitalWrite(led8, LOW);
      digitalWrite(led9, LOW);
    }
    if(X=='C'){
    digitalWrite(led3, HIGH);
      digitalWrite(led2, LOW);
      digitalWrite(led1, LOW);
      digitalWrite(led4, LOW);
      digitalWrite(led5, LOW);
      digitalWrite(led6, LOW);
      digitalWrite(led7, LOW);
      digitalWrite(led8, LOW);
      digitalWrite(led9, LOW);
      
    }
    if(X=='D'){
      digitalWrite(led4, HIGH);
      digitalWrite(led2, LOW);
      digitalWrite(led3, LOW);
      digitalWrite(led1, LOW);
      digitalWrite(led5, LOW);
      digitalWrite(led6, LOW);
      digitalWrite(led7, LOW);
      digitalWrite(led8, LOW);
      digitalWrite(led9, LOW);
    }
    if(X=='E'){
    digitalWrite(led5, HIGH);
      digitalWrite(led2, LOW);
      digitalWrite(led3, LOW);
      digitalWrite(led4, LOW);
      digitalWrite(led1, LOW);
      digitalWrite(led6, LOW);
      digitalWrite(led7, LOW);
      digitalWrite(led8, LOW);
      digitalWrite(led9, LOW);
    }
    if(X=='F'){
     digitalWrite(led6, HIGH);
      digitalWrite(led2, LOW);
      digitalWrite(led3, LOW);
      digitalWrite(led4, LOW);
      digitalWrite(led5, LOW);
      digitalWrite(led1, LOW);
      digitalWrite(led7, LOW);
      digitalWrite(led8, LOW);
      digitalWrite(led9, LOW);
    }
    if(X=='G'){
        digitalWrite(led7, HIGH);
      digitalWrite(led2, LOW);
      digitalWrite(led3, LOW);
      digitalWrite(led4, LOW);
      digitalWrite(led5, LOW);
      digitalWrite(led6, LOW);
      digitalWrite(led1, LOW);
      digitalWrite(led8, LOW);
      digitalWrite(led9, LOW);
    }
    if(X=='H'){
      digitalWrite(led8, HIGH);
      digitalWrite(led2, LOW);
      digitalWrite(led3, LOW);
      digitalWrite(led4, LOW);
      digitalWrite(led5, LOW);
      digitalWrite(led6, LOW);
      digitalWrite(led7, LOW);
      digitalWrite(led1, LOW);
      digitalWrite(led9, LOW);
    }
    if(X=='I'){
     digitalWrite(led9, HIGH);
      digitalWrite(led2, LOW);
      digitalWrite(led3, LOW);
      digitalWrite(led4, LOW);
      digitalWrite(led5, LOW);
      digitalWrite(led6, LOW);
      digitalWrite(led7, LOW);
      digitalWrite(led8, LOW);
      digitalWrite(led1, LOW);
    }
 }
}
