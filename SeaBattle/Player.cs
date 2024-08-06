using SeaBattle.Models;

namespace SeaBattle
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
            RestartGame();
        }
       
        private void Player1_Load(object sender, EventArgs e)
        {
            Drawer.DrawMyField(myField);
            Drawer.DrawComputerField(computerField);
            Drawer.AddNumeration(this);
        }

        private void rbCheckedChanged(object sender, EventArgs e)
        {
            sem.ChangeShipType(sender as RadioButton);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(gameMode==GameMode.ShipEditingMode)
                sem.ClickOnField(e.X, e.Y);
            
        }
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameMode == GameMode.PlayingMode)
                pm.PictureBoxClicked(e.X,e.Y);
        }

        private void rbVertical_CheckedChanged(object sender, EventArgs e)
        {
            sem.ChangeShipPosition(sender as RadioButton);
        }

        private void btStartGame_Clicked(object sender, EventArgs e)
        {
            if (gameMode == GameMode.ShipEditingMode)
            {
                sem.SetShitAutomatic(computerField);
                gbShipType.Enabled = false;
                gbShipPosition.Enabled = false;
                btMoveBack.Enabled = true;
                gameMode = GameMode.PlayingMode;
                btRandomShipSet.Enabled = false;
                lbStatus.Text = "Выполните ход.";
            }
        }

        private void btRandomShipSet_Click(object sender, EventArgs e)
        {
            if (gameMode == GameMode.ShipEditingMode)
            {
                myField = new Field(pictureBox1);
                sem = new ShipEditMode(myField, btSatrtGame, gbShipType);
                pm = new PlayingMode(myField, computerField);
                sem.SetShitAutomatic(myField);
                Drawer.DrawMyField(myField);
                btSatrtGame.Enabled = true;
            }
        }

        private void btRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void RestartGame()
        {
            myField = new Field(pictureBox1);
            computerField = new Field(pictureBox2);
            sem = new ShipEditMode(myField, btSatrtGame, gbShipType);
            pm = new PlayingMode(myField, computerField);
            gameMode = GameMode.ShipEditingMode;
            btSatrtGame.Enabled = false;
            gbShipPosition.Enabled = true;
            btMoveBack.Enabled = false;
            gbShipType.Enabled = true;
            Drawer.DrawMyField(myField);
            Drawer.DrawComputerField(computerField);
            rbOneDeck.Checked = true;
            this.rbThreeDeck.Text = "Трёхпалубные : 2.";
            this.rbFourDeck.Text = "Четырёхпалубные : 1.";
            this.rbTwoDeck.Text = "Двухпалубные : 3.";
            this.rbOneDeck.Text = "Однопалубные : 4.";
            lbStatus.Text = "Расставте корабли.";
            btRandomShipSet.Enabled = true;  
        }

        private void btMoveBack_Click(object sender, EventArgs e)
        {
            pm.MoveBack();
        }

    }
}
