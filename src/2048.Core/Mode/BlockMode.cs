using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Core.Mode
{
    public class BlockMode : ClassicMode
    {
        public BlockMode()
        {
            base.ModeType = Model.ModeType.BlockMode;
        }

        public override void Initi()
        {
            base.Initi();
            addBlock();
        }

        private void addBlock()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            while (true)
            {
                int x = rand.Next(0, Board.GetLength(0));
                int y = rand.Next(0, Board.GetLength(1));

                if (Board[x, y] == 0)
                {
                    Board[x, y] = -999;
                    break;
                }
            }
        }
    }
}
