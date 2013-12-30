using System;

    class NumberToWords
    {
        static void Main()
        {
            string numberstr = Console.ReadLine();
            int number = Convert.ToInt32(numberstr);
            Console.WriteLine();
            Console.WriteLine(new string('-',45));          
            int original = number;
            if (numberstr.Length == 3)
            {
                if (number % 100 == 0)
                {
                    switch (number / 100)
                    {
                        case 1: Console.WriteLine(original + " ---> \"One hundred "); break;
                        case 2: Console.WriteLine(original + " ---> \"Two hundred "); break;
                        case 3: Console.WriteLine(original + " ---> \"Three hundred "); break;
                        case 4: Console.WriteLine(original + " ---> \"Four hundred "); break;
                        case 5: Console.WriteLine(original + " ---> \"Five hundred "); break;
                        case 6: Console.WriteLine(original + " ---> \"Six hundred "); break;
                        case 7: Console.WriteLine(original + " ---> \"Seven hundred "); break;
                        case 8: Console.WriteLine(original + " ---> \"Eight hundred "); break;
                        case 9: Console.WriteLine(original + " ---> \"Nine hundred "); break;
                    }
                }
                else
                {
                    switch (number / 100)
                    {
                        case 1: Console.Write(original + " ---> \"One hundred "); break;
                        case 2: Console.Write(original + " ---> \"Two hundred "); break;
                        case 3: Console.Write(original + " ---> \"Three hundred "); break;
                        case 4: Console.Write(original + " ---> \"Four hundred "); break;
                        case 5: Console.Write(original + " ---> \"Five hundred "); break;
                        case 6: Console.Write(original + " ---> \"Six hundred "); break;
                        case 7: Console.Write(original + " ---> \"Seven hundred "); break;
                        case 8: Console.Write(original + " ---> \"Eight hundred "); break;
                        case 9: Console.Write(original + " ---> \"Nine hundred "); break;                          
                    }
                    number = number % 100;
                    numberstr = number.ToString();
                }
            }
            //2 digit
            if (numberstr.Length == 2)
            {
            Here:
                if (number < 20)
                {
                    if (original < 100)
                    {
                        Console.Write(original + " ---> \"");
                    }
                    switch (number)
                    {
                        case 10: Console.WriteLine("Ten\""); break;
                        case 11: Console.WriteLine("Eleven\""); break;
                        case 12: Console.WriteLine("Twelve\""); break;
                        case 13: Console.WriteLine("Thirteen\""); break;
                        case 14: Console.WriteLine("Fourteen\""); break;
                        case 15: Console.WriteLine("Fifteen\""); break;
                        case 16: Console.WriteLine("Sixteen\""); break;
                        case 17: Console.WriteLine("Seventeen\""); break;
                        case 18: Console.WriteLine("Eightteen\""); break;
                        case 19: Console.WriteLine("Nineteen\""); break;
                    }
                }
                if ((number % 10 == 0) && (number > 19))
                {
                    if (original < 100)
                    {
                        Console.Write(original + " ---> \"");
                    }
                    switch (number)
                    {
                        case 20: Console.WriteLine("Twenty\""); break;
                        case 30: Console.WriteLine("Thirty\""); break;
                        case 40: Console.WriteLine("Fourty\""); break;
                        case 50: Console.WriteLine("Fifty\""); break;
                        case 60: Console.WriteLine("Sixty\""); break;
                        case 70: Console.WriteLine("Seventy\""); break;
                        case 80: Console.WriteLine("Eighty\""); break;
                        case 90: Console.WriteLine("Ninety\""); break;
                    }
                }
                if ((number % 10 != 0) && (number > 19))
                {
                    if (original < 100)
                    {
                        Console.Write(original + " ---> \"");
                    }
                    int testnumberTen = number / 10;
                    int testnumberOne = number % 10;
                    switch (testnumberTen)
                    {
                        case 2: Console.Write("Twenty ");
                            switch (testnumberOne)
                            {
                                case 1: Console.WriteLine("One\""); break;
                                case 2: Console.WriteLine("Two\""); break;
                                case 3: Console.WriteLine("Three\""); break;
                                case 4: Console.WriteLine("Four\""); break;
                                case 5: Console.WriteLine("Five\""); break;
                                case 6: Console.WriteLine("Six\""); break;
                                case 7: Console.WriteLine("Seven\""); break;
                                case 8: Console.WriteLine("Eight\""); break;
                                case 9: Console.WriteLine("Nine\""); break;
                            }
                            break;
                        case 3: Console.Write("Thirty ");
                            switch (testnumberOne)
                            {
                                case 1: Console.WriteLine("One\""); break;
                                case 2: Console.WriteLine("Two\""); break;
                                case 3: Console.WriteLine("Three\""); break;
                                case 4: Console.WriteLine("Four\""); break;
                                case 5: Console.WriteLine("Five\""); break;
                                case 6: Console.WriteLine("Six\""); break;
                                case 7: Console.WriteLine("Seven\""); break;
                                case 8: Console.WriteLine("Eight\""); break;
                                case 9: Console.WriteLine("Nine\""); break;
                            }
                            break;
                        case 4: Console.Write("Fourty ");
                            switch (testnumberOne)
                            {
                                case 1: Console.WriteLine("One\""); break;
                                case 2: Console.WriteLine("Two\""); break;
                                case 3: Console.WriteLine("Three\""); break;
                                case 4: Console.WriteLine("Four\""); break;
                                case 5: Console.WriteLine("Five\""); break;
                                case 6: Console.WriteLine("Six\""); break;
                                case 7: Console.WriteLine("Seven\""); break;
                                case 8: Console.WriteLine("Eight\""); break;
                                case 9: Console.WriteLine("Nine\""); break;
                            }
                            break;
                        case 5: Console.Write("Fifty ");
                            switch (testnumberOne)
                            {
                                case 1: Console.WriteLine("One\""); break;
                                case 2: Console.WriteLine("Two\""); break;
                                case 3: Console.WriteLine("Three\""); break;
                                case 4: Console.WriteLine("Four\""); break;
                                case 5: Console.WriteLine("Five\""); break;
                                case 6: Console.WriteLine("Six\""); break;
                                case 7: Console.WriteLine("Seven\""); break;
                                case 8: Console.WriteLine("Eight\""); break;
                                case 9: Console.WriteLine("Nine\""); break;
                            }
                            break;
                        case 6: Console.Write("Sixty ");
                            switch (testnumberOne)
                            {
                                case 1: Console.WriteLine("One\""); break;
                                case 2: Console.WriteLine("Two\""); break;
                                case 3: Console.WriteLine("Three\""); break;
                                case 4: Console.WriteLine("Four\""); break;
                                case 5: Console.WriteLine("Five\""); break;
                                case 6: Console.WriteLine("Six\""); break;
                                case 7: Console.WriteLine("Seven\""); break;
                                case 8: Console.WriteLine("Eight\""); break;
                                case 9: Console.WriteLine("Nine\""); break;
                            }
                            break;
                        case 7: Console.Write("Seventy ");
                            switch (testnumberOne)
                            {
                                case 1: Console.WriteLine("One\""); break;
                                case 2: Console.WriteLine("Two\""); break;
                                case 3: Console.WriteLine("Three\""); break;
                                case 4: Console.WriteLine("Four\""); break;
                                case 5: Console.WriteLine("Five\""); break;
                                case 6: Console.WriteLine("Six\""); break;
                                case 7: Console.WriteLine("Seven\""); break;
                                case 8: Console.WriteLine("Eight\""); break;
                                case 9: Console.WriteLine("Nine\""); break;
                            }
                            break;
                        case 8: Console.Write("Eighty ");
                            switch (testnumberOne)
                            {
                                case 1: Console.WriteLine("One\""); break;
                                case 2: Console.WriteLine("Two\""); break;
                                case 3: Console.WriteLine("Three\""); break;
                                case 4: Console.WriteLine("Four\""); break;
                                case 5: Console.WriteLine("Five\""); break;
                                case 6: Console.WriteLine("Six\""); break;
                                case 7: Console.WriteLine("Seven\""); break;
                                case 8: Console.WriteLine("Eight\""); break;
                                case 9: Console.WriteLine("Nine\""); break;
                            }
                            break;
                        case 9: Console.Write("Ninety ");
                            switch (testnumberOne)
                            {
                                case 1: Console.WriteLine("One\""); break;
                                case 2: Console.WriteLine("Two\""); break;
                                case 3: Console.WriteLine("Three\""); break;
                                case 4: Console.WriteLine("Four\""); break;
                                case 5: Console.WriteLine("Five\""); break;
                                case 6: Console.WriteLine("Six\""); break;
                                case 7: Console.WriteLine("Seven\""); break;
                                case 8: Console.WriteLine("Eight\""); break;
                                case 9: Console.WriteLine("Nine\""); break;
                            }
                            break;
                    }
                }
                
            }
            //1 digit
            if (numberstr.Length == 1)
            {
                switch (number) 
                {
                    case 0: Console.WriteLine(original + " ---> \"Zero\""); break;
                    case 1: Console.WriteLine(original + " ---> \"One\""); break;
                    case 2: Console.WriteLine(original + " ---> \"Two\""); break;
                    case 3: Console.WriteLine(original + " ---> \"Three\""); break;
                    case 4: Console.WriteLine(original + " ---> \"Four\""); break;
                    case 5: Console.WriteLine(original + " ---> \"Five\""); break;
                    case 6: Console.WriteLine(original + " ---> \"Six\""); break;
                    case 7: Console.WriteLine(original + " ---> \"Seven\""); break;
                    case 8: Console.WriteLine(original + " ---> \"Eight\""); break;
                    case 9: Console.WriteLine(original + " ---> \"Nine\""); break;
                }
            }           
            Console.WriteLine(new string('-', 45));
            Console.WriteLine();
            Console.WriteLine("Sorry for any punctuation errors :)");
        }
    }

