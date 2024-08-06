using SeaBattle.Memento;
using SeaBattle.Models;

namespace SeaBattle
{

    public class PlayingMode 
    {
        private Field player;
        private Field computer;
        private Player pl1, pl2;
        private Dictionary<int, int>availableShipsPlayer=new Dictionary<int, int>() { { 1, 4 }, { 2, 3 }, { 3, 2 }, { 4, 1 } };
        private Dictionary<int, int> availableShipsComputer = new Dictionary<int, int>() { { 1, 4 }, { 2, 3 }, { 3, 2 }, { 4, 1 } };

        Caretaker ct { get; set; }

        public PlayingMode(Field player1, Field player2)
        {
            player = player1;
            computer = player2;
            ct = new Caretaker();
        }

        public void PictureBoxClicked(int x, int y)
        {
            ct.AddMemento(new Memento.Memento(player, computer));
            Cell currentCell=FindCellOnBoardByCoords(x,y,computer);
            bool IsStepFinished = false;
            while (!IsStepFinished)
            {
                if (!currentCell.IsShooted)
                {
                    currentCell.IsShooted = true;
                   if (!currentCell.IsWithShip)
                        IsStepFinished= true;
                    else
                    {
                        if (IsShipCompletelyDestroyed(currentCell, computer))
                        {
                            List<Cell> ship = FindShipAroundCell(currentCell, computer);
                            SetCheckedAroundshootedShip(ship,computer);
                            availableShipsComputer[ship.Count]--;
                        }
                    }
                    Drawer.DrawComputerField(computer);
                    if (IfGameFinished())
                        MessageBox.Show("Ура, Вы победили!", "Игра окончена.");
                }
                else
                {
                    return;
                }
            }
            ComputerStep();
           
            if (IfGameFinished())
                MessageBox.Show("Вы проиграли(","Игра окончена.");
        }
        private bool IsShipCompletelyDestroyed(Cell c,Field f)
        {
            int xIndex = c.XIndex;
            int yIndex=c.YIndex;
            while(xIndex<Field.SIZE && f[xIndex,yIndex].IsWithShip)
            {
                if (!f[xIndex, yIndex].IsShooted)
                    return false;
                xIndex++;
            }
            xIndex = c.XIndex;
            yIndex = c.YIndex;
            while (xIndex >= 0 && f[xIndex, yIndex].IsWithShip)
            {
                if (!f[xIndex, yIndex].IsShooted)
                    return false;
                xIndex--;
            }
            xIndex = c.XIndex;
            yIndex = c.YIndex;
            while (yIndex < Field.SIZE && f[xIndex, yIndex].IsWithShip)
            {
                if (!f[xIndex, yIndex].IsShooted)
                    return false;
                yIndex++;
            }
            xIndex = c.XIndex;
            yIndex = c.YIndex;
            while (yIndex >=0 && f[xIndex, yIndex].IsWithShip)
            {
                if (!f[xIndex, yIndex].IsShooted)
                    return false;
                yIndex--;
            }
            return true;
        }

        private void SetCheckedAroundshootedShip(List<Cell> ship,Field f)
        {
            foreach(Cell cell in ship) 
            {
                if(cell.XIndex + 1<Field.SIZE)
                    f[cell.XIndex + 1, cell.YIndex].IsShooted = true;

                if (cell.XIndex + 1 < Field.SIZE && cell.YIndex+1<Field.SIZE)
                    f[cell.XIndex + 1, cell.YIndex+1].IsShooted = true;

                if (cell.YIndex + 1 < Field.SIZE)
                    f[cell.XIndex, cell.YIndex+1].IsShooted = true;

                if (cell.XIndex - 1 >=0 && cell.YIndex+1<Field.SIZE)
                    f[cell.XIndex - 1, cell.YIndex+1].IsShooted = true;
               
                if (cell.XIndex - 1 >= 0)
                    f[cell.XIndex - 1, cell.YIndex].IsShooted = true;

                if (cell.XIndex - 1 >= 0 && cell.YIndex - 1 >=0)
                    f[cell.XIndex - 1, cell.YIndex-1].IsShooted = true;

                if ( cell.YIndex - 1 >=0)
                    f[cell.XIndex, cell.YIndex-1].IsShooted = true;

                if (cell.XIndex + 1<Field.SIZE && cell.YIndex - 1 >=0)
                    f[cell.XIndex + 1, cell.YIndex-1].IsShooted = true;
            }
            
        }

        private List<Cell> FindShipAroundCell(Cell c, Field f)
        {
            var ship = new List<Cell>{c};
            int xIndex = c.XIndex;
            int yIndex = c.YIndex;
            while (xIndex < Field.SIZE && f[xIndex, yIndex].IsWithShip)
            {
                if (xIndex + 1 < Field.SIZE)
                {
                    xIndex++;
                    if (f[xIndex, yIndex].IsWithShip)
                        ship.Add(f[xIndex, yIndex]);
                }
                else
                break;
            }
            xIndex = c.XIndex;
            yIndex = c.YIndex;
            while (xIndex >= 0 && f[xIndex, yIndex].IsWithShip)
            {
                if (xIndex - 1 >= 0)
                {
                    xIndex--;
                    if (f[xIndex, yIndex].IsWithShip)
                        ship.Add(f[xIndex, yIndex]);
                }
                else
                    break;

            }
            xIndex = c.XIndex;
            yIndex = c.YIndex;
            while (yIndex < Field.SIZE && f[xIndex, yIndex].IsWithShip)
            {
                if (yIndex + 1 < Field.SIZE)
                { 
                    yIndex++;
                    if (f[xIndex, yIndex].IsWithShip)
                    ship.Add(f[xIndex, yIndex]);
                }
                else
                    break;
            }
            xIndex = c.XIndex;
            yIndex = c.YIndex;
            while (yIndex >= 0 && f[xIndex, yIndex].IsWithShip)
            {
                if (yIndex - 1 >= 0)
                {
                    yIndex--;
                    if (f[xIndex, yIndex].IsWithShip)
                        ship.Add(f[xIndex, yIndex]);
                }
                else
                    break;
            }
            return ship;
        }
        private Cell FindCellOnBoardByCoords(int x, int y, Field field)
        {
            for (int i = 0; i < Field.SIZE; i++)
            {
                for (int j = 0; j < Field.SIZE; j++)
                {
                    if (field[i, j].X <= x && field[i, j].X + field[i, j].Size >= x && field[i, j].Y <= y && field[i, j].Y + field[i, j].Size >= y)
                        return field[i, j];
                }
            }
            return null;
        }

        private void ComputerStep()
        {
            bool isFinished = false;
            while (!isFinished)
            {
                Random r = new Random();
                int index1 = r.Next(10);
                int index2 = r.Next(10);
                if (!player[index1, index2].IsShooted)
                {
                    player[index1, index2].IsShooted = true;
                    if (!player[index1, index2].IsWithShip)
                        isFinished = true;
                    else
                    {
                        if (IsShipCompletelyDestroyed(player[index1,index2],player))
                        {
                            List<Cell> ship = FindShipAroundCell(player[index1,index2], player);
                            SetCheckedAroundshootedShip(ship, player);
                            availableShipsPlayer[ship.Count]--;
                        }
                    }
                }
            }
            Drawer.DrawMyField(player);
        }

        private bool IfGameFinished()
        {
            int shipCounter = 0;
            foreach(var item in availableShipsPlayer)
            {
                shipCounter += item.Value;
            }
            if (shipCounter == 0)
                return true;
            shipCounter= 0;
            foreach (var item in availableShipsComputer)
            {
                shipCounter += item.Value;
            }
            if(shipCounter==0)
                return true;
            return false;
        }

        public void MoveBack()
        {
            try
            {
                var m = ct.PickMemento();
                player = m.MyField;
                computer = m.EnemyField;
                Drawer.DrawMyField(player);
                Drawer.DrawComputerField(computer);
            }
            catch(NullReferenceException)
            { }
        }
    }
}
