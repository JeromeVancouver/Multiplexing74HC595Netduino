using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using PHAOneWire;

namespace Multiplexing7Segment
{
    public class Program
    {

        /*
            ledSegC = new OutputPort(Pins.GPIO_PIN_D1, true);
            ledSegE = new OutputPort(Pins.GPIO_PIN_D2, true);
            ledSegD = new OutputPort(Pins.GPIO_PIN_D3, true);
            ledSegDp = new OutputPort(Pins.GPIO_PIN_D4, true);
            ledSegG = new OutputPort(Pins.GPIO_PIN_D5, true);
            ledSegB = new OutputPort(Pins.GPIO_PIN_D6, true);
            ledSegF = new OutputPort(Pins.GPIO_PIN_D7, true);
            ledSegA = new OutputPort(Pins.GPIO_PIN_D8, true);
         */
        


        /*static OutputPort RClock;
        static OutputPort SRClock;
        static OutputPort RClear;
        static OutputPort Data_Pin;*/
        const int SEG_DP = 0;
        const int SEG_C = 1;
        const int SEG_D = 2;
        const int SEG_E = 3;
        const int SEG_B = 4;
        const int SEG_A = 5;
        const int SEG_F = 6;
        const int SEG_G = 7;
                            //PCDEBAFG
        const string SEG_1 = "10110111";
        const string SEG_2 = "11000010";
        const string SEG_3 = "10010010";
        const string SEG_4 = "10110100";
        const string SEG_5 = "10011000";
        const string SEG_6 = "10001000";
        const string SEG_7 = "10110011";
        const string SEG_8 = "10000000";
        const string SEG_9 = "10110000";
        const string SEG_0 = "10000001";
        const string SEG_CLR = "11111111";
        const string SEG_P = "01111111";

        static IC_74HC595_7SEG SegLed1;
        static IC_74HC595_7SEG SegLed2;
        static IC_Chain SegLedChain;


        static void button_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            int i = 0;
            i++;
            /*RClear.Write(false);
            RClear.Write(true);*/
            
        }

        static void DisplayTempurature()
        {
            int temp = 37;
            int digitOne;
            int digitTwo;

            digitOne = temp / 10;
            digitTwo = temp % 10;

            SegLed1.WriteDigit(digitOne);
            SegLed2.WriteSeven();
            SegLedChain.WriteData();
        }

        public static void Main()
        {
            SegLedChain = new IC_Chain(Pins.GPIO_PIN_D0, Pins.GPIO_PIN_D1, Pins.GPIO_PIN_D2, Pins.GPIO_PIN_D3);
            SegLed2 = new IC_74HC595_7SEG(SegLedChain);
            SegLed1 = new IC_74HC595_7SEG(SegLedChain);
            SegLed2.Initialize(5, 4, 2, 1, 0, 6, 7, 3);
            SegLed1.Initialize(6, 7, 2, 1, 0, 5, 4, 3);
            SegLedChain.ClearChain();

            /*RClock = new OutputPort(Pins.GPIO_PIN_D8, true);
            SRClock = new OutputPort(Pins.GPIO_PIN_D9, true);
            Data_Pin = new OutputPort(Pins.GPIO_PIN_D7, true);
            RClear = new OutputPort(Pins.GPIO_PIN_D10, true);*/

           // InterruptPort btBreadBoard = new InterruptPort(Pins.GPIO_PIN_D0, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth);
           // btBreadBoard.OnInterrupt += new NativeEventHandler(button_OnInterrupt);

            //InterruptPort pirFront = new InterruptPort(Pins.GPIO_PIN_D1, false, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeLow);
           // pirFront.OnInterrupt += new NativeEventHandler(button_OnInterrupt);

            while (true)        
            {
                DisplayTempurature();
                Thread.Sleep(500);
            }
                /*
            RClock.Write(false);

            pushPin(8);

            SRClock.Write(false);
            RClock.Write(true);

            Thread.Sleep(1000);*/
            /*while (true)
            {

                RClock.Write(false);


                Data_Pin.Write(true);
                SRClock.Write(true);

                
                //pushPin(4);
                SRClock.Write(false);
                RClock.Write(true);

                Thread.Sleep(5000);
               /* RClock.Write(false);
                //pushData(2);
                pushPin(8);
                SRClock.Write(false);
                RClock.Write(true);
                Thread.Sleep(500);
            }*/


        }

    }
}
