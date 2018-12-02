using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Calculator
{
    public class Calculator
    {
        
        public string ScreenBuffer { get => _screenBuffer; set => _screenBuffer = value; }
        public State State { get => _state; set => _state = value; }

        public void ParseInput(string v)
        {
            ScreenBuffer = v;
        }
        public Calculator()
        {
            _screenBuffer = "0";
            State = new State(InsModeType.DEC, WordSizeType.QWORD);
        }
        ///
        string _screenBuffer;
        State _state;

        
    }
}
