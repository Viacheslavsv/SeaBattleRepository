namespace SeaBattle.Models
{
    public class Cell: ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public int XIndex { get; set; }
        public int YIndex { get; set; }
        public bool IsEmpty {get; set; }
        public bool IsWithShip { get; set; }
        public bool IsShooted { get; set; }

        public Cell(int x, int y, int size, int xIndex, int yIndex)
        {
            X = x;
            Y = y;
            Size = size;
            XIndex = xIndex;
            YIndex = yIndex;
            Size = size;
            IsEmpty = true;
            IsWithShip = false;
        }

        public object Clone()
        {
            bool isShooted = IsShooted, isEmpty=IsEmpty,isWithShip=IsWithShip;
            return new Cell(X, Y, Size, XIndex, YIndex) { IsWithShip = isWithShip, IsEmpty = isEmpty, IsShooted = isShooted };
        }
    }
}
