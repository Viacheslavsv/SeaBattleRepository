namespace SeaBattle.Models
{
    public class Field : ICloneable
    {
        private Cell[,] field;
        public PictureBox MyField { get; set; }
        public Cell[,] _Field { get { return field; } }

        public const int SIZE = 10;

        public Cell this[int index1, int index2]
        {
            get
            {
                return field[index1, index2];
            }
            set
            {
                field[index1, index2] = value??throw new ArgumentNullException("Клетка не может быть null");
            }
        }

        public Field(PictureBox myField)
        {
            MyField = myField ?? throw new ArgumentNullException("Элемент PictureBox не может быть null");
            if (MyField.Width != MyField.Height)
                MyField.Width = MyField.Height;
            int cellSize = MyField.Width / SIZE;
            this.field = new Cell[SIZE, SIZE];
            for (int i = 0; i < this.field.GetLength(0); i++)
            {
                for (int j = 0; j < this.field.GetLength(1); j++)
                {
                    this.field[i, j] = new Cell(cellSize * i, cellSize * j, cellSize, i, j);
                }
            }
        }

        public object Clone()
        {
            var newField = new Field(MyField);
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    newField[i, j] = (Cell)field[i,j].Clone();
                }
            }
            return newField;
        }
    }
}
