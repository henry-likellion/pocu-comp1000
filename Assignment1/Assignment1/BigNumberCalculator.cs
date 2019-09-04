using System;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        public BigNumberCalculator(int bitCount, EMode mode)
        {
        }

        public static string GetOnesComplement(string num)
        {

            if (num == "0b")
            {
                return null;
            }

            if (!num.StartsWith("0b"))
            {
                return null;
            }

            for (int i = 2; i < num.Length; ++i)
            {
                if (num[i] == '0')
                {
                    num = num.Remove(i, 1).Insert(i, "1");
                }
                else if (num[i] == '1')
                {
                    num = num.Remove(i, 1).Insert(i, "0");
                }
                else
                {
                    return null;
                }
            }

            return num;
        }

        public static string GetTwosComplement(string num)
        {
            if (num == "0b")
            {
                return null;
            }

            if (!num.StartsWith("0b"))
            {
                return null;
            }

            bool bWasCarryOver = false;

            for (int i = num.Length - 1; i > 1; --i)
            {
                if (bWasCarryOver)
                {
                    if (num[i] == '0')
                    {
                        num = num.Remove(i, 1).Insert(i, "1");
                    }
                    else if (num[i] == '1')
                    {
                        num = num.Remove(i, 1).Insert(i, "0");
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (num[i] == '1')
                    {
                        bWasCarryOver = true;
                    }
                    else if (num[i] != '0')
                    {
                        return null;
                    }
                }
            }

            return num;
        }

        public static string ToBinary(string num)
        {
            if (num == "0b" || num == "0x")
            {
                return null;
            }

            if (num.StartsWith("0b"))
            {
                return num;
            }

            if (num.StartsWith("0x"))
            {
                num = num.Remove(0, 2);
                string NumHexToBinary = "0b";

                for (int i = 0; i < num.Length; ++i)
                {
                    if (num[i] == '0')
                    {
                        NumHexToBinary += "0000";
                    }
                    else if (num[i] == '1')
                    {
                        NumHexToBinary += "0001";
                    }
                    else if (num[i] == '2')
                    {
                        NumHexToBinary += "0010";
                    }
                    else if (num[i] == '3')
                    {
                        NumHexToBinary += "0011";
                    }
                    else if (num[i] == '4')
                    {
                        NumHexToBinary += "0100";
                    }
                    else if (num[i] == '5')
                    {
                        NumHexToBinary += "0101";
                    }
                    else if (num[i] == '6')
                    {
                        NumHexToBinary += "0110";
                    }
                    else if (num[i] == '7')
                    {
                        NumHexToBinary += "0111";
                    }
                    else if (num[i] == '8')
                    {
                        NumHexToBinary += "1000";
                    }
                    else if (num[i] == '9')
                    {
                        NumHexToBinary += "1001";
                    }
                    else if (num[i] == 'A')
                    {
                        NumHexToBinary += "1010";
                    }
                    else if (num[i] == 'B')
                    {
                        NumHexToBinary += "1011";
                    }
                    else if (num[i] == 'C')
                    {
                        NumHexToBinary += "1100";
                    }
                    else if (num[i] == 'D')
                    {
                        NumHexToBinary += "1101";
                    }
                    else if (num[i] == 'E')
                    {
                        NumHexToBinary += "1110";
                    }
                    else if (num[i] == 'F')
                    {
                        NumHexToBinary += "1111";
                    }
                    else
                    {
                        return null;
                    }
                }
                return NumHexToBinary;
            }

            if (int.TryParse(num, out int decimalNum))
            {
                string NumDecimalToBinary = "0b";

                if (decimalNum < 0)
                {
                    NumDecimalToBinary += "1";
                    decimalNum *= -1;
                }
                else
                {
                    NumDecimalToBinary += "0";
                }

                while(decimalNum != 0)
                {
                    if (decimalNum == 2)
                    {
                        NumDecimalToBinary = NumDecimalToBinary.Insert(3, "1");
                        decimalNum = 0;
                    }
                    else
                    {
                        int remainder = decimalNum % 2;
                        NumDecimalToBinary = NumDecimalToBinary.Insert(3, remainder.ToString());
                        decimalNum /= 2;
                    }
                }

                return NumDecimalToBinary;
            }

            return null;
        }

        public static string ToHex(string num)
        {
            return null;
        }

        public static string ToDecimal(string num)
        {
            return null;
        }

        public string AddOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            return null;
        }
    }
}