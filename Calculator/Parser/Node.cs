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
    public class NodeBinary : Node
    {
        private Node _lhs;
        private Node _rhs;
        private Func<long, long, long> _op;

        public NodeBinary(Node lhs, Node rhs, Func<Int64, Int64, Int64> op)
        {
            _lhs = lhs;
            _rhs = rhs;
            _op = op;
        }
        public override long Eval()
        {
            var lhsVal = _lhs.Eval();
            var rhsVal = _rhs.Eval();
            var result = _op(lhsVal, rhsVal);
            return result;
        }
    }
    public class NodeUnary : Node
    {
        private Node _rhs;
        private Func<long, long> _op;

        public NodeUnary(Node rhs, Func<long,long> op)
        {
            _rhs = rhs;
            _op = op;
        }
        public override long Eval()
        {
            var rhsVal = _rhs.Eval();
            var result = _op(rhsVal);
            return result;
        }
    }
}
