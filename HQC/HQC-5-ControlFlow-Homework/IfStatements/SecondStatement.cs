namespace IfStatements
{
    public class SecondStatement
    {
        public const int MinX = 100;
        public const int MaxX = 1000;
        public const int MinY = 200;
        public const int MaxY = 1800;

        public static void MoveToCell(int x, int y, bool shouldVisitCell)
        {
            if (CheckCellValidity(x, y) && shouldVisitCell)
            {
               VisitCell(x, y);
            }
        }

        private static bool CheckCellValidity(int x, int y) 
        {
            bool isValidX = MinX <= x && x <= MaxX;
            bool isValidY = MinY <= y && y <= MaxY;
            bool isValidCell = isValidX && isValidY;
            return isValidCell;
        }

        private static void VisitCell(int x, int y)
        {
            // ..
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)