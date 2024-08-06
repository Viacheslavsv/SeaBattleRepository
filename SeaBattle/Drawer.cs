namespace SeaBattle.Models
{
    public static class Drawer
    {
         private static void DrawEmptyCell(Cell c, Graphics g)
        {
            g.DrawLine(new Pen(new SolidBrush(Color.DarkBlue), 2), c.X, c.Y, c.X + c.Size, c.Y);
            g.DrawLine(new Pen(new SolidBrush(Color.DarkBlue), 2), c.X+c.Size, c.Y, c.X + c.Size, c.Y+c.Size);
            g.DrawLine(new Pen(new SolidBrush(Color.DarkBlue), 2), c.X+c.Size, c.Y+c.Size, c.X, c.Y+c.Size);
            g.DrawLine(new Pen(new SolidBrush(Color.DarkBlue), 2), c.X, c.Y+c.Size, c.X , c.Y);
        }

        private static void DrawNotEmptyCell(Cell c, Graphics g)
        {
            int x=c.X, y=c.Y, size=c.Size;
            for(int i=0;i<5;i++)
            {
               g.DrawLine(new Pen(new SolidBrush(Color.Black),2), x + (size / 5 * i), y, x, y + (size / 5 * i));
            }
            for (int i = 5; i >=0; i--)
            {
                g.DrawLine(new Pen(new SolidBrush(Color.Black),2),x+size-(size/5*i),y+size,x+size,y+size-(size/5*i));
            }
        }

        private static void DrawShootedEmptyCell(Cell c,Graphics g)
        {
            int x = c.X, y = c.Y, size = c.Size;
            DrawEmptyCell(c,g);
            g.FillEllipse(new SolidBrush(Color.Black),x+size*1/4+5,y+size*1/4+5,size*1/4,size*1/4);
        }
        private static void DrawShootedCellWithShip(Cell c, Graphics g)
        {
            int x = c.X, y = c.Y, size = c.Size;
            g.FillRectangle(new SolidBrush(Color.Black), x, y, size, size);
        }
         public static void DrawMyField(Field f)
        {
            Bitmap MyFieldBmp = new Bitmap(f.MyField.Width, f.MyField.Height);
            Graphics g = Graphics.FromImage(MyFieldBmp);
            
            for (int i = 0; i < Field.SIZE; i++)
            {
                for (int j = 0; j < Field.SIZE; j++)
                {
                    if (f[i, j].IsWithShip && !f[i,j].IsShooted)
                    {
                       DrawNotEmptyCell(f[i, j], g);
                    }
                    else if (f[i,j].IsShooted && f[i,j].IsWithShip)
                    {
                        DrawShootedCellWithShip(f[i, j], g);
                    }
                    else if (!f[i,j].IsWithShip && f[i,j].IsShooted)
                    {
                        DrawShootedEmptyCell(f[i, j], g);
                    }
                    else
                    {
                       DrawEmptyCell(f[i, j], g);
                    }
                    
                }
            }
            f.MyField.Image = MyFieldBmp;
            
        }
        public static void DrawComputerField(Field f)
        {
            Bitmap MyFieldBmp = new Bitmap(f.MyField.Width, f.MyField.Height);
            Graphics g = Graphics.FromImage(MyFieldBmp);

            for (int i = 0; i < Field.SIZE; i++)
            {
                for (int j = 0; j < Field.SIZE; j++)
                {
                   if (f[i, j].IsShooted && f[i, j].IsWithShip)
                    {
                        DrawShootedCellWithShip(f[i, j], g);
                    }
                    else if (!f[i, j].IsWithShip && f[i, j].IsShooted)
                    {
                        DrawShootedEmptyCell(f[i, j], g);
                    }
                    else
                    {
                        DrawEmptyCell(f[i, j], g);
                    }

                }
            }
            
            f.MyField.Image = MyFieldBmp;
        }
        public static void AddNumeration(Form form)
        {
            for (int i = 0; i < 10; i++)
            {
                const int labelSize = 20;
                const string numeration = "АБВГДЕЖЗИК";
                int formWidth = form.Width - 12;
                form.Controls.Add(new Label() { Location = new Point((i + 1) * 45, 12), Size = new Size(labelSize, labelSize), Text = $"{numeration[i]}", BackColor = Color.Transparent });
                form.Controls.Add(new Label() { Location = new Point(7, (i + 1) * 45), Size = new Size(labelSize + 10, labelSize), Text = $"{i + 1}", BackColor = Color.Transparent });
                form.Controls.Add(new Label() { Location = new Point((i + 1) * 45 + 465, 12), Size = new Size(labelSize, labelSize), Text = $"{numeration[i]}", BackColor = Color.Transparent });
                form.Controls.Add(new Label() { Location = new Point(945, (i + 1) * 45), Size = new Size(labelSize + 10, labelSize), Text = $"{i + 1}", BackColor = Color.Transparent });
            }
        }
    }
}
