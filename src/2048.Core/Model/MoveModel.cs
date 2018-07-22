using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Core.Model
{
    public class MoveModel
    {
        private readonly int[,] _board = null;

        public MoveModel(int[,] board)
        {
            _board = board;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int PreX
        {
            get
            {
                return (X - 1 < 0) ? -1 : _board[(X - 1), Y];
            }
        }

        public int PreY
        {
            get
            {
                return (Y - 1 < 0) ? -1 : _board[X, (Y - 1)];
            }
        }

        public int NextX
        {
            get
            {
                return (X + 1 >= _board.GetLength(0)) ? -1 : _board[(X + 1), Y];
            }
        }

        public int NextY
        {
            get
            {
                return (Y + 1 >= _board.GetLength(1)) ? -1 : _board[X, (Y + 1)];
            }
        }

        public int Current
        {
            get
            {
                return _board[X, Y];
            }
        }
    }

}
