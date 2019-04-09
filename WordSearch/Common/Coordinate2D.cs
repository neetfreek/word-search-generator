namespace WordSearch.Common
{
    public class Coordinate2D
    {
        private int x;
        private int y;

        public int X
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }

        public Coordinate2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
