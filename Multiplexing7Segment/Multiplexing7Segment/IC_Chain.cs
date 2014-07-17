using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace Multiplexing7Segment
{

    public class IC_Chain
    {
        static OutputPort RClock;
        static OutputPort SRClock;
        static OutputPort RClear;
        static OutputPort DPin;
        char[] output;
        int chainSize;

        public IC_Chain(Cpu.Pin D_Pin, Cpu.Pin R_Clock, Cpu.Pin SR_Clock, Cpu.Pin R_Clear)
        {
            RClock = new OutputPort(R_Clock, true);
            SRClock = new OutputPort(SR_Clock, true);
            DPin = new OutputPort(D_Pin, true);
            RClear = new OutputPort(R_Clear, false);
            chainSize = 0;
        }

        public int AddIC()
        {
            chainSize++;
            output = new char[8 * chainSize];
            return chainSize-1;
        }

        public void ClearChain()
        {
            for(int i = 0; i < chainSize*8; i++)
                 output[i] = '0';

            RClear.Write(false);
            RClear.Write(true);
        }

        public void Write(char[] outp, int seg)
        {
            int start = seg * 8;
            for (int i = start; i < start+8; i++)
                output[i] = outp[i-start];
        }

        public void WriteData()
        {
            RClock.Write(false);

            for (int segCounter = chainSize-1; segCounter >= 0; segCounter--)
            {
                for (int x = 7; x >= 0; x--)
                {
                    int cnt = segCounter * 8 + x;
                    if (output[cnt] == '0')
                        DPin.Write(false);
                    else
                        DPin.Write(true);

                    SRClock.Write(false);
                    SRClock.Write(true);
                }
            }


            SRClock.Write(false);
            RClock.Write(true);
            RClock.Write(false);
        }


    }
}
