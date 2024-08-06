using SeaBattle.Models;


namespace SeaBattle
{
    partial class Player
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Field myField;
        private Field computerField;
        private ShipEditMode sem;
        private Player SeconPlayer;
        private static GameMode gameMode = GameMode.ShipEditingMode;
        private static PlayingMode pm;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
         private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rbOneDeck = new System.Windows.Forms.RadioButton();
            this.rbTwoDeck = new System.Windows.Forms.RadioButton();
            this.gbShipType = new System.Windows.Forms.GroupBox();
            this.rbFourDeck = new System.Windows.Forms.RadioButton();
            this.rbThreeDeck = new System.Windows.Forms.RadioButton();
            this.gbShipPosition = new System.Windows.Forms.GroupBox();
            this.rbHorizontal = new System.Windows.Forms.RadioButton();
            this.rbVertical = new System.Windows.Forms.RadioButton();
            this.btSatrtGame = new System.Windows.Forms.Button();
            this.btRandomShipSet = new System.Windows.Forms.Button();
            this.btRestartGame = new System.Windows.Forms.Button();
            this.btMoveBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbShipType.SuspendLayout();
            this.gbShipPosition.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(494, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(450, 450);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            // 
            // rbOneDeck
            // 
            this.rbOneDeck.AutoSize = true;
            this.rbOneDeck.Location = new System.Drawing.Point(17, 26);
            this.rbOneDeck.Name = "rbOneDeck";
            this.rbOneDeck.Size = new System.Drawing.Size(158, 24);
            this.rbOneDeck.TabIndex = 2;
            this.rbOneDeck.TabStop = true;
            this.rbOneDeck.Text = "Однопалубные : 4.";
            this.rbOneDeck.UseVisualStyleBackColor = true;
            this.rbOneDeck.CheckedChanged += new System.EventHandler(this.rbCheckedChanged);
            // 
            // rbTwoDeck
            // 
            this.rbTwoDeck.AutoSize = true;
            this.rbTwoDeck.Location = new System.Drawing.Point(17, 56);
            this.rbTwoDeck.Name = "rbTwoDeck";
            this.rbTwoDeck.Size = new System.Drawing.Size(153, 24);
            this.rbTwoDeck.TabIndex = 3;
            this.rbTwoDeck.TabStop = true;
            this.rbTwoDeck.Text = "Двухпалубные : 3.";
            this.rbTwoDeck.UseVisualStyleBackColor = true;
            this.rbTwoDeck.CheckedChanged += new System.EventHandler(this.rbCheckedChanged);
            // 
            // gbShipType
            // 
            this.gbShipType.Controls.Add(this.rbFourDeck);
            this.gbShipType.Controls.Add(this.rbThreeDeck);
            this.gbShipType.Controls.Add(this.rbOneDeck);
            this.gbShipType.Controls.Add(this.rbTwoDeck);
            this.gbShipType.Location = new System.Drawing.Point(32, 537);
            this.gbShipType.Name = "gbShipType";
            this.gbShipType.Size = new System.Drawing.Size(375, 90);
            this.gbShipType.TabIndex = 4;
            this.gbShipType.TabStop = false;
            this.gbShipType.Text = "Тип корабля";
            // 
            // rbFourDeck
            // 
            this.rbFourDeck.AutoSize = true;
            this.rbFourDeck.Location = new System.Drawing.Point(181, 56);
            this.rbFourDeck.Name = "rbFourDeck";
            this.rbFourDeck.Size = new System.Drawing.Size(180, 24);
            this.rbFourDeck.TabIndex = 5;
            this.rbFourDeck.TabStop = true;
            this.rbFourDeck.Text = "Четырёхпалубные : 1.";
            this.rbFourDeck.UseVisualStyleBackColor = true;
            this.rbFourDeck.CheckedChanged += new System.EventHandler(this.rbCheckedChanged);
            // 
            // rbThreeDeck
            // 
            this.rbThreeDeck.AutoSize = true;
            this.rbThreeDeck.Location = new System.Drawing.Point(181, 26);
            this.rbThreeDeck.Name = "rbThreeDeck";
            this.rbThreeDeck.Size = new System.Drawing.Size(153, 24);
            this.rbThreeDeck.TabIndex = 4;
            this.rbThreeDeck.TabStop = true;
            this.rbThreeDeck.Text = "Трёхпалубные : 2.";
            this.rbThreeDeck.UseVisualStyleBackColor = true;
            this.rbThreeDeck.CheckedChanged += new System.EventHandler(this.rbCheckedChanged);
            // 
            // gbShipPosition
            // 
            this.gbShipPosition.Controls.Add(this.rbHorizontal);
            this.gbShipPosition.Controls.Add(this.rbVertical);
            this.gbShipPosition.Location = new System.Drawing.Point(429, 537);
            this.gbShipPosition.Name = "gbShipPosition";
            this.gbShipPosition.Size = new System.Drawing.Size(160, 90);
            this.gbShipPosition.TabIndex = 5;
            this.gbShipPosition.TabStop = false;
            this.gbShipPosition.Text = "Расположение";
            // 
            // rbHorizontal
            // 
            this.rbHorizontal.AutoSize = true;
            this.rbHorizontal.Location = new System.Drawing.Point(12, 56);
            this.rbHorizontal.Name = "rbHorizontal";
            this.rbHorizontal.Size = new System.Drawing.Size(145, 24);
            this.rbHorizontal.TabIndex = 1;
            this.rbHorizontal.Text = "Горизонтальное";
            this.rbHorizontal.UseVisualStyleBackColor = true;
            this.rbHorizontal.CheckedChanged += new System.EventHandler(this.rbVertical_CheckedChanged);
            // 
            // rbVertical
            // 
            this.rbVertical.AutoSize = true;
            this.rbVertical.Checked = true;
            this.rbVertical.Location = new System.Drawing.Point(12, 31);
            this.rbVertical.Name = "rbVertical";
            this.rbVertical.Size = new System.Drawing.Size(128, 24);
            this.rbVertical.TabIndex = 0;
            this.rbVertical.TabStop = true;
            this.rbVertical.Text = "Вертикальное";
            this.rbVertical.UseVisualStyleBackColor = true;
            this.rbVertical.CheckedChanged += new System.EventHandler(this.rbVertical_CheckedChanged);
            // 
            // btSatrtGame
            // 
            this.btSatrtGame.Enabled = false;
            this.btSatrtGame.Location = new System.Drawing.Point(779, 550);
            this.btSatrtGame.Name = "btSatrtGame";
            this.btSatrtGame.Size = new System.Drawing.Size(132, 50);
            this.btSatrtGame.TabIndex = 6;
            this.btSatrtGame.Text = "Начать игру";
            this.btSatrtGame.UseVisualStyleBackColor = true;
            this.btSatrtGame.Click += new System.EventHandler(this.btStartGame_Clicked);
            // 
            // btRandomShipSet
            // 
            this.btRandomShipSet.Location = new System.Drawing.Point(627, 550);
            this.btRandomShipSet.Name = "btRandomShipSet";
            this.btRandomShipSet.Size = new System.Drawing.Size(124, 50);
            this.btRandomShipSet.TabIndex = 7;
            this.btRandomShipSet.Text = "Случайная растановка";
            this.btRandomShipSet.UseVisualStyleBackColor = true;
            this.btRandomShipSet.Click += new System.EventHandler(this.btRandomShipSet_Click);
            // 
            // btRestartGame
            // 
            this.btRestartGame.Location = new System.Drawing.Point(627, 616);
            this.btRestartGame.Name = "btRestartGame";
            this.btRestartGame.Size = new System.Drawing.Size(124, 45);
            this.btRestartGame.TabIndex = 8;
            this.btRestartGame.Text = "Начать заново";
            this.btRestartGame.UseVisualStyleBackColor = true;
            this.btRestartGame.Click += new System.EventHandler(this.btRestartGame_Click);
            // 
            // btMoveBack
            // 
            this.btMoveBack.Enabled = false;
            this.btMoveBack.Location = new System.Drawing.Point(779, 616);
            this.btMoveBack.Name = "btMoveBack";
            this.btMoveBack.Size = new System.Drawing.Size(132, 45);
            this.btMoveBack.TabIndex = 9;
            this.btMoveBack.Text = "Ход назад";
            this.btMoveBack.UseVisualStyleBackColor = true;
            this.btMoveBack.Click += new System.EventHandler(this.btMoveBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(578, 485);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 41);
            this.label1.TabIndex = 10;
            this.label1.Text = "Поле противника";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(179, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 41);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ваше поле";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbStatus.Location = new System.Drawing.Point(69, 641);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(338, 50);
            this.lbStatus.TabIndex = 12;
            this.lbStatus.Text = "Расставте корабли";
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(976, 713);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btMoveBack);
            this.Controls.Add(this.btRestartGame);
            this.Controls.Add(this.btRandomShipSet);
            this.Controls.Add(this.btSatrtGame);
            this.Controls.Add(this.gbShipPosition);
            this.Controls.Add(this.gbShipType);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Player";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Морской бой";
            this.Load += new System.EventHandler(this.Player1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbShipType.ResumeLayout(false);
            this.gbShipType.PerformLayout();
            this.gbShipPosition.ResumeLayout(false);
            this.gbShipPosition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private RadioButton rbOneDeck;
        private RadioButton rbTwoDeck;
        private GroupBox gbShipType;
        private RadioButton rbFourDeck;
        private RadioButton rbThreeDeck;
        private GroupBox gbShipPosition;
        private RadioButton rbHorizontal;
        private RadioButton rbVertical;
        private Button btSatrtGame;
        private Button btRandomShipSet;
        private Button btRestartGame;
        private Button btMoveBack;
        private Label label1;
        private Label label2;
        private Label lbStatus;
    }

    public enum GameMode
    {
        ShipEditingMode,
        PlayingMode
    }
}