using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Parser
{
    public abstract class Node
    {
        public abstract Int64 Eval();
    }

    public class NodeNum : Node
    {
        private long _num;

        public NodeNum(Int64 num)
        {
            _num = num;
        }

        public override long Eval()
        {
            return _num;
        }
    }
}
