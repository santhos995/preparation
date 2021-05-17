using System;
using System.Text.RegularExpressions;

namespace ValidNumber
{
    class ValidNum
    {
        static Regex @int = new Regex("^[+-]*[0-9]+$");
        static Regex @decimal = new Regex("^[+-]*[0 - 9]*[.]*[0 - 9] *$");
        static void Main(string[] args)
        {
            string[] keys = new string[] { "2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789" };

            foreach(var str in keys)
            {
                Console.WriteLine($"{str}  - {validDecimal(str)}");
            }
        }
        static private bool validDecimal(string val)
        {
            var decimals = val.Split('e', 'E');
            if (decimals.Length > 2)
            {
                return false;
            }
            else
            {
                if (decimals.Length == 2 && !validInteger(decimals[1]))
                        return false;
                
                return @decimal.IsMatch(decimals[0]);
            }
        }
        static private bool validInteger(string val)
        {
            return @int.IsMatch(val);
        }

    }
}
