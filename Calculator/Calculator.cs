using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Calc
{
    public class Calculator
    {
        
        public string ScreenBuffer { get; set; }

        public State State { get; set; }

        public void ParseInput(string v)
        {
            ScreenBuffer = v;
        }
        public Calculator()
        {
            ScreenBuffer = "0";
            State = new State(IMType.DEC, WSType.QWORD);
        }
    }
}
