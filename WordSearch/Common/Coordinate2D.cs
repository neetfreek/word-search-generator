namespace WordSearch.Common
{
    public class GridPosition2D
    {
        private int row;
        private int col;

        public int Row
        {
            get
            {
                return row;
            }
        }
        public int Col
        {
            get
            {
                return col;
            }
        }

        public GridPosition2D(int row, int col)
        {
            this.row = col;
            this.col = row;
        }
    }
}
