using SeaBattle.Models;

namespace SeaBattle
{
    public class ShipEditMode 
    {
        private Dictionary<int, int> availableShips = new Dictionary<int, int>() { { 1, 4 }, { 2, 3 }, { 3, 2 }, { 4, 1 } };
        private ShipType _shipType;
        private ShipPosition _shipPosition;
        private Button startGame;
        private GroupBox shipTypes;
        private Field myField;
        public ShipType _ShipType{ get { return _shipType; } }
        public ShipPosition _ShipPosition { get { return _shipPosition; } }
        public ShipEditMode(Field myField, Button StartGame, GroupBox shipTypes)
        {
            this.myField = myField;
            _shipType = ShipType.OneDeck;
            _shipPosition = ShipPosition.Vertical;
            startGame = StartGame;
            this.shipTypes = shipTypes;
        }

        public Cell FindCellOnBoardByCoords(int x, int y)
        {
            for (int i = 0; i < Field.SIZE; i++)
            {
                for (int j = 0; j < Field.SIZE; j++)
                {
                    if (myField[i, j].X <= x && myField[i, j].X + myField[i, j].Size >= x && myField[i, j].Y <= y && myField[i, j].Y + myField[i, j].Size >= y)
                        return myField[i, j];
                }
            }
            return null;
        }
        public void ChangeShipType(RadioButton rb)
        {
            if (rb is null)
                throw new ArgumentNullException("Радиобаттон не может быть равен 0");
            switch(rb.Name)
            {
                case "rbOneDeck":
                    _shipType = ShipType.OneDeck;
                    break;
                case "rbTwoDeck":
                    _shipType = ShipType.TwoDeck;
                    break;
                case "rbThreeDeck":
                    _shipType = ShipType.ThreeDeck;
                    break;
                case "rbFourDeck":
                    _shipType = ShipType.FourDeck;
                    break;
                    default:
                    throw new ArgumentException("Непрвильный тип корабля.");
            }
        }

        public void ChangeShipPosition(RadioButton rb)
        {
            if (rb is null)
                throw new ArgumentNullException("Радиобаттон не может быть равен 0");
            switch (rb.Name)
            {
                case "rbVertical":
                    _shipPosition = ShipPosition.Vertical;
                    break;
                case "rbHorizontal":
                    _shipPosition= ShipPosition.Horizontal;
                    break;
                default:
                    throw new ArgumentException("Неправильное расположение корабля.");
            }

        }

        public void ClickOnField(int x, int y)
        {
            Cell c = FindCellOnBoardByCoords(x, y);
            if (!c.IsWithShip)
                AddShipOnField(c);
            else
            {
                DeleteShip(c);
            }
            Drawer.DrawMyField(myField);
        }

        private void AddShipOnField(Cell c)
        {
            
            int shipLength = DefineShipLength();
            bool ifShipCanBeAdded; 
            switch (_shipPosition)
            {
                case ShipPosition.Vertical:
                  ifShipCanBeAdded= IfCanPutVerticalShip(c.XIndex, c.YIndex,myField);
                    break;
                case ShipPosition.Horizontal:
                    ifShipCanBeAdded = IfCanPutHorizontalShip(c.XIndex, c.YIndex,myField);
                    break;
                default:
                    throw new ArgumentException("Неправильное расположение корабля.");
            }
            if(ifShipCanBeAdded && availableShips[shipLength]>0)
            {
                switch(_ShipPosition)
                {
                    case ShipPosition.Horizontal:
                        AddHorizontalShip(shipLength, c.XIndex, c.YIndex, myField);
                        availableShips[shipLength]--;
                        break;
                    case ShipPosition.Vertical:
                        AddVerticalShip(shipLength, c.XIndex, c.YIndex,myField);
                        availableShips[shipLength]--;
                        break;
                    default:
                        throw new ArgumentException("Неправильное расположение корабля.");
                }
            }

            ChangeTextOnRadioButtons();

            int counter = 0;
            foreach(var element in availableShips)
            {
                if (element.Value > 0)
                    break;
                else counter++;
            }
            if (counter == 4)
                startGame.Enabled = true;
        }

        private void DeleteShip(Cell c)
        {
            List<Cell> FindShip(List<Cell> ship)
            {
                List<Cell> oldShip = new List<Cell>(ship);
                for(int i=0;i<ship.Count;i++)
                {
                    int xIndex = ship[i].XIndex, yIndex = ship[i].YIndex;
                    if (xIndex + 1 < Field.SIZE && myField[xIndex + 1, yIndex].IsWithShip)
                    {
                        int counter = 0;
                        for (int j = 0; j < ship.Count; j++)
                        {
                            if (ship[j].XIndex == ship[i].XIndex + 1 && ship[j].YIndex == ship[i].YIndex)
                                counter++;
                        }
                        if (counter == 0)
                            ship.Add(myField[xIndex + 1, yIndex]);
                    }
                    if (xIndex - 1 >=0 && myField[xIndex - 1, yIndex].IsWithShip)
                    {
                        int counter = 0;
                        for (int j = 0; j < ship.Count; j++)
                        {
                            if (ship[j].XIndex == ship[i].XIndex - 1 && ship[j].YIndex == ship[i].YIndex)
                                counter++;
                        }
                        if (counter == 0)
                            ship.Add(myField[xIndex - 1, yIndex]);
                    }
                    if (yIndex + 1 < Field.SIZE && myField[xIndex, yIndex + 1].IsWithShip)
                    {
                        int counter = 0;
                        for (int j = 0; j < ship.Count; j++)
                        {
                            if (ship[j].XIndex == ship[i].XIndex && ship[j].YIndex == ship[i].YIndex+1)
                                counter++;
                        }
                        if (counter == 0)
                            ship.Add(myField[xIndex, yIndex + 1]);
                    }
                    if (yIndex - 1 >= 0 && myField[xIndex, yIndex - 1].IsWithShip)
                    {
                        int counter = 0;
                        for (int j = 0; j < ship.Count; j++)
                        {
                            if (ship[j].XIndex == ship[i].XIndex && ship[j].YIndex == ship[i].YIndex - 1)
                                counter++;
                        }
                        if (counter == 0)
                            ship.Add(myField[xIndex, yIndex - 1]);
                    }
                    if (oldShip.Count == ship.Count)
                        return ship;
                    else FindShip(ship);
                }
                return ship;
            }
            List<Cell> ship = new List<Cell>();
            ship.Add(c);
            ship=FindShip(ship);
            foreach(var cell in ship)
            {
                cell.IsWithShip = false;
               int xIndex=cell.XIndex, yIndex=cell.YIndex;
                try
                {
                    myField[xIndex - 1, yIndex].IsEmpty = true;
                    myField[xIndex - 1, yIndex - 1].IsEmpty = true;
                    myField[xIndex, yIndex - 1].IsEmpty = true;
                    myField[xIndex + 1, yIndex - 1].IsEmpty = true;
                    myField[xIndex + 1, yIndex].IsEmpty = true;
                    myField[xIndex + 1, yIndex + 1].IsEmpty = true;
                    myField[xIndex, yIndex + 1].IsEmpty = true;
                    myField[xIndex - 1, yIndex + 1].IsEmpty = true;
                }
                catch(IndexOutOfRangeException)
                { }
            }
            availableShips[ship.Count]++;
            ChangeTextOnRadioButtons();
            startGame.Enabled = false;
            
        }

        private void ChangeTextOnRadioButtons()
        {
            shipTypes.GetChildAtPoint(new Point(17, 26)).Text = $"Однопалубные : {availableShips[1]}.";
            shipTypes.GetChildAtPoint(new Point(17, 56)).Text = $"Двухпалубные : {availableShips[2]}.";
            shipTypes.GetChildAtPoint(new Point(181, 26)).Text = $"Трёхпалубные : {availableShips[3]}.";
            shipTypes.GetChildAtPoint(new Point(181, 56)).Text = $"Четырёхпалубные : {availableShips[4]}.";

        }


        private void AddVerticalShip(int shipLength, int xIndex, int yIndex, Field f)
        {
          for (int i = 0; i < shipLength; i++)
            {
                if (yIndex + i < Field.SIZE)
                {
                    f[xIndex, yIndex + i].IsEmpty = false;
                    f[xIndex, yIndex + i].IsWithShip = true;
                }
                if (xIndex + 1 < Field.SIZE)
                    f[xIndex + 1, yIndex + i].IsEmpty = false;
                if (xIndex - 1 >= 0)
                    f[xIndex - 1, yIndex + i].IsEmpty = false;
                if (yIndex + i + 1 < Field.SIZE)
                    f[xIndex, yIndex + i + 1].IsEmpty = false;
                if (yIndex + i - 1 >= 0)
                    f[xIndex, yIndex + i - 1].IsEmpty = false;
            }
        }

        private void AddHorizontalShip(int shipLength, int xIndex, int yIndex, Field f)
        {
            for (int i = 0; i < shipLength; i++)
            {
                if (xIndex + i < Field.SIZE)
                {
                    f[xIndex + i, yIndex].IsEmpty = false;
                    f[xIndex + i, yIndex].IsWithShip = true;
                }
                    if(xIndex + i + 1<Field.SIZE)
                    f[xIndex + i + 1, yIndex].IsEmpty = false;
                if (xIndex + i - 1 >=0)
                    f[xIndex + i - 1, yIndex].IsEmpty = false;
                if (yIndex + 1 <Field.SIZE)
                    f[xIndex + i, yIndex + 1].IsEmpty = false;
                if (yIndex - 1 >= 0)
                    f[xIndex + i, yIndex - 1].IsEmpty = false;
            }
        }
        private bool IfCanPutHorizontalShip(int xIndex, int yIndex, Field f)
        {
            int shipLength = DefineShipLength();
            if (xIndex < Field.SIZE && xIndex >= 0 && yIndex < Field.SIZE && yIndex >= 0 && xIndex + shipLength - 1 < Field.SIZE)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    if (!f[xIndex + i, yIndex].IsEmpty)
                        return false;
                }
               
                    for (int i = 0; i < shipLength; i++)
                    {
                        if (xIndex + i - 1<Field.SIZE && xIndex + i - 1>=0 && f[xIndex + i - 1, yIndex].IsWithShip ||
                            xIndex + i - 1 < Field.SIZE && xIndex + i - 1 >= 0 && yIndex-1>=0 && f[xIndex + i - 1, yIndex - 1].IsWithShip ||
                            xIndex+i<Field.SIZE && yIndex-1>=0 && f[xIndex + i, yIndex - 1].IsWithShip ||
                            xIndex + i + 1 < Field.SIZE && yIndex - 1 >= 0 && f[xIndex + i + 1, yIndex - 1].IsWithShip ||
                            xIndex + i + 1 < Field.SIZE && f[xIndex + i + 1, yIndex].IsWithShip ||
                            xIndex + i + 1 < Field.SIZE && yIndex+1<Field.SIZE && f[xIndex + i + 1, yIndex + 1].IsWithShip ||
                            xIndex + i < Field.SIZE && yIndex+1<Field.SIZE && f[xIndex + i, yIndex + 1].IsWithShip ||
                            xIndex + i - 1 < Field.SIZE && xIndex + i - 1 >= 0 && yIndex + 1 < Field.SIZE && f[xIndex + i - 1, yIndex + 1].IsWithShip)
                            return false;
                    }
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool IfCanPutVerticalShip(int xIndex, int yIndex, Field f)
        {
            int shipLength = DefineShipLength();
            if (xIndex < Field.SIZE && xIndex >= 0 && yIndex < Field.SIZE && yIndex >= 0 && yIndex + shipLength - 1 < Field.SIZE)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    if (!f[xIndex, yIndex+i].IsEmpty)
                        return false;
                }
              
                    for (int i = 0; i < shipLength; i++)
                    {
                        
                        if (yIndex + i - 1>=0 && f[xIndex, yIndex + i - 1].IsWithShip ||
                            yIndex + i - 1>=0 && xIndex-1>=0 && f[xIndex - 1, yIndex + i - 1].IsWithShip ||
                            xIndex - 1>=0 && yIndex+i<Field.SIZE && f[xIndex - 1, yIndex + i].IsWithShip ||
                            xIndex - 1>=0 && yIndex+i+1<Field.SIZE && f[xIndex - 1, yIndex + i + 1].IsWithShip ||
                            yIndex + i + 1<Field.SIZE && f[xIndex, yIndex + i + 1].IsWithShip ||
                            xIndex + 1<Field.SIZE && yIndex+i+1<Field.SIZE && f[xIndex + 1, yIndex + i + 1].IsWithShip ||
                            xIndex + 1<Field.SIZE && yIndex+i<Field.SIZE && f[xIndex + 1, yIndex + i].IsWithShip ||
                            xIndex+1<Field.SIZE && yIndex+i-1<Field.SIZE && yIndex+i-1>=0 && f[xIndex + 1, yIndex + i - 1].IsWithShip)
                            return false;
                    }
                
             
                return true;
            }
            else
            {
                return false;
            }
        }
        private int DefineShipLength()
        {
            switch (_shipType)
            {
                case ShipType.OneDeck:
                    return 1;
                    
                case ShipType.TwoDeck:
                    return 2;
                     
                case ShipType.ThreeDeck:
                    return 3;
                    
                case ShipType.FourDeck:
                    return 4;
                    
                default:
                    throw new ArgumentException("Непрвильный тип корабля.");
            }
        }

        public void SetShitAutomatic(Field f)
        {
            Random r = new Random();
            availableShips = new Dictionary<int, int>() { { 1, 4 }, { 2, 3 }, { 3, 2 }, { 4, 1 } };
            for (int i=4;i>=1;i--)
            {
                while (availableShips[i]>0)
                {
                    _shipType = (ShipType)(i - 1);
                    bool isSeted = false;
                    while (!isSeted)
                    {
                        _shipPosition = r.Next(1, 3) == 1 ? ShipPosition.Vertical : ShipPosition.Horizontal;
                        int index1 = r.Next(10);
                        int index2 = r.Next(10);
                        if (_shipPosition == ShipPosition.Horizontal)
                        {
                            if (IfCanPutHorizontalShip(index1, index2, f))
                            {
                                AddHorizontalShip(i, index1, index2, f);
                                availableShips[i]--;
                                isSeted = true;
                            }
                        }
                        else
                        {
                            if (IfCanPutVerticalShip(index1, index2, f))
                            {
                                AddVerticalShip(i, index1, index2, f);
                                availableShips[i]--;
                                isSeted = true;
                            }
                        }
                    }
                }
            }
            ChangeTextOnRadioButtons();
        }

    }

   public enum ShipType
    {
        OneDeck,
        TwoDeck,
        ThreeDeck,
        FourDeck
    }
    public enum ShipPosition
    {
        Vertical,
        Horizontal
    }

}
