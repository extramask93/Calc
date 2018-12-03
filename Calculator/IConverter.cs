using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Calc
{
    
    public class Converter
    {
        public static string Convert(string input, IMType from, IMType to, WSType word = WSType.QWORD)
        {
            string result = "";
            switch (word)
            {
                case WSType.BYTE:
                    {
                        SByte dec = System.Convert.ToSByte(input, (int)from);
                        result = Converter.SbyteToString((SByte)dec, (int)to);
                        result = result.Substring(2);
                        break;
                    }
                case WSType.WORD:
                    {
                        Int16 dec = System.Convert.ToInt16(input, (int)from);
                        result = System.Convert.ToString(dec, (int)to);
                        break;
                    }
                case WSType.DWORD:
                    {
                        Int32 dec = System.Convert.ToInt32(input, (int)from);
                        result = System.Convert.ToString(dec, (int)to);
                        break;
                    }
                case WSType.QWORD:
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
