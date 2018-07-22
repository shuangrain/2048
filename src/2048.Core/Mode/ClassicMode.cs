using _2048.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Core.Mode
{
    public class ClassicMode : GameMode
    {
        public ClassicMode()
        {
            base.ModeType = ModeType.ClassicMode;
        }

        public override void Left()
        {
            LoopBoard(MoveType.Left, (model) =>
            {
                if (model.Current > 0 && model.Current == model.NextX)
                {
                    int sumNum = (model.Current + model.NextX);

                    Score += sumNum;
                    Board[model.X, model.Y] = sumNum;
                    Board[(model.X + 1), model.Y] = 0;

                    if (sumNum > 0)
                    {
                        HasAddNumInThisRound = true;
                    }
                }
            });
        }

        public override void Right()
        {
            LoopBoard(MoveType.Right, (model) =>
            {
                if (model.Current > 0 && model.Current == model.PreX)
                {
                    int sumNum = (model.Current + model.PreX);

                    Score += sumNum;
                    Board[(model.X - 1), model.Y] = sumNum;
                    Board[model.X, model.Y] = 0;

                    if (sumNum > 0)
                    {
                        HasAddNumInThisRound = true;
                    }
                }
            });
        }

        public override void Up()
        {
            LoopBoard(MoveType.Up, (model) =>
            {
                if (model.Current > 0 && model.Current == model.PreY)
                {
                    int sumNum = (model.Current + model.PreY);

                    Score += sumNum;
                    Board[model.X, (model.Y - 1)] = sumNum;
                    Board[model.X, model.Y] = 0;

                    if (sumNum > 0)
                    {
                        HasAddNumInThisRound = true;
                    }
                }
            });
        }

        public override void Down()
        {
            LoopBoard(MoveType.Down, (model) =>
            {
                if (model.Current > 0 && model.Current == model.NextY)
                {
                    int sumNum = (model.Current + model.NextY);

                    Score += sumNum;
                    Board[model.X, model.Y] = sumNum;
                    Board[model.X, (model.Y + 1)] = 0;

                    if (sumNum > 0)
                    {
                        HasAddNumInThisRound = true;
                    }
                }
            });
        }

    }
}
