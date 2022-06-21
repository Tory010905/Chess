using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess_IHopeLastOne
{
    class Game
    {
        public int TurnNumber { get; set; }
        public int[,] Position = new int[8, 8];
        private int BlackKingPositionX;
        private int BlackKingPositionY;
        private int WhiteKingPositionX;
        private int WhiteKingPositionY;
        private bool WhiteLongCastlingPossibility = true;
        private bool WhiteShortCastlingPossibility = true;
        private bool BlackLongCastlingPossibility = true;
        private bool BlackShortCastlingPossibility = true;
        public int ClickedPositionX;
        public int ClickedPositionY;
        public int HeldPositionX;
        public int HeldPositionY;
        public Bitmap CurrentWhiteImage;
        public Bitmap CurrentBlackImage;
        public Bitmap CurrentHighlightedWhiteImage;
        public Bitmap CurrentHighlightedBlackImage;
        public Bitmap PawnChoiceKnight;
        public Bitmap PawnChoiceBishop;
        public Bitmap PawnChoiceRook;
        public Bitmap PawnChoiceQueen;
        public Bitmap PawnChoiceHighlightedKnight;
        public Bitmap PawnChoiceHighlightedBishop;
        public Bitmap PawnChoiceHighlightedRook;
        public Bitmap PawnChoiceHighlightedQueen;
        private bool[,] TileIsBeingAttacked = new bool[8,8];
        public bool PieceIsBeingHeld;
        public bool PawnIsBeingPromoted;
        private int tempPieceHeld;
        private int tempPieceClick;
        private bool[] IsKingAttackedFromDirection= new bool[8];
        private bool HideHighlights;
        private int NumbOfMoves;
        public bool EndOfTurn;
        public string EndOfTurnMessage;
        private bool[] EntPassant = new bool[8];
        private string CurrentPieceIcon;
        /// <summary>
        /// 0 = HeldX, 1 = HeldY, 2 = Position[HeldX, HeldY], 3 = ClickX, 4 = ClickY, 5 = Position[ClickX, ClickY], 
        /// 6 = proběhl en passant?, 7 = en passant 
        /// </summary>
        private int[] LastTurn = new int[8];
        private bool[] LastTurnCastling = new bool[4];
        public int TypeOfMove;
        public bool UndoMovePossibility;
        public bool PublicGameOver;
        public string WinMessage;

        private Bitmap WhiteTile = new Bitmap(Properties.Resources.whiteTile);
        private Bitmap WhiteTile_Higlighted = new Bitmap(Properties.Resources.whiteTile_highlighted);
        private Bitmap BlackTile = new Bitmap(Properties.Resources.blackTile);
        private Bitmap BlackTile_Highlighted = new Bitmap(Properties.Resources.blackTile_highlighted);

        private Bitmap WhitePawn_White = new Bitmap(Properties.Resources.whitePawn_white);
        private Bitmap WhitePawn_Black = new Bitmap(Properties.Resources.whitePawn_black);
        private Bitmap WhitePawn_HighlightedWhite = new Bitmap(Properties.Resources.whitePawn_highlightedWhite);
        private Bitmap WhitePawn_HighlightedBlack = new Bitmap(Properties.Resources.whitePawn_highlightedBlack);

        private Bitmap BlackPawn_White = new Bitmap(Properties.Resources.blackPawn_white);
        private Bitmap BlackPawn_Black = new Bitmap(Properties.Resources.blackPawn_black);
        private Bitmap BlackPawn_HighlightedWhite = new Bitmap(Properties.Resources.blackPawn_highlightedWhite);
        private Bitmap BlackPawn_HighlightedBlack = new Bitmap(Properties.Resources.blackPawn_highlightedBlack);

        public Bitmap WhiteKnight_White = new Bitmap(Properties.Resources.whiteKnight_white);
        public Bitmap WhiteKnight_Black = new Bitmap(Properties.Resources.whiteKnight_black);
        public Bitmap WhiteKnight_HighlightedWhite = new Bitmap(Properties.Resources.whiteKnight_highlightedWhite);
        public Bitmap WhiteKnight_HighlightedBlack = new Bitmap(Properties.Resources.whiteKnight_highlightedBlack);
        public Bitmap BlackKnight_White = new Bitmap(Properties.Resources.blackKnight_white);
        public Bitmap BlackKnight_Black = new Bitmap(Properties.Resources.blackKnight_black);
        public Bitmap BlackKnight_HighlightedWhite = new Bitmap(Properties.Resources.blackKnight_highlightedWhite);
        public Bitmap BlackKnight_HighlightedBlack = new Bitmap(Properties.Resources.blackKnight_highlightedBlack);

        public Bitmap WhiteBishop_White = new Bitmap(Properties.Resources.whiteBishop_white);
        public Bitmap WhiteBishop_Black = new Bitmap(Properties.Resources.whiteBishop_black);
        public Bitmap WhiteBishop_HighligtedWhite = new Bitmap(Properties.Resources.whiteBishop_highlightedWhite);
        public Bitmap WhiteBishop_HighligtedBlack = new Bitmap(Properties.Resources.whiteBishop_highlightedBlack);
        public Bitmap BlackBishop_White = new Bitmap(Properties.Resources.blackBishop_white);
        public Bitmap BlackBishop_Black = new Bitmap(Properties.Resources.blackBishop_black);
        public Bitmap BlackBishop_HighlightedWhite = new Bitmap(Properties.Resources.blackBishop_highlightedWhite);
        public Bitmap BlackBishop_HighlightedBlack = new Bitmap(Properties.Resources.blackBishop_highlightedBlack);

        public Bitmap WhiteRook_White = new Bitmap(Properties.Resources.whiteRook_white);
        public Bitmap WhiteRook_Black = new Bitmap(Properties.Resources.whiteRook_black);
        public Bitmap WhiteRook_HighlightedWhite = new Bitmap(Properties.Resources.whiteRook_highlightedWhite);
        public Bitmap WhiteRook_HighlightedBlack = new Bitmap(Properties.Resources.whiteRook_highlightedBlack);
        public Bitmap BlackRook_White = new Bitmap(Properties.Resources.blackRook_white);
        public Bitmap BlackRook_Black = new Bitmap(Properties.Resources.blackRook_black);
        public Bitmap BlackRook_HighlightedWhite = new Bitmap(Properties.Resources.blackRook_highlightedWhite);
        public Bitmap BlackRook_HighlightedBlack = new Bitmap(Properties.Resources.blackRook_highlightedBlack);

        public Bitmap WhiteQueen_White = new Bitmap(Properties.Resources.whiteQueen_white);
        public Bitmap WhiteQueen_Black = new Bitmap(Properties.Resources.whiteQueen_black);
        public Bitmap WhiteQueen_HighlightedWhite = new Bitmap(Properties.Resources.whiteQueen_highlightedWhite);
        public Bitmap WhiteQueen_HighlightedBlack = new Bitmap(Properties.Resources.whiteQueen_highlightedBlack);
        public Bitmap BlackQueen_White = new Bitmap(Properties.Resources.blackQueen_white);
        public Bitmap BlackQueen_Black = new Bitmap(Properties.Resources.blackQueen_black);
        public Bitmap BlackQueen_HighlightedWhite = new Bitmap(Properties.Resources.blackQueen_highlightedWhite);
        public Bitmap BlackQueen_HighlightedBlack = new Bitmap(Properties.Resources.blackQueen_highlightedBlack);

        private Bitmap WhiteKing_White = new Bitmap(Properties.Resources.whiteKing_white);
        private Bitmap WhiteKing_Black = new Bitmap(Properties.Resources.whiteKing_black);
        private Bitmap WhiteKing_HighlightedWhite = new Bitmap(Properties.Resources.whiteKing_highlightedWhite);
        private Bitmap WhiteKing_HighlightedBlack = new Bitmap(Properties.Resources.whiteKing_highlightedBlack);
        private Bitmap BlackKing_White = new Bitmap(Properties.Resources.blackKing_white);
        private Bitmap BlackKing_Black = new Bitmap(Properties.Resources.blackKing_black);
        private Bitmap BlackKing_HighlightedWhite = new Bitmap(Properties.Resources.blackKing_highlightedWhite);
        private Bitmap BlackKing_HighlightedBlack = new Bitmap(Properties.Resources.blackKing_highlightedBlack);

        //Nalezení obrázků k dané figurce
        public void GetChessPiece(int X, int Y)
        {
            if (IsInTheBounds(X,Y)) 
            {
                switch (Position[X, Y])
                {
                    //Default
                    case 0:
                        CurrentWhiteImage = WhiteTile;
                        CurrentBlackImage = BlackTile;
                        CurrentHighlightedWhiteImage = WhiteTile_Higlighted;
                        CurrentHighlightedBlackImage = BlackTile_Highlighted;
                        CurrentPieceIcon = null;
                        break;

                    //White Pawn
                    case 1:
                        CurrentWhiteImage = WhitePawn_White;
                        CurrentBlackImage = WhitePawn_Black;
                        CurrentHighlightedWhiteImage = WhitePawn_HighlightedWhite;
                        CurrentHighlightedBlackImage = WhitePawn_HighlightedBlack;
                        CurrentPieceIcon = "♙";
                        break;

                    //White Knight
                    case 2:
                        CurrentWhiteImage = WhiteKnight_White;
                        CurrentBlackImage = WhiteKnight_Black;
                        CurrentHighlightedWhiteImage = WhiteKnight_HighlightedWhite;
                        CurrentHighlightedBlackImage = WhiteKnight_HighlightedBlack;
                        CurrentPieceIcon = "♘";
                        break;

                    //White Bishop
                    case 3:
                        CurrentWhiteImage = WhiteBishop_White;
                        CurrentBlackImage = WhiteBishop_Black;
                        CurrentHighlightedWhiteImage = WhiteBishop_HighligtedWhite;
                        CurrentHighlightedBlackImage = WhiteBishop_HighligtedBlack;
                        CurrentPieceIcon = "♗";
                        break;

                    //White Rook
                    case 4:
                        CurrentWhiteImage = WhiteRook_White;
                        CurrentBlackImage = WhiteRook_Black;
                        CurrentHighlightedWhiteImage = WhiteRook_HighlightedWhite;
                        CurrentHighlightedBlackImage = WhiteRook_HighlightedBlack;
                        CurrentPieceIcon = "♖";
                        break;

                    //White Queen
                    case 5:
                        CurrentWhiteImage = WhiteQueen_White;
                        CurrentBlackImage = WhiteQueen_Black;
                        CurrentHighlightedWhiteImage = WhiteQueen_HighlightedWhite;
                        CurrentHighlightedBlackImage = WhiteQueen_HighlightedBlack;
                        CurrentPieceIcon = "♕";
                        break;

                    //White King
                    case 6:
                        CurrentWhiteImage = WhiteKing_White;
                        CurrentBlackImage = WhiteKing_Black;
                        CurrentHighlightedWhiteImage = WhiteKing_HighlightedWhite;
                        CurrentHighlightedBlackImage = WhiteKing_HighlightedBlack;
                        CurrentPieceIcon = "♔";
                        break;

                    //Black Pawn
                    case 7:
                        CurrentWhiteImage = BlackPawn_White;
                        CurrentBlackImage = BlackPawn_Black;
                        CurrentHighlightedWhiteImage = BlackPawn_HighlightedWhite;
                        CurrentHighlightedBlackImage = BlackPawn_HighlightedBlack;
                        CurrentPieceIcon = "♟";
                        break;

                    //Black Knight
                    case 8:
                        CurrentWhiteImage = BlackKnight_White;
                        CurrentBlackImage = BlackKnight_Black;
                        CurrentHighlightedWhiteImage = BlackKnight_HighlightedWhite;
                        CurrentHighlightedBlackImage = BlackKnight_HighlightedBlack;
                        CurrentPieceIcon = "♞";
                        break;

                    //Black Bishop
                    case 9:
                        CurrentWhiteImage = BlackBishop_White;
                        CurrentBlackImage = BlackBishop_Black;
                        CurrentHighlightedWhiteImage = BlackBishop_HighlightedWhite;
                        CurrentHighlightedBlackImage = BlackBishop_HighlightedBlack;
                        CurrentPieceIcon = "♝";
                        break;

                    //Black Rook
                    case 10:
                        CurrentWhiteImage = BlackRook_White;
                        CurrentBlackImage = BlackRook_Black;
                        CurrentHighlightedWhiteImage = BlackRook_HighlightedWhite;
                        CurrentHighlightedBlackImage = BlackRook_HighlightedBlack;
                        CurrentPieceIcon = "♜";
                        break;

                    //Black Queen
                    case 11:
                        CurrentWhiteImage = BlackQueen_White;
                        CurrentBlackImage = BlackQueen_Black;
                        CurrentHighlightedWhiteImage = BlackQueen_HighlightedWhite;
                        CurrentHighlightedBlackImage = BlackQueen_HighlightedBlack;
                        CurrentPieceIcon = "♛";
                        break;

                    //Black King
                    case 12:
                        CurrentWhiteImage = BlackKing_White;
                        CurrentBlackImage = BlackKing_Black;
                        CurrentHighlightedWhiteImage = BlackKing_HighlightedWhite;
                        CurrentHighlightedBlackImage = BlackKing_HighlightedBlack;
                        CurrentPieceIcon = "♚";
                        break;
                }
            }
        }

        //Zjistí, na které políčko bylo klinuto
        private void GetCoordinations(ChessBoard chessBoard, int ClickX, int ClickY)
        {
            ClickedPositionX = ClickX / chessBoard.Size;
            ClickedPositionY = ClickY / chessBoard.Size; 
        }

        //Kontrola jestli souřadníce X nebo Y není vetší než 7 nebo menší než 0, jelikož jinak by nešla dosadit do pole
        private bool IsInTheBounds(int X, int Y)
        {
            if (X < 8 && Y < 8 && X >= 0 && Y >= 0)
                return true;
            else
                return false;
        }

        //Označení figurky
        private void HighlightPiece(ChessBoard chessBoard, Graphics g, int X, int Y)
        {
            if (HideHighlights)
                 NumbOfMoves += 1;
            else
            {
                GetChessPiece(X, Y);
                if (chessBoard.IsTileBlack(X, Y))
                    g.DrawImage(CurrentHighlightedBlackImage, X * chessBoard.Size, Y * chessBoard.Size, chessBoard.Size, chessBoard.Size);
                else
                    g.DrawImage(CurrentHighlightedWhiteImage, X * chessBoard.Size, Y * chessBoard.Size, chessBoard.Size, chessBoard.Size);
            }
        }

        //Odznačení figurky
        private void UnHighlightPiece(ChessBoard chessBoard, Graphics g, int X, int Y)
        {
            GetChessPiece(X, Y);
            if (IsInTheBounds(X, Y))
            {
                if (chessBoard.IsTileBlack(X, Y))
                {
                    g.DrawImage(CurrentBlackImage, X * chessBoard.Size, Y * chessBoard.Size, chessBoard.Size, chessBoard.Size);
                }
                else
                {
                    g.DrawImage(CurrentWhiteImage, X * chessBoard.Size, Y * chessBoard.Size, chessBoard.Size, chessBoard.Size);
                }
                TileIsBeingAttacked[X, Y] = false;
            }
        }

        //Navrátí hrací plochu do stavu před kliknutím na figurku, odstraní všechny označená pole
        private void RestoreBoard(ChessBoard chessBoard, Graphics g)
        {
            for (int i = 0; i < chessBoard.GridSize; i++)
                for (int j = 0; j < chessBoard.GridSize; j++)
                    UnHighlightPiece(chessBoard, g, i, j);
        }

        //Zaútočení figurky na dané pole
        private void Attack(ChessBoard chessBoard, Graphics g, int X, int Y)
        {
            if(IsInTheBounds(X,Y))
            {
                if(Position[HeldPositionX, HeldPositionY] == 6 | Position[HeldPositionX,HeldPositionY] == 12)
                {
                    if(!IsTileAttacked(X, Y) && ((Position[HeldPositionX, HeldPositionY] > 6 && Position[X, Y] < 7) | (Position[HeldPositionX, HeldPositionY] < 7 && Position[X, Y] > 6) | Position[X, Y] == 0))
                    { 
                        HighlightPiece(chessBoard, g, X, Y);
                        TileIsBeingAttacked[X, Y] = true;
                    }
                }
                else
                {
                    tempPieceHeld = Position[HeldPositionX, HeldPositionY];
                    tempPieceClick = Position[X, Y];
                    if (Position[HeldPositionX, HeldPositionY] > 6)
                    {
                        if (Position[X, Y] < 7 | Position[X, Y] == 0)
                        {
                            Position[HeldPositionX, HeldPositionY] = 0;
                            Position[X, Y] = tempPieceHeld;
                            if (!IsTileAttacked(BlackKingPositionX, BlackKingPositionY))
                            {
                                Position[X, Y] = tempPieceClick;
                                Position[HeldPositionX, HeldPositionY] = tempPieceHeld;
                                HighlightPiece(chessBoard, g, X, Y);
                                TileIsBeingAttacked[X, Y] = true;
                            }
                            else
                            {
                                Position[X, Y] = tempPieceClick;
                                Position[HeldPositionX, HeldPositionY] = tempPieceHeld;
                            }

                        }
                    }
                    else if (Position[HeldPositionX, HeldPositionY] < 7)
                    {
                        if (Position[X, Y] > 6 | Position[X, Y] == 0)
                        {
                            Position[HeldPositionX, HeldPositionY] = 0;
                            Position[X, Y] = tempPieceHeld;
                            if (!IsTileAttacked(WhiteKingPositionX, WhiteKingPositionY))
                            {
                                Position[X, Y] = tempPieceClick;
                                Position[HeldPositionX, HeldPositionY] = tempPieceHeld;
                                HighlightPiece(chessBoard, g, X, Y);
                                TileIsBeingAttacked[X, Y] = true;
                            }
                            else
                            {
                                Position[X, Y] = tempPieceClick;
                                Position[HeldPositionX, HeldPositionY] = tempPieceHeld;
                            }
                        }
                    }
                }
                
            }
        }

        //Ukáže všechny možné pohyby danou figurkou
        public void ShowPossibleMoves(ChessBoard chessBoard, Graphics g, int X, int Y)
        {
            switch (Position[X, Y])
            {
                //Default
                case 0:
                    break;

                //White Pawns
                case 1:
                    if (IsInTheBounds(X, Y - 1))
                    {
                        if(Position[X, Y - 1] == 0)
                        {
                            Attack(chessBoard, g, X, Y - 1);
                            if (Y == 6 && Position[X, 4] == 0)
                                Attack(chessBoard, g, X, Y - 2);
                        }
                            
                    }
                    if (IsInTheBounds(X - 1, Y - 1))
                    {
                        if (Position[X - 1, Y - 1] != 0)
                            Attack(chessBoard, g, X - 1, Y - 1);
                    }
                    if(IsInTheBounds(X + 1, Y - 1))
                    {
                        if (Position[X + 1, Y - 1] != 0)
                            Attack(chessBoard, g, X + 1, Y - 1);
                    }
                    if(Y == 3)
                    {
                        if (IsInTheBounds(X + 1, Y - 1))
                            if (EntPassant[X + 1])
                                Attack(chessBoard, g, X + 1, Y - 1);
                        if (IsInTheBounds(X - 1, Y - 1))
                            if (EntPassant[X - 1])
                                Attack(chessBoard, g, X - 1, Y - 1);
                    }
                    break;

                //Black Pawns
                case 7:
                    if (IsInTheBounds(X, Y + 1))
                    {
                        if (Position[X, Y + 1] == 0)
                        {
                            Attack(chessBoard, g, X, Y + 1);
                            if (Y == 1 && Position[X, 3] == 0)
                                Attack(chessBoard, g, X, Y + 2);
                        }

                    }
                    if (IsInTheBounds(X + 1, Y + 1))
                    {
                        if (Position[X + 1, Y + 1] != 0)
                            Attack(chessBoard, g, X + 1, Y + 1);
                    }
                    if (IsInTheBounds(X - 1, Y + 1))
                    {
                        if (Position[X - 1, Y + 1] != 0)
                            Attack(chessBoard, g, X - 1, Y + 1);
                    }
                    if(Y == 4)
                    {
                        if (IsInTheBounds(X + 1, Y + 1))
                            if (EntPassant[X + 1])
                                Attack(chessBoard, g, X + 1, Y + 1);
                        if (IsInTheBounds(X - 1, Y + 1))
                            if (EntPassant[X - 1])
                                Attack(chessBoard, g, X - 1, Y + 1);
                    }
                    break;

                //Knights
                case 2:
                case 8:
                    Attack(chessBoard, g, X + 2, Y - 1);
                    Attack(chessBoard, g, X + 2, Y + 1);
                    Attack(chessBoard, g, X + 1, Y - 2);
                    Attack(chessBoard, g, X + 1, Y + 2);
                    Attack(chessBoard, g, X - 1, Y - 2);
                    Attack(chessBoard, g, X - 1, Y + 2);
                    Attack(chessBoard, g, X - 2, Y - 1);
                    Attack(chessBoard, g, X - 2, Y + 1);
                    break;

                //Bishops
                case 3:
                case 9:
                    for (int i = 1; X + i < 8; i++)
                    {
                        Attack(chessBoard, g, X + i, Y + i);
                        if(IsInTheBounds(X + i, Y + i))
                        {
                            if (Position[X + i, Y + i] != 0)
                                break;
                        }
                        
                    }
                    for (int i = 1; X + i < 8; i++)
                    {
                        Attack(chessBoard, g, X + i, Y - i);
                        if (IsInTheBounds(X + i, Y - i))
                        {
                            if (Position[X + i, Y - i] != 0)
                                break;
                        }

                    }
                    for (int i = 1; X - i >= 0; i++)
                    {
                        Attack(chessBoard, g, X - i, Y + i);
                        if (IsInTheBounds(X - i, Y + i))
                        {
                            if (Position[X - i, Y + i] != 0)
                                break;
                        }

                    }
                    for (int i = 1; X - i >= 0; i++)
                    {
                        Attack(chessBoard, g, X - i, Y - i);
                        if (IsInTheBounds(X - i, Y - i))
                        {
                            if (Position[X - i, Y - i] != 0)
                                break;
                        }

                    }
                    break;

                //Rooks
                case 4:
                case 10:
                    for (int i = 1; X + i < 8; i++)
                    {
                        Attack(chessBoard, g, X + i, Y);
                        if (IsInTheBounds(X + i, Y))
                        {
                            if (Position[X + i, Y] != 0)
                                break;
                        }

                    }
                    for (int i = 1; Y + i < 8; i++)
                    {
                        Attack(chessBoard, g, X, Y + i);
                        if (IsInTheBounds(X, Y + i))
                        {
                            if (Position[X, Y + i] != 0)
                                break;
                        }

                    }
                    for (int i = 1; X - i >= 0; i++)
                    {
                        Attack(chessBoard, g, X - i, Y);
                        if (IsInTheBounds(X - i, Y))
                        {
                            if (Position[X - i, Y] != 0)
                                break;
                        }

                    }
                    for (int i = 1; Y - i >= 0; i++)
                    {
                        Attack(chessBoard, g, X, Y - i);
                        if (IsInTheBounds(X, Y - i))
                        {
                            if (Position[X, Y - i] != 0)
                                break;
                        }

                    }
                    break;

                //Queens
                case 5:
                case 11:
                    for (int i = 1; X + i < 8; i++)
                    {
                        Attack(chessBoard, g, X + i, Y);
                        if (IsInTheBounds(X + i, Y))
                        {
                            if (Position[X + i, Y] != 0)
                                break;
                        }

                    }
                    for (int i = 1; Y + i < 8; i++)
                    {
                        Attack(chessBoard, g, X, Y + i);
                        if (IsInTheBounds(X, Y + i))
                        {
                            if (Position[X, Y + i] != 0)
                                break;
                        }

                    }
                    for (int i = 1; X - i >= 0; i++)
                    {
                        Attack(chessBoard, g, X - i, Y);
                        if (IsInTheBounds(X - i, Y))
                        {
                            if (Position[X - i, Y] != 0)
                                break;
                        }

                    }
                    for (int i = 1; Y - i >= 0; i++)
                    {
                        Attack(chessBoard, g, X, Y - i);
                        if (IsInTheBounds(X, Y - i))
                        {
                            if (Position[X, Y - i] != 0)
                                break;
                        }

                    }
                    for (int i = 1; X + i < 8; i++)
                    {
                        Attack(chessBoard, g, X + i, Y + i);
                        if (IsInTheBounds(X + i, Y + i))
                        {
                            if (Position[X + i, Y + i] != 0)
                                break;
                        }

                    }
                    for (int i = 1; X + i < 8; i++)
                    {
                        Attack(chessBoard, g, X + i, Y - i);
                        if (IsInTheBounds(X + i, Y - i))
                        {
                            if (Position[X + i, Y - i] != 0)
                                break;
                        }

                    }
                    for (int i = 1; X - i >= 0; i++)
                    {
                        Attack(chessBoard, g, X - i, Y + i);
                        if (IsInTheBounds(X - i, Y + i))
                        {
                            if (Position[X - i, Y + i] != 0)
                                break;
                        }

                    }
                    for (int i = 1; X - i >= 0; i++)
                    {
                        Attack(chessBoard, g, X - i, Y - i);
                        if (IsInTheBounds(X - i, Y - i))
                        {
                            if (Position[X - i, Y - i] != 0)
                                break;
                        }

                    }
                    break;

                //Kings
                case 6:
                case 12:
                    IsTileAttacked(X, Y);
                    if(!IsKingAttackedFromDirection[6])
                        Attack(chessBoard, g, X + 1, Y + 1);
                    if (!IsKingAttackedFromDirection[7])
                        Attack(chessBoard, g, X + 1, Y);
                    if (!IsKingAttackedFromDirection[0])
                        Attack(chessBoard, g, X + 1, Y - 1);
                    if (!IsKingAttackedFromDirection[5])
                        Attack(chessBoard, g, X, Y + 1);
                    if (!IsKingAttackedFromDirection[1])
                        Attack(chessBoard, g, X, Y - 1);
                    if (!IsKingAttackedFromDirection[4])
                        Attack(chessBoard, g, X - 1, Y + 1);
                    if (!IsKingAttackedFromDirection[3])
                        Attack(chessBoard, g, X - 1, Y);
                    if (!IsKingAttackedFromDirection[2])
                        Attack(chessBoard, g, X - 1, Y - 1);
                    CastlingAttack(chessBoard, g, X, Y);
                    break;
            }
        }
        
        //Aktualizuje obrázek políčka v případě přemístění figurek
        public void RefreshTile(ChessBoard chessBoard, Graphics g, int X, int Y)
        {
            GetChessPiece(X, Y);
            if (chessBoard.IsTileBlack(X, Y))
            {
                g.DrawImage(CurrentBlackImage, X * chessBoard.Size, Y * chessBoard.Size, chessBoard.Size, chessBoard.Size);
            }
            else
            {
                g.DrawImage(CurrentWhiteImage, X * chessBoard.Size, Y * chessBoard.Size, chessBoard.Size, chessBoard.Size);
            }
        }

        //Kontrola kdo je na tahu
        private bool IsThisPlayerOnTurn(int X, int Y)
        {
            if (((TurnNumber % 2 == 0 && Position[X, Y] > 6) | (TurnNumber % 2 != 0 && Position[X, Y] < 7)) && Position[X, Y] != 0)
                return true;
            else
                return false;
        }

        //Zjišťuje, jestli se na daném políčku nachází určitá figurka
        private bool CheckForPiece(int PieceNumber, int X, int Y)
        {
            if (IsInTheBounds(X, Y))
            {
                if ((Position[X, Y] == PieceNumber))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        //Zjišťuje, jestli je políčko napadeno pešákem
        private bool AttackedByPawn(int X, int Y)
        {
            if(GetPieceColor() < 7)
            {
                if (CheckForPiece(7, X + 1, Y - 1) | CheckForPiece(7, X - 1, Y - 1))
                    return true;
                else
                    return false;

            }
            else
            {
                if (CheckForPiece(1, X + 1, Y + 1) | CheckForPiece(1, X - 1, Y + 1))
                    return true;
                else
                    return false;
            }
        }

        //Zjišťuje, jestli je políčko napadeno jezdcem
        private bool AttackedByKnight(int X, int Y)
        {
            if (GetPieceColor() < 7)
            {
                if (CheckForPiece(8, X + 2, Y + 1) |
                    CheckForPiece(8, X + 2, Y - 1) |
                    CheckForPiece(8, X + 1, Y + 2) |
                    CheckForPiece(8, X + 1, Y - 2) |
                    CheckForPiece(8, X - 1, Y + 2) |
                    CheckForPiece(8, X - 1, Y - 2) |
                    CheckForPiece(8, X - 2, Y + 1) |
                    CheckForPiece(8, X - 2, Y - 1))
                    return true;
                else
                    return false;

            }
            else
            {
                if (CheckForPiece(2, X + 2, Y + 1) |
                    CheckForPiece(2, X + 2, Y - 1) |
                    CheckForPiece(2, X + 1, Y + 2) |
                    CheckForPiece(2, X + 1, Y - 2) |
                    CheckForPiece(2, X - 1, Y + 2) |
                    CheckForPiece(2, X - 1, Y - 2) |
                    CheckForPiece(2, X - 2, Y + 1) |
                    CheckForPiece(2, X - 2, Y - 1))
                    return true;
                else
                    return false;
            }
        }

        //Zjišťuje, jestli je políčko napadeno střelcem
        private bool AttackedByBishop(int X, int Y)
        {
            if (GetPieceColor() < 7)
            {
                for (int i = 1; X + i < 8 && Y + i < 8; i++)
                {
                    if (CheckForPiece(9, X + i, Y + i))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[2] = true;
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y + i))
                    {
                        if (Position[X + i, Y + i] != 0)
                        {
                            break;
                        }     
                    }
                }
                for (int i = 1; X + i < 8 && Y - i >= 0; i++)
                {
                    if (CheckForPiece(9, X + i, Y - i))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[4] = true;
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y - i))
                    {
                        if (Position[X + i, Y - i] != 0)
                        {
                            break;
                        }     
                    }

                }
                for (int i = 1; X - i >= 0 && Y + i < 8; i++)
                {
                    if (CheckForPiece(9, X - i, Y + i))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[0] = true;
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y + i))
                    {
                        if (Position[X - i, Y + i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; X - i >= 0 && Y - i >= 0; i++)
                {
                    if (CheckForPiece(9, X - i, Y - i))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[6] = true;
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y - i))
                    {
                        if (Position[X - i, Y - i] != 0)
                        {
                            break;
                        }
                    }
                }
                return false;

            }
            else
            {
                for (int i = 1; X + i < 8 && Y + i < 8; i++)
                {
                    if (CheckForPiece(3, X + i, Y + i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[2] = true;
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y + i))
                    {
                        if (Position[X + i, Y + i] != 0)
                        {
                            break;
                        }
                    }
                }
                for (int i = 1; X + i < 8 && Y - i >= 0; i++)
                {
                    if (CheckForPiece(3, X + i, Y - i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[4] = true;
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y - i))
                    {
                        if (Position[X + i, Y - i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; X - i >= 0 && Y + i < 8; i++)
                {
                    if (CheckForPiece(3, X - i, Y + i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[0] = true;
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y + i))
                    {
                        if (Position[X - i, Y + i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; X - i >= 0 && Y - i > 0; i++)
                {
                    if (CheckForPiece(3, X - i, Y - i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[6] = true;
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y - i))
                    {
                        if (Position[X - i, Y - i] != 0)
                        {
                            break;
                        }
                    }

                }
                return false;
            }
        }

        //Zjišťuje, jestli je políčko napadeno věží
        private bool AttackedByRook(int X, int Y)
        {
            if (GetPieceColor() < 7)
            {
                for (int i = 1; X + i < 8; i++)
                {
                    if (CheckForPiece(10, X + i, Y))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[3] = true;
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y))
                    {
                        if (Position[X + i, Y] != 0)
                        {
                            break;
                        }    
                    }

                }
                for (int i = 1; X - i >= 0; i++)
                {
                    if (CheckForPiece(10, X - i, Y))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[7] = true;
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y))
                    {
                        if (Position[X - i, Y] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; Y + i < 8; i++)
                {
                    if (CheckForPiece(10, X, Y + i))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[1] = true;
                        return true;
                    }
                    if (IsInTheBounds(X, Y + i))
                    {
                        if (Position[X, Y + i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; Y - i >= 0; i++)
                {
                    if (CheckForPiece(10, X, Y - i))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[5] = true;
                        return true;
                    }
                    if (IsInTheBounds(X, Y - i))
                    {
                        if (Position[X, Y - i] != 0)
                        {
                            break;
                        }
                    }

                }
                return false;
            }
            else
            {
                for (int i = 1; X + i < 8; i++)
                {
                    if (CheckForPiece(4, X + i, Y))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[3] = true;
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y))
                    {
                        if (Position[X + i, Y] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; X - i >= 0; i++)
                {
                    if (CheckForPiece(4, X - i, Y))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[7] = true;
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y))
                    {
                        if (Position[X - i, Y] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; Y + i < 8; i++)
                {
                    if (CheckForPiece(4, X, Y + i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[1] = true;
                        return true;
                    }
                    if (IsInTheBounds(X, Y + i))
                    {
                        if (Position[X, Y + i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; Y - i >= 0; i++)
                {
                    if (CheckForPiece(4, X, Y - i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[5] = true;
                        return true;
                    }
                    if (IsInTheBounds(X, Y - i))
                    {
                        if (Position[X, Y - i] != 0)
                        {
                            break;
                        }
                    }

                }
                return false;
            }
        }

        //Zjišťuje, jestli je políčko napadeno královnou
        private bool AttackedByQueen(int X, int Y)
        {
            if (GetPieceColor() < 7)
            {
                for (int i = 1; X + i < 8 && Y + i < 8; i++)
                {
                    if (CheckForPiece(11, X + i, Y + i))
                    {
                        if(CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[2] = true;
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y + i))
                    {
                        if (Position[X + i, Y + i] != 0)
                        {
                            break;
                        }
                    }
                }
                for (int i = 1; X + i < 8 && Y - i >= 0; i++)
                {
                    if (CheckForPiece(11, X + i, Y - i))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[4] = true;
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y - i))
                    {
                        if (Position[X + i, Y - i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; X - i >= 0 && Y + i < 8; i++)
                {
                    if (CheckForPiece(11, X - i, Y + i))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[0] = true;  
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y + i))
                    {
                        if (Position[X - i, Y + i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; X - i >= 0 && Y - i >= 0; i++)
                {
                    if (CheckForPiece(11, X - i, Y - i))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[6] = true;
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y - i))
                    {
                        if (Position[X - i, Y - i] != 0)
                        {
                            break;
                        }
                    }
                }
                for (int i = 1; X + i < 8; i++)
                {
                    if (CheckForPiece(11, X + i, Y))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[3] = true;
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y))
                    {
                        if (Position[X + i, Y] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; X - i >= 0; i++)
                {
                    if (CheckForPiece(11, X - i, Y))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[7] = true;
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y))
                    {
                        if (Position[X - i, Y] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; Y + i < 8; i++)
                {
                    if (CheckForPiece(11, X, Y + i))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[1] = true;
                        return true;
                    }
                    if (IsInTheBounds(X, Y + i))
                    {
                        if (Position[X, Y + i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; Y - i >= 0; i++)
                {
                    if (CheckForPiece(11, X, Y - i))
                    {
                        if (CheckForPiece(6, X, Y))
                            IsKingAttackedFromDirection[5] = true;
                        return true;
                    }
                    if (IsInTheBounds(X, Y - i))
                    {
                        if (Position[X, Y - i] != 0)
                        {
                            break;
                        }
                    }

                }
                return false;
            }
            else
            {
                for (int i = 1; X + i < 8 && Y + i < 8; i++)
                {
                    if (CheckForPiece(5, X + i, Y + i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[2] = true;
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y + i))
                    {
                        if (Position[X + i, Y + i] != 0)
                        {
                            break;
                        }
                    }
                }
                for (int i = 1; X + i < 8 && Y - i >= 0; i++)
                {
                    if (CheckForPiece(5, X + i, Y - i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[4] = true;
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y - i))
                    {
                        if (Position[X + i, Y - i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; X - i >= 0 && Y + i < 8 ; i++)
                {
                    if (CheckForPiece(5, X - i, Y + i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[0] = true; 
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y + i))
                    {
                        if (Position[X - i, Y + i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; X - i >= 0 && Y - 1 >= 0; i++)
                {
                    if (CheckForPiece(5, X - i, Y - i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[6] = true;
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y - i))
                    {
                        if (Position[X - i, Y - i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; X + i < 8; i++)
                {
                    if (CheckForPiece(5, X + i, Y))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[3] = true;    
                        return true;
                    }
                    if (IsInTheBounds(X + i, Y))
                    {
                        if (Position[X + i, Y] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; X - i >= 0; i++)
                {
                    if (CheckForPiece(5, X - i, Y))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[7] = true;
                        return true;
                    }
                    if (IsInTheBounds(X - i, Y))
                    {
                        if (Position[X - i, Y] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; Y + i < 8; i++)
                {
                    if (CheckForPiece(5, X, Y + i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[1] = true;
                        return true;
                    }
                    if (IsInTheBounds(X, Y + i))
                    {
                        if (Position[X, Y + i] != 0)
                        {
                            break;
                        }
                    }

                }
                for (int i = 1; Y - i >= 0; i++)
                {
                    if (CheckForPiece(5, X, Y - i))
                    {
                        if (CheckForPiece(12, X, Y))
                            IsKingAttackedFromDirection[5] = true;
                        return true;
                    }
                    if (IsInTheBounds(X, Y - i))
                    {
                        if (Position[X, Y - i] != 0)
                        {
                            break;
                        }
                    }

                }
                return false;
            }
        }

        //Zjišťuje, jestli je políčko napadeno králem
        private bool AttackedByKing(int X, int Y)
        {
            if (GetPieceColor() < 7)
            {
                if (CheckForPiece(12, X + 1, Y + 1) |
                    CheckForPiece(12, X + 1, Y) |
                    CheckForPiece(12, X + 1, Y - 1) |
                    CheckForPiece(12, X, Y + 1) |
                    CheckForPiece(12, X, Y - 1) |
                    CheckForPiece(12, X - 1, Y + 1) |
                    CheckForPiece(12, X - 1, Y) |
                    CheckForPiece(12, X - 1, Y - 1))
                    return true;
                else
                    return false;

            }
            else
            {
                if (CheckForPiece(6, X + 1, Y + 1) |
                    CheckForPiece(6, X + 1, Y) |
                    CheckForPiece(6, X + 1, Y - 1) |
                    CheckForPiece(6, X, Y + 1) |
                    CheckForPiece(6, X, Y - 1) |
                    CheckForPiece(6, X - 1, Y + 1) |
                    CheckForPiece(6, X - 1, Y) |
                    CheckForPiece(6, X - 1, Y - 1))
                    return true;
                else
                    return false;
            }
        }

        //Průnik všech předchozích AttackecBy boolů
        private bool IsTileAttacked(int X, int Y)
        {
            if (AttackedByPawn(X, Y) | AttackedByKnight(X, Y) | AttackedByBishop(X, Y) | AttackedByRook(X, Y) | AttackedByQueen(X, Y) | AttackedByKing(X, Y))
                return true;
            else
                return false;
        }

        //Metoda, kterou používám k určení barvy figurky u AttackedBy metod
        private int GetPieceColor()
        {
            if (Position[HeldPositionX, HeldPositionY] == 0)
                return tempPieceHeld;
            else
                return Position[HeldPositionX, HeldPositionY];
        }

        //Funguje podobně jako metoda Attack, ale na rošádu
        private void CastlingAttack(ChessBoard chessBoard, Graphics g, int X, int Y)
        {
            if (X == 4)
            {
                if (Y == 7)
                {
                    if (!(IsTileAttacked(4, 7)))
                    {
                        if (WhiteLongCastlingPossibility && Position[1, 7] == 0 && Position[2, 7] == 0 && Position[3, 7] == 0 && !IsTileAttacked(2, 7)&& !IsTileAttacked(3, 7) && !IsTileAttacked(4, 7))
                        {
                            Attack(chessBoard, g, 2, 7);
                            TileIsBeingAttacked[2, 7] = false;
                        }
                        if (WhiteShortCastlingPossibility && Position[5, 7] == 0 && Position[6, 7] == 0 && !IsTileAttacked(5, 7) && !IsTileAttacked(6, 7) && !IsTileAttacked(4, 7))
                        {
                            Attack(chessBoard, g, 6, 7);
                            TileIsBeingAttacked[6, 7] = false;
                        }

                    }
                }
                else if (Y == 0)
                {
                    if (!(IsTileAttacked(4, 0)))
                    {
                        if (BlackLongCastlingPossibility && Position[1, 0] == 0 && Position[2, 0] == 0 && Position[3, 0] == 0 && !IsTileAttacked(2, 0) && !IsTileAttacked(3, 0) && !IsTileAttacked(4, 0))
                        {
                            Attack(chessBoard, g, 2, 0);
                            TileIsBeingAttacked[2, 0] = false;
                        }   
                        if (BlackShortCastlingPossibility && Position[5, 0] == 0 && Position[6, 0] == 0 && !IsTileAttacked(5, 0) && !IsTileAttacked(6, 0) && !IsTileAttacked(4, 0))
                        {
                            Attack(chessBoard, g, 6, 0);
                            TileIsBeingAttacked[6, 0] = false;
                        }
                           
                    }
                }
            }
        }

        //Aktualizuje, jestli je rošáda stále možná (konkrétně jestli se králové nebo věže nepohnuli)
        private void CastlingPosibilityUpdate(int X, int Y)
        {
            if (Position[X, Y] < 7)
            {
                if (X == 0 && Y == 7)
                    WhiteLongCastlingPossibility = false;
                if (X == 7 && Y == 7)
                    WhiteShortCastlingPossibility = false;
                if (X == 4 && Y == 7)
                {
                    WhiteLongCastlingPossibility = false;
                    WhiteShortCastlingPossibility = false;
                }
            }
            else
            {
                if (X == 0 && Y == 0)
                    BlackLongCastlingPossibility = false;
                if (X == 7 && Y == 0)
                    BlackShortCastlingPossibility = false;
                if (X == 4 && Y == 0)
                {
                    BlackLongCastlingPossibility = false;
                    BlackShortCastlingPossibility = false;
                }
            }
        }

        //Zjišťuje jestli probíhá dlouhá bílá rošáda 
        private bool WhiteLongCastling(int HeldX, int HeldY, int ClickX)
        {
            if (HeldX == 4 && HeldY == 7 && ClickX == 2 && WhiteLongCastlingPossibility && Position[1, 7] == 0 && Position[2, 7] == 0 && Position[3, 7] == 0 && !IsTileAttacked(2, 7) && !IsTileAttacked(3, 7) && !IsTileAttacked(4, 7))
                return true;
            else
                return false;
        }

        //Zjišťuje jestli probíhá krátká bílá rošáda 
        private bool WhiteShortCastling(int HeldX, int HeldY, int ClickX)
        {
            if (HeldX == 4 && HeldY == 7 && ClickX == 6 && WhiteShortCastlingPossibility && Position[5, 7] == 0 && Position[6, 7] == 0 && !IsTileAttacked(5, 7) && !IsTileAttacked(6, 7) && !IsTileAttacked(4, 7))
                return true;
            else
                return false;
        }

        //Zjišťuje jestli probíhá dlouhá černá rošáda 
        private bool BlackLongCastling(int HeldX, int HeldY, int ClickX)
        {
            if (HeldX == 4 && HeldY == 0 && ClickX == 2 && BlackLongCastlingPossibility && Position[1, 0] == 0 && Position[2, 0] == 0 && Position[3, 0] == 0 && !IsTileAttacked(2, 0) && !IsTileAttacked(3, 0) && !IsTileAttacked(4, 0))
                return true;
            else
                return false;
        }

        //Zjišťuje jestli probíhá krátká černá rošáda 
        private bool BlackShortCastling(int HeldX, int HeldY, int ClickX)
        {
            if (HeldX == 4 && HeldY == 0 && ClickX == 6 && BlackShortCastlingPossibility && Position[5, 0] == 0 && Position[6, 0] == 0 && !IsTileAttacked(5, 0) && !IsTileAttacked(6, 0) && !IsTileAttacked(4, 0))
                return true;
            else
                return false;
        }

        //Provedení rošády
        private void Castling(ChessBoard chessBoard, Graphics g, int HeldX, int HeldY, int ClickX)
        {
                if (WhiteLongCastling(HeldX, HeldY, ClickX))
                {
                    RestoreBoard(chessBoard, g);
                    Position[4, 7] = 0;
                    Position[0, 7] = 0;
                    Position[2, 7] = 6;
                    Position[3, 7] = 4;
                    RefreshTile(chessBoard, g, 4, 7);
                    RefreshTile(chessBoard, g, 0, 7);
                    RefreshTile(chessBoard, g, 2, 7);
                    RefreshTile(chessBoard, g, 3, 7);
                    WhiteLongCastlingPossibility = false;
                    WhiteShortCastlingPossibility = false;
                    TypeOfMove = 2;
                    EndOfTurnMessage = TurnNumber + ". 0-0-0";
                }
                else if (WhiteShortCastling(HeldX, HeldY, ClickX))
                {
                    RestoreBoard(chessBoard, g);
                    Position[4, 7] = 0;
                    Position[7, 7] = 0;
                    Position[6, 7] = 6;
                    Position[5, 7] = 4;
                    RefreshTile(chessBoard, g, 4, 7);
                    RefreshTile(chessBoard, g, 7, 7);
                    RefreshTile(chessBoard, g, 6, 7);
                    RefreshTile(chessBoard, g, 5, 7);
                    WhiteLongCastlingPossibility = false;
                    WhiteShortCastlingPossibility = false;
                    TypeOfMove = 3;
                    EndOfTurnMessage = TurnNumber + ". 0-0";
                }
                else if (BlackLongCastling(HeldX, HeldY, ClickX))
                {
                    RestoreBoard(chessBoard, g);
                    Position[4, 0] = 0;
                    Position[0, 0] = 0;
                    Position[2, 0] = 12;
                    Position[3, 0] = 10;
                    RefreshTile(chessBoard, g, 4, 0);
                    RefreshTile(chessBoard, g, 0, 0);
                    RefreshTile(chessBoard, g, 2, 0);
                    RefreshTile(chessBoard, g, 3, 0);
                    BlackLongCastlingPossibility = false;
                    BlackShortCastlingPossibility = false;
                    TypeOfMove = 2;
                    EndOfTurnMessage = TurnNumber + ". 0-0-0";
                }
                else if (BlackShortCastling(HeldX, HeldY, ClickX))
                {
                    RestoreBoard(chessBoard, g);
                    Position[4, 0] = 0;
                    Position[7, 0] = 0;
                    Position[6, 0] = 12;
                    Position[5, 0] = 10;
                    RefreshTile(chessBoard, g, 4, 0);
                    RefreshTile(chessBoard, g, 7, 0);
                    RefreshTile(chessBoard, g, 6, 0);
                    RefreshTile(chessBoard, g, 5, 0);
                    BlackLongCastlingPossibility = false;
                    BlackShortCastlingPossibility = false;
                    TypeOfMove = 3;
                    EndOfTurnMessage = TurnNumber + ". 0-0";
                }
            
        }

        //Aktualizuje pozici králů
        private void UpdateKingsPosition(int ClickX, int ClickY)
        {
            if (Position[HeldPositionX, HeldPositionY] == 6)
            {
                WhiteKingPositionX = ClickX;
                WhiteKingPositionY = ClickY;
            }
            else if (Position[HeldPositionX, HeldPositionY] == 12)
            {
                BlackKingPositionX = ClickX;
                BlackKingPositionY = ClickY;
            }
        }

        //Záměna pěšáka za jinou figurku když dojde na konec šachovnice
        public void PawnChange(ChessBoard chessBoard, Graphics g, int X, int Y)
        {
            PawnIsBeingPromoted = true;
            if (chessBoard.IsTileBlack(X, Y))
            {
                if (Position[X, Y] < 7)
                {
                    PawnChoiceKnight = WhiteKnight_Black;
                    PawnChoiceBishop = WhiteBishop_Black;
                    PawnChoiceRook = WhiteRook_Black;
                    PawnChoiceQueen = WhiteQueen_Black;

                    PawnChoiceHighlightedKnight = WhiteKnight_HighlightedBlack;
                    PawnChoiceHighlightedBishop = WhiteBishop_HighligtedBlack;
                    PawnChoiceHighlightedRook = WhiteRook_HighlightedBlack;
                    PawnChoiceHighlightedQueen = WhiteQueen_HighlightedBlack;
                }
                else
                {
                    PawnChoiceKnight = BlackKnight_Black;
                    PawnChoiceBishop = BlackBishop_Black;
                    PawnChoiceRook = BlackRook_Black;
                    PawnChoiceQueen = BlackQueen_Black;

                    PawnChoiceHighlightedKnight = BlackKnight_HighlightedBlack;
                    PawnChoiceHighlightedBishop = BlackBishop_HighlightedBlack;
                    PawnChoiceHighlightedRook = BlackRook_HighlightedBlack;
                    PawnChoiceHighlightedQueen = BlackQueen_HighlightedBlack;
                }
            }
            else
            {
                if(Position[X, Y] < 7)
                {
                    PawnChoiceKnight = WhiteKnight_White;
                    PawnChoiceBishop = WhiteBishop_White;
                    PawnChoiceRook = WhiteRook_White;
                    PawnChoiceQueen = WhiteQueen_White;

                    PawnChoiceHighlightedKnight = WhiteKnight_HighlightedWhite;
                    PawnChoiceHighlightedBishop = WhiteBishop_HighligtedWhite;
                    PawnChoiceHighlightedRook = WhiteRook_HighlightedWhite;
                    PawnChoiceHighlightedQueen = WhiteQueen_HighlightedWhite;
                }
                else
                {
                    PawnChoiceKnight = BlackKnight_White;
                    PawnChoiceBishop = BlackBishop_White;
                    PawnChoiceRook = BlackRook_White;
                    PawnChoiceQueen = BlackQueen_White;

                    PawnChoiceHighlightedKnight = BlackKnight_HighlightedWhite;
                    PawnChoiceHighlightedBishop = BlackBishop_HighlightedWhite;
                    PawnChoiceHighlightedRook = BlackRook_HighlightedWhite;
                    PawnChoiceHighlightedQueen = BlackQueen_HighlightedWhite;
                }
            }
        }

        //Aktualizuje šachovnici
        public void RefreshBoard(ChessBoard chessBoard, Graphics g)
        {
            for (int i = 0; i < chessBoard.GridSize; i++)
                for (int j = 0; j < chessBoard.GridSize; j++)
                    RefreshTile(chessBoard, g, i, j);
        }

        //Zjišťuje jestli hra zkončila, konkrétně jestli má hráč nějaký možný pohyb
        private bool GameOver(ChessBoard chessBoard, Graphics g)
        {
            NumbOfMoves = 0;
            HideHighlights = true;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (IsThisPlayerOnTurn(i, j) && Position[i,j] != 0)
                    {
                        HeldPositionX = i;
                        HeldPositionY = j;
                        ShowPossibleMoves(chessBoard, g, i, j);
                        RestoreBoard(chessBoard, g);
                    }
                }
            HideHighlights = false;
            if (NumbOfMoves == 0)
            {
                PublicGameOver = true;
                return true;
            }
            else
                return false;
        }

        //Zjišťuje jestli je konec hry mat (true) nebo pat (false)
        private bool CheckMate(int turnNumber)
        {
            if ((turnNumber % 2 != 0 && IsTileAttacked(WhiteKingPositionX, WhiteKingPositionY)) | (turnNumber % 2 == 0 && IsTileAttacked(BlackKingPositionX, BlackKingPositionY)))
                return true;
            else
                return false;
        }

        //Ukládá data do stringu EndOfTurnMessage
        private void EndOfTurnLogMessage(int HeldX, int HeldY, int ClickX, int ClickY)
        {
            char X1;
            char Y1;
            char X2;
            char Y2;
            switch (HeldX)
            {
                case 0:
                    X1 = 'a';
                    break;
                case 1:
                    X1 = 'b';
                    break;
                case 2:
                    X1 = 'c';
                    break;
                case 3:
                    X1 = 'd';
                    break;
                case 4:
                    X1 = 'e';
                    break;
                case 5:
                    X1 = 'f';
                    break;
                case 6:
                    X1 = 'g';
                    break;
                case 7:
                    X1 = 'h';
                    break;
                default:
                    X1 = 'X';
                    break;
            }
            switch (ClickX)
            {
                case 0:
                    X2 = 'a';
                    break;
                case 1:
                    X2 = 'b';
                    break;
                case 2:
                    X2 = 'c';
                    break;
                case 3:
                    X2 = 'd';
                    break;
                case 4:
                    X2 = 'e';
                    break;
                case 5:
                    X2 = 'f';
                    break;
                case 6:
                    X2 = 'g';
                    break;
                case 7:
                    X2 = 'h';
                    break;
                default:
                    X2 = 'X';
                    break;
            }
            switch (HeldY)
            {
                case 0:
                    Y1 = '8';
                    break;
                case 1:
                    Y1 = '7';
                    break;
                case 2:
                    Y1 = '6';
                    break;
                case 3:
                    Y1 = '5';
                    break;
                case 4:
                    Y1 = '4';
                    break;
                case 5:
                    Y1 = '3';
                    break;
                case 6:
                    Y1 = '2';
                    break;
                case 7:
                    Y1 = '1';
                    break;
                default:
                    Y1 = 'X';
                    break;
            }
            switch (ClickY)
            {
                case 0:
                    Y2 = '8';
                    break;
                case 1:
                    Y2 = '7';
                    break;
                case 2:
                    Y2 = '6';
                    break;
                case 3:
                    Y2 = '5';
                    break;
                case 4:
                    Y2 = '4';
                    break;
                case 5:
                    Y2 = '3';
                    break;
                case 6:
                    Y2 = '2';
                    break;
                case 7:
                    Y2 = '1';
                    break;
                default:
                    Y2 = 'X';
                    break;
            }
            GetChessPiece(HeldX, HeldY);
            EndOfTurnMessage += TurnNumber + ". " + CurrentPieceIcon + X1 + Y1;
            GetChessPiece(ClickX, ClickY);
            EndOfTurnMessage += " " + CurrentPieceIcon + X2 + Y2;

        }

        //Funkce která končí tah a dokončuje string EndOfTurnMessage 
        private void EndOfTurnSummary(ChessBoard chessBoard, Graphics g, int HeldY, int ClickX, int ClickY)
        {
            for (int i = 0; i < 8; i++)
                EntPassant[i] = false;
            EnPassantUpdate(HeldY, ClickX, ClickY);
            TurnNumber += 1;
            UndoMovePossibility = true;
            RefreshBoard(chessBoard, g);
            EndOfTurn = true;
            if (GameOver(chessBoard, g))
            {
                if (CheckMate(TurnNumber))
                {
                    EndOfTurnMessage += " #";
                    if (TurnNumber % 2 == 0)
                        WinMessage = "White won";
                    else
                        WinMessage = "Black Won";
                }
                else
                {
                    WinMessage = "Stalemate";
                    EndOfTurnMessage += " =";
                }     
            }
            else
            {
                if ((TurnNumber % 2 == 0 && IsTileAttacked(BlackKingPositionX, BlackKingPositionY)) | (TurnNumber % 2 != 0 && IsTileAttacked(WhiteKingPositionX, WhiteKingPositionY)))
                    EndOfTurnMessage += " +";
            }
        }

        //Funkce která končí tah a dokončuje string EndOfTurnMessage, tenhle oveload je použit u výměny pěšáků, kde není potřeba znát přesné souřadnice figurky
        public void EndOfTurnSummary(ChessBoard chessBoard, Graphics g)
        {
            for (int i = 0; i < 8; i++)
                EntPassant[i] = false;
            TurnNumber += 1;
            UndoMovePossibility = true;
            RefreshBoard(chessBoard, g);
            EndOfTurn = true;
            if (GameOver(chessBoard, g))
            {
                if (CheckMate(TurnNumber))
                {
                    EndOfTurnMessage += " #";
                    if (TurnNumber % 2 == 0)
                        WinMessage = "White won";
                    else
                        WinMessage = "Black Won";
                }
                else
                {
                    WinMessage = "Stalemate";
                    EndOfTurnMessage += " =";
                }
            }
            else
            {
                if ((TurnNumber % 2 == 0 && IsTileAttacked(BlackKingPositionX, BlackKingPositionY)) | (TurnNumber % 2 != 0 && IsTileAttacked(WhiteKingPositionX, WhiteKingPositionY)))
                    EndOfTurnMessage += " +";
            }
        }

        //Zjišťuje, jestli se aktivovalo braní mimochodem(en passant)
        private void EnPassantUpdate(int HeldY, int ClickX, int ClickY)
        {
            if ((ClickY == 3 && HeldY == 1 && CheckForPiece(7, ClickX, ClickY)) | (ClickY == 4 && HeldY == 6 && CheckForPiece(1, ClickX, ClickY)))
                EntPassant[ClickX] = true;
        }

        //Uložení dat z předchozího kola pro tlačítko zpět
        private void SaveThisTurn(int HeldX, int HeldY, int ClickX, int CLickY)
        {
            LastTurn[0] = HeldX;
            LastTurn[1] = HeldY;
            LastTurn[2] = Position[HeldX, HeldY];
            LastTurn[3] = ClickX;
            LastTurn[4] = CLickY;
            LastTurn[5] = Position[ClickX, CLickY];

            LastTurnCastling[0] = WhiteLongCastlingPossibility;
            LastTurnCastling[1] = WhiteShortCastlingPossibility;
            LastTurnCastling[2] = BlackLongCastlingPossibility;
            LastTurnCastling[3] = BlackShortCastlingPossibility;

            int temp = 0;
            for(int i = 0; i < 8; i++)
            {
                if (EntPassant[i])
                {
                    LastTurn[7] = i;
                    temp = 1;
                    break;
                }      
            }
            LastTurn[6] = temp;
        }

        //Vrácení tahu zpět
        public void UndoMove(ChessBoard chessBoard, Graphics g, int TypeOfMove)
        {
            Position[LastTurn[0], LastTurn[1]] = LastTurn[2];
            Position[LastTurn[3], LastTurn[4]] = LastTurn[5];
            UpdateKingsPosition(LastTurn[3], LastTurn[4]);

            WhiteLongCastlingPossibility = LastTurnCastling[0];
            WhiteShortCastlingPossibility = LastTurnCastling[1];
            BlackLongCastlingPossibility = LastTurnCastling[2];
            BlackShortCastlingPossibility = LastTurnCastling[3];

            if (LastTurn[6] == 1)
                EntPassant[LastTurn[7]] = true;

            switch (TypeOfMove)
            {
                case 1:
                    Position[LastTurn[3], LastTurn[1]] = 1 + (TurnNumber % 2) * 6;
                    EntPassant[LastTurn[3]] = true;
                    break;
                case 2:
                    Position[3, LastTurn[1]] = 0;
                    Position[0, LastTurn[1]] = 4 + ((TurnNumber + 1) % 2) * 6;
                    HeldPositionX = 4;
                    HeldPositionY = LastTurn[1];
                    UpdateKingsPosition(4, LastTurn[1]);
                    break;
                case 3:
                    Position[5, LastTurn[1]] = 0;
                    Position[7, LastTurn[1]] = 4 + ((TurnNumber + 1) % 2) * 6;
                    HeldPositionX = 4;
                    HeldPositionY = LastTurn[1];
                    UpdateKingsPosition(4, LastTurn[1]);
                    break;
                default:
                    break;
            }
            RefreshBoard(chessBoard, g);
        }

        //Hlavní metoda, rozhoduje co se stane po každém kliknutí
        public void ChooseWhatToDo(ChessBoard chessBoard ,Graphics g, int ClickX, int ClickY)  
        {
            GetCoordinations(chessBoard, ClickX, ClickY);
            if (PieceIsBeingHeld)
            {
                //Braní mimochodem (En passant)
                if (TileIsBeingAttacked[ClickedPositionX, ClickedPositionY] && EntPassant[ClickedPositionX] && (HeldPositionX == ClickedPositionX + 1 | HeldPositionX == ClickedPositionX - 1) && ((HeldPositionY == 3  && Position[HeldPositionX, HeldPositionY] == 1 && ClickedPositionY == 2) | (HeldPositionY == 4 && Position[HeldPositionX, HeldPositionY] == 7 && ClickedPositionY == 5)))
                {
                    SaveThisTurn(HeldPositionX, HeldPositionY, ClickedPositionX, ClickedPositionY);
                    TypeOfMove = 1;
                    EndOfTurnLogMessage(HeldPositionX, HeldPositionY, ClickedPositionX, ClickedPositionY);
                    EndOfTurnMessage += " e.p.";
                    RestoreBoard(chessBoard, g);
                    Position[ClickedPositionX, ClickedPositionY] = Position[HeldPositionX, HeldPositionY];
                    Position[HeldPositionX, HeldPositionY] = 0;
                    Position[ClickedPositionX, HeldPositionY] = 0;
                    EndOfTurnSummary(chessBoard, g, HeldPositionY, ClickedPositionX, ClickedPositionY);
                }
                //Když pěšák dojde na konec šachovnice
                else if ((Position[HeldPositionX, HeldPositionY] == 1 && ClickedPositionY == 0) | (Position[HeldPositionX, HeldPositionY] == 7 && ClickedPositionY == 7) && TileIsBeingAttacked[ClickedPositionX, ClickedPositionY])
                {
                    //TODO
                    SaveThisTurn(HeldPositionX, HeldPositionY, ClickedPositionX, ClickedPositionY);
                    TypeOfMove = 0;
                    EndOfTurnLogMessage(HeldPositionX, HeldPositionY, ClickedPositionX, ClickedPositionY);
                    RestoreBoard(chessBoard, g);
                    Position[ClickedPositionX, ClickedPositionY] = Position[HeldPositionX, HeldPositionY];
                    Position[HeldPositionX, HeldPositionY] = 0;
                    RefreshBoard(chessBoard, g);
                    PawnChange(chessBoard, g, ClickedPositionX, ClickedPositionY);
                }
                //Rošáda
                else if (WhiteShortCastling(HeldPositionX, HeldPositionY, ClickedPositionX) | WhiteLongCastling(HeldPositionX, HeldPositionY, ClickedPositionX) | BlackShortCastling(HeldPositionX, HeldPositionY, ClickedPositionX) | BlackLongCastling(HeldPositionX, HeldPositionY, ClickedPositionX))
                {
                    //TODO
                    SaveThisTurn(HeldPositionX, HeldPositionY, ClickedPositionX, ClickedPositionY);
                    EndOfTurnLogMessage(HeldPositionX, HeldPositionY, ClickedPositionX, ClickedPositionY);
                    RestoreBoard(chessBoard, g);
                    Castling(chessBoard, g, HeldPositionX, HeldPositionY, ClickedPositionX);
                    UpdateKingsPosition(ClickedPositionX, ClickedPositionY);
                    CastlingPosibilityUpdate(HeldPositionX, HeldPositionY);
                    EndOfTurnSummary(chessBoard, g, HeldPositionY, ClickedPositionX, ClickedPositionY);
                }
                //Normální pohyb
                else if (TileIsBeingAttacked[ClickedPositionX, ClickedPositionY])
                {
                    SaveThisTurn(HeldPositionX, HeldPositionY, ClickedPositionX, ClickedPositionY);
                    TypeOfMove = 0;
                    EndOfTurnLogMessage(HeldPositionX, HeldPositionY, ClickedPositionX, ClickedPositionY);
                    UpdateKingsPosition(ClickedPositionX, ClickedPositionY);
                    CastlingPosibilityUpdate(HeldPositionX, HeldPositionY);
                    RestoreBoard(chessBoard, g);
                    Position[ClickedPositionX, ClickedPositionY] = Position[HeldPositionX, HeldPositionY];
                    Position[HeldPositionX, HeldPositionY] = 0;
                    EndOfTurnSummary(chessBoard, g, HeldPositionY, ClickedPositionX, ClickedPositionY);
                }
                else
                {
                    RestoreBoard(chessBoard, g);
                }
                PieceIsBeingHeld = false;
            }
            else
            {
                if (IsThisPlayerOnTurn(ClickedPositionX, ClickedPositionY))
                {
                    HighlightPiece(chessBoard, g, ClickedPositionX, ClickedPositionY);
                    PieceIsBeingHeld = true;
                    HeldPositionX = ClickedPositionX;
                    HeldPositionY = ClickedPositionY;
                    ShowPossibleMoves(chessBoard, g, ClickedPositionX, ClickedPositionY);
                }
            }
        }

        //Začátek a reset hry
        public void SetGame()
        {
            TurnNumber = 1;

            for (int i = 0; i < 8; i++)
            {
                IsKingAttackedFromDirection[i] = false;
                EntPassant[i] = false;
                for (int j = 0; j < 8; j++)
                {
                    Position[i, j] = 0;
                    TileIsBeingAttacked[i, j] = false;
                }
            }

            WhiteLongCastlingPossibility = true;
            WhiteShortCastlingPossibility = true;
            BlackLongCastlingPossibility = true;
            BlackShortCastlingPossibility = true;

            PieceIsBeingHeld = false;
            PawnIsBeingPromoted = false;
            HideHighlights = false;
            EndOfTurn = false;
            EndOfTurnMessage = null;
            PublicGameOver = false;
            UndoMovePossibility = false;

            Position[0, 0] = 10;
            Position[1, 0] = 8;
            Position[2, 0] = 9;
            Position[3, 0] = 11;
            Position[4, 0] = 12;
            BlackKingPositionX = 4;
            BlackKingPositionY = 0;
            Position[5, 0] = 9;
            Position[6, 0] = 8;
            Position[7, 0] = 10;
            Position[0, 1] = 7;
            Position[1, 1] = 7;
            Position[2, 1] = 7;
            Position[3, 1] = 7;
            Position[4, 1] = 7;
            Position[5, 1] = 7;
            Position[6, 1] = 7;
            Position[7, 1] = 7;
            Position[0, 6] = 1;
            Position[1, 6] = 1;
            Position[2, 6] = 1;
            Position[3, 6] = 1;
            Position[4, 6] = 1;
            Position[5, 6] = 1;
            Position[6, 6] = 1;
            Position[7, 6] = 1;
            Position[0, 7] = 4;
            Position[1, 7] = 2;
            Position[2, 7] = 3;
            Position[3, 7] = 5;
            Position[4, 7] = 6;
            WhiteKingPositionX = 4;
            WhiteKingPositionY = 7;
            Position[5, 7] = 3;
            Position[6, 7] = 2;
            Position[7, 7] = 4;
        }
    }
}
