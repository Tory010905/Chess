namespace Chess_IHopeLastOne
{
    partial class ChessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessForm));
            this.chessPictureBox = new System.Windows.Forms.PictureBox();
            this.pawnChoiceBoxKnight = new System.Windows.Forms.PictureBox();
            this.pawnChoiceBoxQueen = new System.Windows.Forms.PictureBox();
            this.pawnChoiceBoxBishop = new System.Windows.Forms.PictureBox();
            this.pawnChoiceBoxRook = new System.Windows.Forms.PictureBox();
            this.EndGameLabel = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.turnLogListBox = new System.Windows.Forms.ListBox();
            this.undoMoveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chessPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChoiceBoxKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChoiceBoxQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChoiceBoxBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChoiceBoxRook)).BeginInit();
            this.SuspendLayout();
            // 
            // chessPictureBox
            // 
            this.chessPictureBox.Location = new System.Drawing.Point(44, 27);
            this.chessPictureBox.Name = "chessPictureBox";
            this.chessPictureBox.Size = new System.Drawing.Size(400, 400);
            this.chessPictureBox.TabIndex = 0;
            this.chessPictureBox.TabStop = false;
            this.chessPictureBox.Click += new System.EventHandler(this.chessPictureBox_Click);
            this.chessPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.chessPictureBox_Paint);
            // 
            // pawnChoiceBoxKnight
            // 
            this.pawnChoiceBoxKnight.Location = new System.Drawing.Point(473, 27);
            this.pawnChoiceBoxKnight.Name = "pawnChoiceBoxKnight";
            this.pawnChoiceBoxKnight.Size = new System.Drawing.Size(78, 78);
            this.pawnChoiceBoxKnight.TabIndex = 5;
            this.pawnChoiceBoxKnight.TabStop = false;
            this.pawnChoiceBoxKnight.Click += new System.EventHandler(this.pawnChoiceBoxKnight_Click);
            // 
            // pawnChoiceBoxQueen
            // 
            this.pawnChoiceBoxQueen.Location = new System.Drawing.Point(575, 111);
            this.pawnChoiceBoxQueen.Name = "pawnChoiceBoxQueen";
            this.pawnChoiceBoxQueen.Size = new System.Drawing.Size(78, 78);
            this.pawnChoiceBoxQueen.TabIndex = 6;
            this.pawnChoiceBoxQueen.TabStop = false;
            this.pawnChoiceBoxQueen.Click += new System.EventHandler(this.pawnChoiceBoxQueen_Click);
            // 
            // pawnChoiceBoxBishop
            // 
            this.pawnChoiceBoxBishop.Location = new System.Drawing.Point(575, 27);
            this.pawnChoiceBoxBishop.Name = "pawnChoiceBoxBishop";
            this.pawnChoiceBoxBishop.Size = new System.Drawing.Size(78, 78);
            this.pawnChoiceBoxBishop.TabIndex = 7;
            this.pawnChoiceBoxBishop.TabStop = false;
            this.pawnChoiceBoxBishop.Click += new System.EventHandler(this.pawnChoiceBoxBishop_Click);
            // 
            // pawnChoiceBoxRook
            // 
            this.pawnChoiceBoxRook.Location = new System.Drawing.Point(473, 111);
            this.pawnChoiceBoxRook.Name = "pawnChoiceBoxRook";
            this.pawnChoiceBoxRook.Size = new System.Drawing.Size(78, 78);
            this.pawnChoiceBoxRook.TabIndex = 8;
            this.pawnChoiceBoxRook.TabStop = false;
            this.pawnChoiceBoxRook.Click += new System.EventHandler(this.pawnChoiceBoxRook_Click);
            // 
            // EndGameLabel
            // 
            this.EndGameLabel.AutoSize = true;
            this.EndGameLabel.Location = new System.Drawing.Point(485, 391);
            this.EndGameLabel.Name = "EndGameLabel";
            this.EndGameLabel.Size = new System.Drawing.Size(0, 13);
            this.EndGameLabel.TabIndex = 9;
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(69, 433);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(161, 23);
            this.restartButton.TabIndex = 11;
            this.restartButton.Text = "New Game";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // turnLogListBox
            // 
            this.turnLogListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.turnLogListBox.FormattingEnabled = true;
            this.turnLogListBox.ItemHeight = 29;
            this.turnLogListBox.Location = new System.Drawing.Point(460, 208);
            this.turnLogListBox.Name = "turnLogListBox";
            this.turnLogListBox.Size = new System.Drawing.Size(212, 207);
            this.turnLogListBox.TabIndex = 12;
            // 
            // undoMoveButton
            // 
            this.undoMoveButton.Enabled = false;
            this.undoMoveButton.Location = new System.Drawing.Point(256, 433);
            this.undoMoveButton.Name = "undoMoveButton";
            this.undoMoveButton.Size = new System.Drawing.Size(168, 23);
            this.undoMoveButton.TabIndex = 13;
            this.undoMoveButton.Text = "Undo Move";
            this.undoMoveButton.UseVisualStyleBackColor = true;
            this.undoMoveButton.Click += new System.EventHandler(this.undoMoveButton_Click);
            // 
            // ChessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.undoMoveButton);
            this.Controls.Add(this.turnLogListBox);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.EndGameLabel);
            this.Controls.Add(this.pawnChoiceBoxRook);
            this.Controls.Add(this.pawnChoiceBoxBishop);
            this.Controls.Add(this.pawnChoiceBoxQueen);
            this.Controls.Add(this.pawnChoiceBoxKnight);
            this.Controls.Add(this.chessPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "ChessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.ChessForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chessPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChoiceBoxKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChoiceBoxQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChoiceBoxBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pawnChoiceBoxRook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox chessPictureBox;
        private System.Windows.Forms.PictureBox pawnChoiceBoxKnight;
        private System.Windows.Forms.PictureBox pawnChoiceBoxQueen;
        private System.Windows.Forms.PictureBox pawnChoiceBoxBishop;
        private System.Windows.Forms.PictureBox pawnChoiceBoxRook;
        private System.Windows.Forms.Label EndGameLabel;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.ListBox turnLogListBox;
        private System.Windows.Forms.Button undoMoveButton;
    }
}

