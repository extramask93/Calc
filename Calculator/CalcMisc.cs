using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum WordSizeType
    {
        QWORD =8 ,DWORD = 4, WORD = 2, BYTE = 1
    }
    public enum InsModeType
    {
        HEX = 16, DEC = 10, OCT = 8, BIN = 2
    }
    public class State
    {
        public InsModeType InsMode;
        public WordSizeType WordSize;
        public State(InsModeType ins, WordSizeType wordSize)
        {
            InsMode = ins;
            WordSize = wordSize;
        }
    }
}
