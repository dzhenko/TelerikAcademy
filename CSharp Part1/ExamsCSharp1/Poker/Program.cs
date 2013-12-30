using System;

class Program
{
    static void Main()
    {
        string A = (Console.ReadLine());
        string B = (Console.ReadLine());
        string C = (Console.ReadLine());
        string D = (Console.ReadLine());
        string E = (Console.ReadLine());
        bool flagAB = A == B;
        bool flagAC = A == C;
        bool flagAD = A == D;
        bool flagAE = A == E;

        bool flagBC = B == C;
        bool flagBD = B == D;
        bool flagBE = B == E;
        
        bool flagCD = C == D;
        bool flagCE = C == E;

        bool flagDE = D == E;

        bool fABC = flagAB&&flagBC;
        bool fABD = flagAB&&flagBD;
        bool fABE = flagAB&&flagBE;
        bool fACD = flagAC&&flagCD;
        bool fACE = flagAC&&flagCE;
        bool fADE = flagAD&&flagDE;
        bool fBCD = flagBC&&flagCD;
        bool fBCE = flagBC&&flagCE;
        bool fBDE = flagBD&&flagDE;
        bool fCDE = flagCD&&flagDE;

        if (flagAB && flagBC && flagCD && flagDE)
        {
            Console.WriteLine("Impossible");
            Environment.Exit(0);
        }
        if ((flagAB && flagBC && flagCD) || (flagAB && flagBC && flagCE) || (flagAB && flagBD && flagDE) || (flagAC && flagCD && flagDE) || (flagBC && flagCD && flagDE))
        {
            Console.WriteLine("Four of a Kind");
            Environment.Exit(0);
        }
        //Full and three
        if (fABC || fABD || fABE || fACD || fACE || fADE || fBCD || fBCE || fBDE || fCDE)
        {
            if (flagAB || flagAC || flagAD || flagAE || flagBC || flagBD || flagBE || flagCD || flagCE || flagDE)
            {
                Console.WriteLine("Full House");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Three of a Kind");
                Environment.Exit(0);
            }
        }
        //2
        if (flagAB || flagAC || flagAD || flagAE || flagBC || flagBD || flagBE || flagCD || flagCE || flagDE)
        {
            if (((flagAC || flagAD || flagAE || flagBC || flagBD || flagBE || flagCD || flagCE || flagDE) && flagAB) ||
                ((flagAB || flagAD || flagAE || flagBC || flagBD || flagBE || flagCD || flagCE || flagDE) && flagAC) ||
                ((flagAB || flagAC || flagAE || flagBC || flagBD || flagBE || flagCD || flagCE || flagDE) && flagAD) ||
                ((flagAB || flagAC || flagAD || flagBC || flagBD || flagBE || flagCD || flagCE || flagDE) && flagAE) ||
                ((flagAB || flagAC || flagAD || flagAE || flagBD || flagBE || flagCD || flagCE || flagDE) && flagBC) ||
                ((flagAB || flagAC || flagAD || flagAE || flagBC || flagBE || flagCD || flagCE || flagDE) && flagBD) ||
                ((flagAB || flagAC || flagAD || flagAE || flagBC || flagBD || flagCD || flagCE || flagDE) && flagBE) ||
                ((flagAB || flagAC || flagAD || flagAE || flagBC || flagBD || flagBE || flagCE || flagDE) && flagCD) ||
                ((flagAB || flagAC || flagAD || flagAE || flagBC || flagBD || flagBE || flagCD || flagDE) && flagCE) ||
                ((flagAB || flagAC || flagAD || flagAE || flagBC || flagBD || flagBE || flagCD || flagCE) && flagDE))
            {
                Console.WriteLine("Two Pairs");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("One Pair");
                Environment.Exit(0);
            }
        }
        Console.WriteLine("Nothing");
    }          
}             
               

               
               

               