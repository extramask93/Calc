using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Calculator
{
    
    public class Converter
    {
        public static string Convert(string input, InsModeType from, InsModeType to, WordSizeType word = WordSizeType.QWORD)
        {
            string result = "";
            switch (word)
            {
                case WordSizeType.BYTE:
                    {
                        SByte dec = System.Convert.ToSByte(input, (int)from);
                        result = Converter.SbyteToString((SByte)dec, (int)to);
                        result = result.Substring(2);
                        break;
                    }
                case WordSizeType.WORD:
                    {
                        Int16 dec = System.Convert.ToInt16(input, (int)from);
                        result = System.Convert.ToString(dec, (int)to);
                        break;
                    }
                case WordSizeType.DWORD:
                    {
                        Int32 dec = System.Convert.ToInt32(input, (int)from);
                        result = System.Convert.ToString(dec, (int)to);
                        break;
                    }
                case WordSizeType.QWORD:
                    {
                        Int64 dec = System.Convert.ToInt64(input, (int)from);
                        result = System.Convert.ToString(dec, (int)to);
                        break;
                    }

            }
            return result.ToUpper();
        }
       static string SbyteToString(int by, int bas)
        {
            Stack<string> stack = new Stack<string>();
            while(by != 0)
            {
                string c = (by % bas).ToString();
                by = by / bas;
                stack.Push(c);
            }
            string result = "";
            while(stack.Count>0)
            {
                result += stack.Pop();
            }
            return result;
        }
    }
}
