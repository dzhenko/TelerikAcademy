namespace MinesweeperGame
{
    public class Score
    {
        private string name;
        private int points;

        public Score()
            : this(string.Empty, 0) 
        {
        }

        public Score(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)