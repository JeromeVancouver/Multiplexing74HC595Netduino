using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace Multiplexing7Segment
{
    public class IC_74HC595
    {
        public OutputPort RClock;
        public OutputPort SRClock;
        public OutputPort RClear;
        public OutputPort DPin;
        public IC_Chain ICChain;
        public int icSeg;
        public char[] output;

        public IC_74HC595()
        {
        }

        public IC_74HC595(Cpu.Pin D_Pin, Cpu.Pin R_Clock, Cpu.Pin SR_Clock, Cpu.Pin R_Clear)
        {

            RClock = new OutputPort(R_Clock, true);
            SRClock = new OutputPort(SR_Clock, true);
            DPin = new OutputPort(D_Pin, true);
            RClear = new OutputPort(R_Clear, false);
            output = new char[8];
            ClearOutput();
        }


        public IC_74HC595(IC_Chain ic_Chain)
        {
            ICChain = ic_Chain;
            icSeg = ICChain.AddIC();
            output = new char[8];
            ClearOutput();
        }

        public void ClearOutput()
        {
            for (int i = 0; i < 8; i++)
                output[i] = '1';
        }


        public void WriteToChain()
        {
            ICChain.Write(output, icSeg);
        }

        public void Write(String outp)
        {
            output = outp.ToCharArray(0, 8);
            WriteToChain();
        }

    }
}
