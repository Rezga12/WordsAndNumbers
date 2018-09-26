using System;

namespace wordsAndNumbers
{
    class Program
    {
        static string under20(char num, bool moreTen)
        {
            switch (num)
            {
                case '0':
                    return moreTen ? "daati":"i";
                case '1':
                    return moreTen ? "datertmeti" : "daerti";
                case '2':
                    return moreTen ? "datormeti" : "daori";
                case '3':
                    return moreTen ? "dacameti" : "dasami";
                case '4':
                    return moreTen ? "datotxmeti" : "daotxi";
                case '5':
                    return moreTen ? "datxutmeti" : "daxuti";
                case '6':
                    return moreTen ? "dateqvsmeti" : "daeqvsi";
                case '7':
                    return moreTen ? "dachvidmeti" : "dashvidi";
                case '8':
                    return moreTen ? "datvrameti" : "darva";
                case '9':
                    return moreTen ? "dacxrameti" : "dacxra";

            }

            return "";
        }
        static string twoDigit(string num)
        {
            switch (num[0])
            {
                case '0':
                    return num[1] == '0' ? under20(num[1], false) : " " + under20(num[1], false).Substring(2);
                case '1':
                    return " " + under20(num[1], num[0] == '1').Substring(2);
                case '2':
                case '3':
                    return " oc" + under20(num[1], num[0] == '3'); ;
                case '4':
                case '5':
                    return " ormoc" + under20(num[1], num[0] == '5');
                case '6':
                case '7':
                    return " samoc" + under20(num[1], num[0] == '7');

                default:
                    return " otxmoc" + under20(num[1], num[0] == '9');
            }
        }
        
        static string threeDigit(string num)
        {   
            switch (num[0])
            {
                case '0':
                    return twoDigit(num.Substring(1)).Substring(1);
                case '1':
                    return "as" + twoDigit(num.Substring(1));
                case '8':
                case '9':
                    return twoDigit("0" + num[0]).Substring(1) + "as" + twoDigit(num.Substring(1)); 
                default:
                    string pref = twoDigit("0" + num[0]);
                    return pref.Substring(1, pref.Length - 2) + "as" + twoDigit(num.Substring(1));
            }
        }

        static string sixDigit(string num)
        {
            num = num.PadLeft(10, '0');
            string bil = num[0] + "";
            string mil = num.Substring(1, 3);
            string thou = num.Substring(4, 3);
            string hun = num.Substring(7, 3);

            bil = bil == "0" ? "" : twoDigit("0" + bil).Substring(1) + " miliard ";
            mil = mil == "000" ? "" : threeDigit(mil) + " milion ";
            thou = thou == "000" ? "" : threeDigit(thou) + " atas ";
            thou = thou == "erti atas " ? "atas" : thou;
            hun = hun == "000" ? "" : threeDigit(hun);

            var Result = bil + mil + thou + hun;

            if (hun == "")
                Result = Result.Substring(0, Result.Length - 1) + "i";

            return Result;
        }

        static void Main(string[] args)
        {

            while (true)
            {

                Console.WriteLine(sixDigit(Console.ReadLine()));
            }
        }
    }
}
