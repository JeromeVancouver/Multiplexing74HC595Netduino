using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace Multiplexing7Segment
{
    public class IC_74HC595_7SEG:IC_74HC595
    {
        int SEG_DP = 0;
        int SEG_C = 1;
        int SEG_D = 2;
        int SEG_E = 3;
        int SEG_B = 4;
        int SEG_A = 5;
        int SEG_F = 6;
        int SEG_G = 7;

        public IC_74HC595_7SEG(Cpu.Pin D_Pin, Cpu.Pin R_Clock, Cpu.Pin SR_Clock, Cpu.Pin R_Clear)
        {
            RClock = new OutputPort(R_Clock, true);
            SRClock = new OutputPort(SR_Clock, true);
            DPin = new OutputPort(D_Pin, true);
            RClear = new OutputPort(R_Clear, false);
            output = new char[8];
            ClearOutput();
        }

        public IC_74HC595_7SEG(IC_Chain ic_Chain)
        {
            ICChain = ic_Chain;
            icSeg = ICChain.AddIC();
            output = new char[8];
            ClearOutput();
        }

        public void WriteSegment(int segNum)
        {
            output[segNum] = '0';
        }

        public void WriteDigit(int digit)
        {
            switch (digit)
            {
                case 1:
                    WriteOne();
                    break;
                case 2:
                    WriteTwo();
                    break;
                case 3:
                    WriteThree();
                    break;
                case 4:
                    WriteFour();
                    break;
                case 5:
                    WriteFive();
                    break;
                case 6:
                    WriteSix();
                    break;
                case 7:
                    WriteSeven();
                    break;
                case 8:
                    WriteEight();
                    break;
                case 9:
                    WriteNine();
                    break;
                case 0:
                    WriteZero();
                    break;
            }
        }

        public void WriteOne()
        {
            ClearOutput();
            WriteSegment(SEG_B);
            WriteSegment(SEG_C);
            WriteToChain();
        }

        public void WriteTwo()
        {
            ClearOutput();
            WriteSegment(SEG_B);
            WriteSegment(SEG_A);
            WriteSegment(SEG_D);
            WriteSegment(SEG_E);
            WriteSegment(SEG_G);
            WriteToChain();
        }

        public void WriteThree()
        {
            ClearOutput();
            WriteSegment(SEG_B);
            WriteSegment(SEG_A);
            WriteSegment(SEG_D);
            WriteSegment(SEG_C);
            WriteSegment(SEG_G);
            WriteToChain();
        }

        public void WriteFour()
        {
            ClearOutput();
            WriteSegment(SEG_F);
            WriteSegment(SEG_G);
            WriteSegment(SEG_B);
            WriteSegment(SEG_C);
            WriteToChain();
        }

        public void WriteFive()
        {
            ClearOutput();
            WriteSegment(SEG_A);
            WriteSegment(SEG_F);
            WriteSegment(SEG_G);
            WriteSegment(SEG_C);
            WriteSegment(SEG_D);
            WriteToChain();
        }

        public void WriteSix()
        {
            ClearOutput();
            WriteSegment(SEG_C);
            WriteSegment(SEG_D);
            WriteSegment(SEG_E);
            WriteSegment(SEG_F);
            WriteSegment(SEG_G);
            WriteToChain();
        }

        public void WriteSeven()
        {
            ClearOutput();
            WriteSegment(SEG_A);
            WriteSegment(SEG_B);
            WriteSegment(SEG_C);
            WriteToChain();
        }

        public void WriteEight()
        {
            ClearOutput();
            WriteSegment(SEG_A);
            WriteSegment(SEG_B);
            WriteSegment(SEG_C);
            WriteSegment(SEG_D);
            WriteSegment(SEG_E);
            WriteSegment(SEG_F);
            WriteSegment(SEG_G);
            WriteToChain();
        }


        public void WriteNine()
        {
            ClearOutput();
            WriteSegment(SEG_A);
            WriteSegment(SEG_B);
            WriteSegment(SEG_C);
            WriteSegment(SEG_F);
            WriteSegment(SEG_G);
            WriteToChain();
        }

        public void WriteZero()
        {
            ClearOutput();
            WriteSegment(SEG_A);
            WriteSegment(SEG_B);
            WriteSegment(SEG_C);
            WriteSegment(SEG_D);
            WriteSegment(SEG_E);
            WriteSegment(SEG_F);
            WriteToChain();
        }

        public void Initialize(int sA, int sB, int sC, int sD, int sE, int sF, int sG, int sDP)
        {
            SEG_A = sA;
            SEG_B = sB;
            SEG_C = sC;
            SEG_D = sD;
            SEG_E = sE;
            SEG_F = sF;
            SEG_G = sG;
            SEG_DP = sDP;
            //output = "11111111";
        }
    }
}
