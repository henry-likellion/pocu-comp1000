using System;

namespace Assignment1
{
    public class BigNumberCalculator
    {
        private int BitCount { get; }
        private EMode Mode { get; }
        public BigNumberCalculator(int bitCount, EMode mode)
        {
            BitCount = bitCount;
            Mode = mode;
        }

        public static string GetOnesComplement(string num)
        {
            if (!num.StartsWith("0b"))
            {
                return null;
            }

            if (!IsValidBinary(num))
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
            }

            return num;
        }

        public static string GetTwosComplement(string num)
        {
            if (!num.StartsWith("0b"))
            {
                return null;
            }

            if (!IsValidBinary(num))
            {
                return null;
            }

            bool bCarryover = false;

            for (int i = num.Length - 1; i > 1; --i)
            {
                if (bCarryover)
                {
                    if (num[i] == '0')
                    {
                        num = num.Remove(i, 1).Insert(i, "1");
                    }
                    else if (num[i] == '1')
                    {
                        num = num.Remove(i, 1).Insert(i, "0");
                    }
                }
                else
                {
                    if (num[i] == '1')
                    {
                        bCarryover = true;
                    }
                }
            }

            return num;
        }

        public static string ToBinary(string num)
        {
            if (num.StartsWith("0b"))
            {
                if (!IsValidBinary(num))
                {
                    return null; 
                }

                return num;
            }

            if (num.StartsWith("0x"))
            {
                if (!IsValidHex(num))
                {
                    return null;
                }

                num = num.Remove(0, 2);
                string numHexToBinary = "0b";

                for (int i = 0; i < num.Length; ++i)
                {
                    if (num[i] == '0')
                    {
                        numHexToBinary += "0000";
                    }
                    else if (num[i] == '1')
                    {
                        numHexToBinary += "0001";
                    }
                    else if (num[i] == '2')
                    {
                        numHexToBinary += "0010";
                    }
                    else if (num[i] == '3')
                    {
                        numHexToBinary += "0011";
                    }
                    else if (num[i] == '4')
                    {
                        numHexToBinary += "0100";
                    }
                    else if (num[i] == '5')
                    {
                        numHexToBinary += "0101";
                    }
                    else if (num[i] == '6')
                    {
                        numHexToBinary += "0110";
                    }
                    else if (num[i] == '7')
                    {
                        numHexToBinary += "0111";
                    }
                    else if (num[i] == '8')
                    {
                        numHexToBinary += "1000";
                    }
                    else if (num[i] == '9')
                    {
                        numHexToBinary += "1001";
                    }
                    else if (num[i] == 'A')
                    {
                        numHexToBinary += "1010";
                    }
                    else if (num[i] == 'B')
                    {
                        numHexToBinary += "1011";
                    }
                    else if (num[i] == 'C')
                    {
                        numHexToBinary += "1100";
                    }
                    else if (num[i] == 'D')
                    {
                        numHexToBinary += "1101";
                    }
                    else if (num[i] == 'E')
                    {
                        numHexToBinary += "1110";
                    }
                    else if (num[i] == 'F')
                    {
                        numHexToBinary += "1111";
                    }
                }
                return numHexToBinary;
            }

            if (IsValidDecimal(num))
            {
                if (num == "0")
                {
                    return "0b0";
                }

                string numDecimalToBinary = "0b";
                string quotient = num;
                bool bIsNegative = false;

                if (num[0] == '-')
                {
                    bIsNegative = true;
                    quotient = quotient.Remove(0, 1);
                }

                while (quotient != "")
                {
                    int numberOfDigits = quotient.Length;

                    int numberLastDigit = int.Parse(quotient[numberOfDigits - 1].ToString());

                    if (numberLastDigit % 2 == 0)
                    {
                        numDecimalToBinary = numDecimalToBinary.Insert(2, "0");
                    }
                    else
                    {
                        numDecimalToBinary = numDecimalToBinary.Insert(2, "1");
                    }
                    quotient = GetQuotientDividedByTwo(quotient);
                }

                if (bIsNegative)
                {
                    numDecimalToBinary = GetTwosComplement(numDecimalToBinary);
                    numDecimalToBinary = numDecimalToBinary.Insert(2, "1");
                }
                else
                {
                    numDecimalToBinary = numDecimalToBinary.Insert(2, "0");
                }

                return numDecimalToBinary;
            }

            return null;
        }

        public static string ToHex(string num)
        {
            if (num.StartsWith("0x"))
            {
                if (!IsValidHex(num))
                {
                    return null;
                }

                return num;
            }

            if (num.StartsWith("0b"))
            {
                if (!IsValidBinary(num))
                {
                    return null;
                }

                string numberBinaryToHex = FromBinaryToHex(num);

                return numberBinaryToHex;
            }

            string numDecimalToBinary = ToBinary(num);

            if (numDecimalToBinary == null)
            {
                return null;
            }
            else
            {
                string numberBinaryToHex = FromBinaryToHex(numDecimalToBinary);

                return numberBinaryToHex;
            }
        }

        public static string ToDecimal(string num)
        {
            if (num.StartsWith("0x"))
            {
                string numberHexToBinary = ToBinary(num);

                if (numberHexToBinary == null)
                {
                    return null;
                }

                string numberBinaryToDecimal = GetDecimalFromBinary(numberHexToBinary);

                return numberBinaryToDecimal;
            }

            if (num.StartsWith("0b"))
            {
                if (!IsValidBinary(num))
                {
                    return null;
                }

                string numberBinaryToDecimal = GetDecimalFromBinary(num);

                return numberBinaryToDecimal;
            }

            if (IsValidDecimal(num))
            {
                return num;
            }

            return null;
        }

        public string AddOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;
            // check validity of input numbers
            if (!IsValidNumber(num1) && !IsValidNumber(num2))
            {
                return null;
            }

            // if both numbers pass the validity test,
            // check bit validity.

            string num1Binary = ToBinary(num1);
            string num2Binary = ToBinary(num2);

            if (num1Binary.Length - 2 > BitCount || num2Binary.Length - 2 > BitCount)
            {
                return null;
            }

            // start adding numbers
            string num1Decimal = ToDecimal(num1);
            string num2Decimal = ToDecimal(num2);

            string maxAbsValueGivenBit = GetMaxAbsDecimalGivenBit(BitCount);
            string rangeGivenBit = MultiplyByTwo(maxAbsValueGivenBit);
            string maxValueGivenBit = SubtractTwoDecimalNumbers(maxAbsValueGivenBit, "1");

            string sum;

            // num1 & num1 both positive, both negative, one negative

            if (num1Decimal[0] != '-' && num2Decimal[0] != '-')
            {
                if (num1Decimal.Length >= num2Decimal.Length)
                {
                    sum = AddTwoDecimalNumbers(num1Decimal, num2Decimal);
                }
                else
                {
                    sum = AddTwoDecimalNumbers(num2Decimal, num1Decimal);
                }
            }
            else if (num1Decimal[0] == '-' && num2Decimal[0] == '-')
            {
                num1Decimal = num1Decimal.Remove(0, 1);
                num2Decimal = num2Decimal.Remove(0, 1);

                if (num1Decimal.Length >= num2Decimal.Length)
                {
                    sum = AddTwoDecimalNumbers(num1Decimal, num2Decimal);
                }
                else
                {
                    sum = AddTwoDecimalNumbers(num2Decimal, num1Decimal);
                }

                sum = sum.Insert(0, "-");
            }
            else
            {
                if (num1Decimal[0] == '-')
                {
                    string temp = num1Decimal;
                    num1Decimal = num2Decimal;
                    num2Decimal = temp;
                }

                num2Decimal = num2Decimal.Remove(0, 1);

                string biggerNumber = GetLargerNumber(num1Decimal, num2Decimal);

                if (biggerNumber == num1Decimal)
                {
                    sum = SubtractTwoDecimalNumbers(num1Decimal, num2Decimal);
                }
                else
                {
                    sum = SubtractTwoDecimalNumbers(num2Decimal, num1Decimal);
                    sum = sum.Insert(0, "-");
                }
            }
            
            // If the sum is positive, check overflow

            if (sum[0] != '-')
            {
                string biggerNumber = GetLargerNumber(maxValueGivenBit, sum);

                if (maxValueGivenBit != biggerNumber && biggerNumber == sum)
                {
                    bOverflow = true;
                    sum = SubtractTwoDecimalNumbers(rangeGivenBit, sum);
                    sum = sum.Insert(0, "-");
                }
            }
            else
            {
                sum = sum.Remove(0, 1);

                string biggerNumber = GetLargerNumber(maxAbsValueGivenBit, sum);
                
                if (maxAbsValueGivenBit != biggerNumber && biggerNumber == sum)
                {
                    bOverflow = true;
                    sum = SubtractTwoDecimalNumbers(rangeGivenBit, sum);
                }
                else
                {
                    sum = sum.Insert(0, "-");
                }
            }

            if (Mode == EMode.Binary)
            {
                sum = ToBinary(sum);
                int differenceBits = BitCount - (sum.Length - 2);

                for (int i = 0; i < differenceBits; ++i)
                {
                    if (sum[2] == '1')
                    {
                        sum = sum.Insert(2, "1");
                    }
                    else
                    {
                        sum = sum.Insert(2, "0");
                    }
                }
            }

            return sum;
        }

        public string SubtractOrNull(string num1, string num2, out bool bOverflow)
        {
            bOverflow = false;

            // check validity of input numbers
            if (!IsValidNumber(num1) && !IsValidNumber(num2))
            {
                return null;
            }

            // if both numbers pass the validity test,
            // check bit validity.

            string num1Binary = ToBinary(num1);
            string num2Binary = ToBinary(num2);

            if (num1Binary.Length - 2 > BitCount || num2Binary.Length - 2 > BitCount)
            {
                return null;
            }

            // start subtracting numbers
            string num1Decimal = ToDecimal(num1);
            string num2Decimal = ToDecimal(num2);

            if (num2Decimal[0] == '-')
            {
                num2Decimal = num2Decimal.Remove(0, 1);
            }
            else
            {
                num2Decimal = num2Decimal.Insert(0, "-");
            }

            string difference = AddOrNull(num1Decimal, num2Decimal, out bOverflow);

            return difference;
        }

        public static string GetMaxAbsDecimalGivenBit(int bit)
        {
            string result = "1";

            for (int i = 1; i < bit; ++i)
            {
                result = MultiplyByTwo(result);
            }

            return result;
        }
        public static bool IsValidDecimal(string num)
        {
            char firstCharacter = num[0];
            char firstNumber;

            if (num == "0")
            {
                return true;
            }

            if (num == "-")
            {
                return false;
            }

            if (firstCharacter == '-')
            {
                firstNumber = num[1];
                num = num.Remove(0, 1);
            }
            else
            {
                firstNumber = firstCharacter;
            }

            if (firstNumber == '1' || firstNumber == '2' || firstNumber == '3' || firstNumber == '4' || firstNumber == '5' || firstNumber == '6' || firstNumber == '7' || firstNumber == '8' || firstNumber == '9')
            {
                for (int i = 1; i < num.Length; ++i)
                {
                    if (num[i] != '0' && num[i] != '1' && num[i] != '2' && num[i] != '3' && num[i] != '4' && num[i] != '5' && num[i] != '6' && num[i] != '7' && num[i] != '8' && num[i] != '9')
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public static bool IsValidBinary(string num)
        {
            if (num == "0b")
            {
                return false;
            }

            for (int i = 2; i < num.Length; ++i)
            {
                if (num[i] != '0' && num[i] != '1')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValidHex(string num)
        {
            for (int i = 2; i < num.Length; ++i)
            {
                if (!int.TryParse(num[i].ToString(), out int digitNum) && num[i] != 'A' && num[i] != 'B' && num[i] != 'C' && num[i] != 'D' && num[i] != 'E' && num[i] != 'F')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValidNumber(string num)
        {
            if (num == "0b" || num == "0x")
            {
                return false;
            }

            if (num.StartsWith("0b"))
            {
                if (IsValidBinary(num))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (num.StartsWith("0x"))
            {
                if (IsValidHex(num))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (IsValidDecimal(num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string MultiplyByTwo(string number)
        {
            string result = "";
            bool bCarryover = false;

            for (int i = number.Length - 1; i >= 0; --i)
            {
                int currentDigitMultipliedBy2 = int.Parse(number[i].ToString()) * 2;

                if (bCarryover)
                {
                    currentDigitMultipliedBy2 += 1;
                }

                if (currentDigitMultipliedBy2 > 9)
                {
                    bCarryover = true;
                    currentDigitMultipliedBy2 -= 10;
                }
                else
                {
                    bCarryover = false;
                }

                result = result.Insert(0, $"{currentDigitMultipliedBy2}");
            }

            if (bCarryover)
            {
                result = result.Insert(0, "1");
            }

            return result;
        }

        public static string GetQuotientDividedByTwo(string number)
        {
            string quotient = "";
            bool bIsNoRemainder = true;

            for (int i = 0; i < number.Length; ++i)
            {
                int currentDigit = int.Parse(number[i].ToString());

                if (!bIsNoRemainder)
                {
                    currentDigit += 10;
                }

                string quotientCurrentDigit = (currentDigit / 2).ToString();

                quotient = quotient + quotientCurrentDigit;

                if (currentDigit % 2 == 0)
                {
                    bIsNoRemainder = true;
                }
                else
                {
                    bIsNoRemainder = false;
                }
            }

            if (quotient[0] == '0')
            {
                quotient = quotient.Remove(0, 1);
            }

            return quotient;
        }

        public static string FromBinaryToHex(string binaryNumber)
        {
            int remainderDigitsDividedByFour = (binaryNumber.Length - 2) % 4;
            char numSignDigit = binaryNumber[2];

            if (remainderDigitsDividedByFour > 0)
            {
                for (int i = 0; i < 4 - remainderDigitsDividedByFour; ++i)
                {
                    if (numSignDigit == '0')
                    {
                        binaryNumber = binaryNumber.Insert(2, "0");
                    }
                    else
                    {
                        binaryNumber = binaryNumber.Insert(2, "1");
                    }
                }
            }

            string numBinaryToHex = "0x";
            int numberOfHexDigits = (binaryNumber.Length - 2) / 4;

            for (int i = 0; i < numberOfHexDigits; ++i)
            {
                string fourBinaryDigits = binaryNumber.Substring(i * 4 + 2, 4);

                if (fourBinaryDigits == "0000")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "0");
                }
                else if (fourBinaryDigits == "0001")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "1");
                }
                else if (fourBinaryDigits == "0010")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "2");
                }
                else if (fourBinaryDigits == "0011")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "3");
                }
                else if (fourBinaryDigits == "0100")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "4");
                }
                else if (fourBinaryDigits == "0101")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "5");
                }
                else if (fourBinaryDigits == "0110")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "6");
                }
                else if (fourBinaryDigits == "0111")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "7");
                }
                else if (fourBinaryDigits == "1000")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "8");
                }
                else if (fourBinaryDigits == "1001")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "9");
                }
                else if (fourBinaryDigits == "1010")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "A");
                }
                else if (fourBinaryDigits == "1011")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "B");
                }
                else if (fourBinaryDigits == "1100")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "C");
                }
                else if (fourBinaryDigits == "1101")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "D");
                }
                else if (fourBinaryDigits == "1110")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "E");
                }
                else if (fourBinaryDigits == "1111")
                {
                    numBinaryToHex = numBinaryToHex.Insert(numBinaryToHex.Length, "F");
                }
            }

            return numBinaryToHex;
        }

        public static string GetDecimalFromBinary(string numBinary)
        {
            string numBinaryToDecimal = "0";
            string currentDecimalValue = "1";
            bool bIsNegative = false;

            if (numBinary[2] == '1')
            {
                bIsNegative = true;
            }

            // check positivity

            for (int i = numBinary.Length - 1; i > 2; --i)
            {
                if (numBinary[i] == '1')
                {
                    numBinaryToDecimal = AddTwoDecimalNumbers(currentDecimalValue, numBinaryToDecimal);
                }

                currentDecimalValue = MultiplyByTwo(currentDecimalValue);
            }

            if (bIsNegative)
            {
                int numBinaryDigitsNoSignedBit = numBinary.Length - 3;

                numBinaryToDecimal = SubtractTwoDecimalNumbers(currentDecimalValue, numBinaryToDecimal);

                numBinaryToDecimal = numBinaryToDecimal.Insert(0, "-");
            }

            return numBinaryToDecimal;
        }

        public static string AddTwoDecimalNumbers(string numBigger, string numSmaller)
        {
            string result = "";
            bool bCarryover = false;
            int differenceDigits = numBigger.Length - numSmaller.Length;

            for (int i = 0; i < differenceDigits; ++i)
            {
                numSmaller = numSmaller.Insert(0, "0");
            }

            for (int i = 1; i <= numBigger.Length; ++i)
            {
                int numBiggerDigitNumber = int.Parse(numBigger[numBigger.Length - i].ToString());
                int numSmallerDigitNumber = int.Parse(numSmaller[numSmaller.Length - i].ToString());

                int sum = numBiggerDigitNumber + numSmallerDigitNumber;

                if (bCarryover)
                {
                    sum += 1;
                }

                if (sum > 9)
                {
                    bCarryover = true;
                    sum -= 10;
                }
                else
                {
                    bCarryover = false;
                }

                result = result.Insert(0, $"{sum}");
            }

            if (bCarryover)
            {
                result = result.Insert(0, "1");
            }

            return result;
        }

        public static string SubtractTwoDecimalNumbers(string numBigger, string numSmaller)
        {
            string result = "";
            bool bBorrowing = false;
            int differenceDigits = numBigger.Length - numSmaller.Length;

            for (int i = 0; i < differenceDigits; ++i)
            {
                numSmaller = numSmaller.Insert(0, "0");
            }

            for (int i = 1; i <= numBigger.Length; ++i)
            {
                int numBiggerDigitNumber = int.Parse(numBigger[numBigger.Length - i].ToString());
                int numSmallerDigitNumber = int.Parse(numSmaller[numSmaller.Length - i].ToString());

                if (bBorrowing)
                {
                    numBiggerDigitNumber -= 1;
                }

                if (numBiggerDigitNumber < numSmallerDigitNumber)
                {
                    bBorrowing = true;
                    numBiggerDigitNumber += 10;
                }
                else
                {
                    bBorrowing = false;
                }

                result = result.Insert(0, $"{numBiggerDigitNumber - numSmallerDigitNumber}");
            }

            if (result == "0")
            {
                return result;
            }

            while (result[0] == '0')
            {
                if (result == "0")
                {
                    return result;
                }
                
                result = result.Remove(0, 1);
            }

            return result;
        }

        public static string GetLargerNumber(string num1, string num2)
        {
            if (num1 == num2)
            {
                return num1;
            }

            if (num1.Length > num2.Length)
            {
                return num1;
            }
            else if (num2.Length > num1.Length)
            {
                return num2;
            }
            else
            {
                for (int i = 0; i < num1.Length; ++i)
                {
                    int num1CurrentDigit = int.Parse(num1[i].ToString());
                    int num2CurrentDigit = int.Parse(num2[i].ToString());

                    if (num1CurrentDigit > num2CurrentDigit)
                    {
                        return num1;
                    }
                    else if (num1CurrentDigit < num2CurrentDigit)
                    {
                        return num2;
                    }
                }
            }

            return num1;
        }
    }
}