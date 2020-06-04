﻿using System;

namespace SpellNumber
{
    public class Spell
    {
        public Spell()
        {
        }

        private static string Ones(string strNumber)
        {
            var number = Convert.ToInt32(strNumber);
            var name = "";
            switch (number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        private static String Tens(String strNumber)
        {
            int number = Convert.ToInt32(strNumber);
            String name = null;
            switch (number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (number > 0)
                    {
                        name = Tens(strNumber.Substring(0, 1) + "0") + " " + Ones(strNumber.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private static String ConvertWholeNumber(String strNumber)
        {
            string word = "";
            try
            {
                bool isDone = false;//test if already translated    
                double dblAmt = (Convert.ToDouble(strNumber));

                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric    

                    int numDigits = strNumber.Length;
                    int pos = 0;//store digit grouping    
                    String place = "";//digit grouping name:hundres,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' range    

                            word = Ones(strNumber);
                            isDone = true;
                            break;
                        case 2://tens' range    
                            word = Tens(strNumber);
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...    
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        //if transalation is not done, continue...(Recursion comes in now!!)    
                        if (strNumber.Substring(0, pos) != "0" && strNumber.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(strNumber.Substring(0, pos)) + place + ConvertWholeNumber(strNumber.Substring(pos));
                            }
                            catch
                            {
                                // ignored
                            }
                        }
                        else
                        {
                            word = ConvertWholeNumber(strNumber.Substring(0, pos)) + ConvertWholeNumber(strNumber.Substring(pos));
                        }
                    }
                    //ignore digit grouping names    
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }
        private static String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else if (number.Length == 2 && i == 0)
                {
                    engOne = Tens(digit + 0);
                }
                else { engOne = Ones(digit); }
                cd += " " + engOne;
            }
            return cd;
        }
        public static String ConvertToWords(String numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = "Only";
            try
            {
                int decimalPlace = numb.IndexOf(".", StringComparison.Ordinal);
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "Rupees and";// just to separate whole numbers from points/paise 
                        endStr = "Paisa " + endStr;//Cents    
                        pointStr = ConvertDecimals(points);
                    }
                }
                if (!string.IsNullOrEmpty(ConvertWholeNumber(wholeNo).Trim()))
                    val = $"{ConvertWholeNumber(wholeNo).Trim()} {andStr}{pointStr} {endStr}";
                else { val = "Value is negative"; }
            }
            catch
            {
                // ignored
            }

            return val;
        }
    }
}
