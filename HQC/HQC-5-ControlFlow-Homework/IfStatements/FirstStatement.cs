namespace IfStatements
{
    public class FirstStatement
    {
        public static void CookPotato()
        {
            // doesn't compile if not instanced
            Potato potato = new Potato();

            // ... 
            if (potato != null)
            {
                if (potato.HasBeenPeeled && potato.IsFresh)
                {
                    Cook(potato);
                }
            }
        }

        private static void Cook(Potato potato)
        {
            // ..
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)