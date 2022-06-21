using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_IHopeLastOne
{
    public partial class ChessForm : Form
    {
        ChessBoard chessBoard = new ChessBoard(50, 8);
        Game game = new Game();
        Graphics g;
        private bool Warning;
        private bool AreYouSure;

        public ChessForm()
        {
            InitializeComponent();
        }

        //zaznamená kolo do zápisu
        public void TurnLogUpdate()
        {
            if (game.EndOfTurn)
            {
                turnLogListBox.Items.Add(game.EndOfTurnMessage);
                turnLogListBox.TopIndex = turnLogListBox.Items.Count - 1;
                game.EndOfTurnMessage = null;
                game.EndOfTurn = false;
            }
        }

        //Resetuje obrázky u výměny pěšáka
        public void ResetPictures()
        {
            this.pawnChoiceBoxKnight.Image = null;
            this.pawnChoiceBoxBishop.Image = null;
            this.pawnChoiceBoxRook.Image = null;
            this.pawnChoiceBoxQueen.Image = null;
            game.PawnIsBeingPromoted = false;
            Warning = false;
        }

        private void chessPictureBox_Click(object sender, EventArgs e)
        {
            AreYouSure = false;
            restartButton.Text = "New Game";
            MouseEventArgs location = (MouseEventArgs)e;
            if (!game.PublicGameOver)
            {
                if (!game.PawnIsBeingPromoted)
                {
                    game.ChooseWhatToDo(chessBoard, g, location.X, location.Y);
                    if (game.PawnIsBeingPromoted)
                    {
                        this.pawnChoiceBoxKnight.Image = game.PawnChoiceKnight;
                        this.pawnChoiceBoxBishop.Image = game.PawnChoiceBishop;
                        this.pawnChoiceBoxRook.Image = game.PawnChoiceRook;
                        this.pawnChoiceBoxQueen.Image = game.PawnChoiceQueen;
                    }
                    TurnLogUpdate();
                    if (game.PublicGameOver)
                    {
                        turnLogListBox.Items.Add(game.WinMessage);
                        turnLogListBox.TopIndex = turnLogListBox.Items.Count - 1;
                    } 
                    if (game.UndoMovePossibility)
                        undoMoveButton.Enabled = true;
                }
                else
                {
                    if (Warning)
                    {

                        this.pawnChoiceBoxKnight.Image = game.PawnChoiceKnight;
                        this.pawnChoiceBoxBishop.Image = game.PawnChoiceBishop;
                        this.pawnChoiceBoxRook.Image = game.PawnChoiceRook;
                        this.pawnChoiceBoxQueen.Image = game.PawnChoiceQueen;
                        Warning = false;
                    }
                    else
                    {
                        this.pawnChoiceBoxKnight.Image = game.PawnChoiceHighlightedKnight;
                        this.pawnChoiceBoxBishop.Image = game.PawnChoiceHighlightedBishop;
                        this.pawnChoiceBoxRook.Image = game.PawnChoiceHighlightedRook;
                        this.pawnChoiceBoxQueen.Image = game.PawnChoiceHighlightedQueen;
                        Warning = true;
                    }
                }
            }
        }

        private void chessPictureBox_Paint(object sender, PaintEventArgs e)
        {
            game.PieceIsBeingHeld = false;
            game.RefreshBoard(chessBoard, e.Graphics);    
        }

        private void ChessForm_Load(object sender, EventArgs e)
        {
            this.g = chessPictureBox.CreateGraphics();
            game.SetGame();
            chessBoard.createBoard(g, game);
        }

        private void pawnChoiceBoxKnight_Click(object sender, EventArgs e)
        {
            if (game.PawnIsBeingPromoted)
            {
                if (game.Position[game.ClickedPositionX, game.ClickedPositionY] < 7)
                {
                   
                    game.Position[game.ClickedPositionX, game.ClickedPositionY] = 2;
                    game.RefreshTile(chessBoard, g, game.ClickedPositionX, game.ClickedPositionY);
                    game.EndOfTurn = true;
                    game.EndOfTurnMessage += "♘";
                }
                else
                {
                    game.Position[game.ClickedPositionX, game.ClickedPositionY] = 8;
                    game.RefreshTile(chessBoard, g, game.ClickedPositionX, game.ClickedPositionY);
                    game.EndOfTurn = true;
                    game.EndOfTurnMessage += "♞";
                }
                game.EndOfTurnSummary(chessBoard, g);
                TurnLogUpdate();
                ResetPictures();
                if (game.PublicGameOver)
                {
                    turnLogListBox.Items.Add(game.WinMessage);
                    turnLogListBox.TopIndex = turnLogListBox.Items.Count - 1;
                }
                if (game.UndoMovePossibility)
                    undoMoveButton.Enabled = true;
            }
        }

        private void pawnChoiceBoxBishop_Click(object sender, EventArgs e)
        {
            if (game.PawnIsBeingPromoted)
            {
                if (game.Position[game.ClickedPositionX, game.ClickedPositionY] < 7)
                {

                    game.Position[game.ClickedPositionX, game.ClickedPositionY] = 3;
                    game.RefreshTile(chessBoard, g, game.ClickedPositionX, game.ClickedPositionY);
                    game.EndOfTurn = true;
                    game.EndOfTurnMessage += "♗";
                }
                else
                {
                    game.Position[game.ClickedPositionX, game.ClickedPositionY] = 9;
                    game.RefreshTile(chessBoard, g, game.ClickedPositionX, game.ClickedPositionY);
                    game.EndOfTurn = true;
                    game.EndOfTurnMessage += "♝";
                }
                game.EndOfTurnSummary(chessBoard, g);
                TurnLogUpdate();
                ResetPictures();
                if (game.PublicGameOver)
                {
                    turnLogListBox.Items.Add(game.WinMessage);
                    turnLogListBox.TopIndex = turnLogListBox.Items.Count - 1;
                }
                if (game.UndoMovePossibility)
                    undoMoveButton.Enabled = true;
            }
        }

        private void pawnChoiceBoxRook_Click(object sender, EventArgs e)
        {
            if (game.PawnIsBeingPromoted)
            {
                if (game.Position[game.ClickedPositionX, game.ClickedPositionY] < 7)
                {

                    game.Position[game.ClickedPositionX, game.ClickedPositionY] = 4;
                    game.RefreshTile(chessBoard, g, game.ClickedPositionX, game.ClickedPositionY);
                    game.EndOfTurn = true;
                    game.EndOfTurnMessage += "♖";
                }
                else
                {
                    game.Position[game.ClickedPositionX, game.ClickedPositionY] = 10;
                    game.RefreshTile(chessBoard, g, game.ClickedPositionX, game.ClickedPositionY);
                    game.EndOfTurn = true;
                    game.EndOfTurnMessage += "♜";
                }
                game.EndOfTurnSummary(chessBoard, g);
                TurnLogUpdate();
                ResetPictures();
                if (game.PublicGameOver)
                {
                    turnLogListBox.Items.Add(game.WinMessage);
                    turnLogListBox.TopIndex = turnLogListBox.Items.Count - 1;
                }
                if (game.UndoMovePossibility)
                    undoMoveButton.Enabled = true;
            }
        }

        private void pawnChoiceBoxQueen_Click(object sender, EventArgs e)
        {
            if (game.PawnIsBeingPromoted)
            {
                if (game.Position[game.ClickedPositionX, game.ClickedPositionY] < 7)
                {

                    game.Position[game.ClickedPositionX, game.ClickedPositionY] = 5;
                    game.RefreshTile(chessBoard, g, game.ClickedPositionX, game.ClickedPositionY);
                    game.EndOfTurn = true;
                    game.EndOfTurnMessage += "♕";
                }
                else
                {
                    game.Position[game.ClickedPositionX, game.ClickedPositionY] = 11;
                    game.RefreshTile(chessBoard, g, game.ClickedPositionX, game.ClickedPositionY);
                    game.EndOfTurn = true;
                    game.EndOfTurnMessage += "♛";
                }
                game.EndOfTurnSummary(chessBoard, g);
                TurnLogUpdate();
                ResetPictures();
                if (game.PublicGameOver)
                {
                    turnLogListBox.Items.Add(game.WinMessage);
                    turnLogListBox.TopIndex = turnLogListBox.Items.Count - 1;
                }
                if (game.UndoMovePossibility)
                    undoMoveButton.Enabled = true;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (AreYouSure | game.PublicGameOver)
            {
                AreYouSure = false;
                undoMoveButton.Enabled = false;
                restartButton.Text = "New Game";
                turnLogListBox.Items.Clear();
                ResetPictures();
                game.SetGame();
                chessBoard.createBoard(g, game);
            }
            else
            {
                AreYouSure = true;
                restartButton.Text = "Are you sure?";
            }
        }

        private void undoMoveButton_Click(object sender, EventArgs e)
        {
            ResetPictures();
            game.PublicGameOver = false;
            game.PawnIsBeingPromoted = false;
            game.TurnNumber -= 1;
            turnLogListBox.Items.RemoveAt(turnLogListBox.Items.Count - 1);
            game.UndoMove(chessBoard, g, game.TypeOfMove);
            undoMoveButton.Enabled = false;
            game.UndoMovePossibility = false;
        }
    }
}
