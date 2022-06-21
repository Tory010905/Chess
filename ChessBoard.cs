using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess_IHopeLastOne
{
    class ChessBoard
    {
        private int gridSize;
        private int size;

        public ChessBoard(int Size, int GridSize)
        {
            this.size = Size;
            this.gridSize = GridSize;
        }
        //vykreslí šachovnici
        public void createBoard(Graphics g, Game game)
        {
            for (int j = 0; j < GridSize; j++)
            {
                for (int i = 0; i < GridSize; i++)
                {
                    game.GetChessPiece(i, j);
                    if (IsTileBlack(i, j))
                    {
                        g.DrawImage(game.CurrentBlackImage, i * Size, j * Size, Size, Size);
                    }
                    else
                    {
                        g.DrawImage(game.CurrentWhiteImage, i* Size, j * Size, Size, Size);
                    }

                }
            }
        }

        public int Size
        {
            get { return size; }
            set { value = size; }
        }

        public int GridSize
        {
            get { return gridSize; }
            set { value = gridSize; }
        }
        //zjistí jakou barvu má dané políčko
        public bool IsTileBlack(int X, int Y)
        {
            if ((X % 2 == 0 && Y % 2 != 0) | (X % 2 != 0 && Y % 2 == 0))
                return true;
            else
                return false;
        }
    }
}
