using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public enum WSType
    {
        QWORD =8 ,DWORD = 4, WORD = 2, BYTE = 1
    }
    public enum IMType
    {
        HEX = 16, DEC = 10, OCT = 8, BIN = 2
    }
    public class State
    {
        public IMType Im;
        public WSType Ws;
        public State(IMType ins, WSType ws)
        {
            Im = ins;
            Ws = ws;
        }
    }
}
