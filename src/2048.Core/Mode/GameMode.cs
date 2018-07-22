using _2048.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Core.Mode
{
    public abstract class GameMode
    {
        private DateTime _startTime = default(DateTime);

        public int PlayTime { get; protected set; }

        public int Score { get; set; }

        public ModeType ModeType { get; protected set; }

        public bool HasMoveNumInThisRound { get; set; }

        public bool HasAddNumInThisRound { get; set; }

        public int[,] Board { get; set; }

        /// <summary>
        /// 初始化遊戲
        /// </summary>
        public virtual void Initi()
        {
            Board = new int[4, 4];
            Score = 0;
            PlayTime = 0;
            _startTime = DateTime.Now;

            AddRandNum();
            AddRandNum();
        }

        /// <summary>
        /// 判斷遊戲是否結束
        /// </summary>
        public virtual bool IsLose()
        {
            bool isLose = true;

            LoopBoard(MoveType.None, (model) =>
            {
                if (model.Current == 0 ||
                    model.PreX == model.Current || model.NextX == model.Current ||
                    model.PreY == model.Current || model.NextY == model.Current)
                {
                    isLose = false;
                    return;
                }
            });

            return isLose;
        }

        /// <summary>
        /// 隨機位置新增一數字
        /// </summary>
        public Tuple<int, int> AddRandNum()
        {
            if (!hasEmpty())
            {
                return null;
            }

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int randNum = (2 * rand.Next(1, 3));

            while (true)
            {
                int x = rand.Next(0, Board.GetLength(0));
                int y = rand.Next(0, Board.GetLength(1));

                if (Board[x, y] == 0)
                {
                    Board[x, y] = randNum;
                    return Tuple.Create(x, y);
                }
            }
        }

        /// <summary>
        /// 取得遊戲訊息
        /// </summary>
        /// <returns></returns>
        public virtual string GetTipMessage()
        {
            PlayTime = (int)new TimeSpan(DateTime.Now.Ticks - _startTime.Ticks).TotalSeconds;
            return $"遊戲時間：{PlayTime} 秒";
        }

        public abstract void Left();

        public abstract void Right();

        public abstract void Up();

        public abstract void Down();

        protected void LoopBoard(MoveType type, Action<MoveModel> action)
        {
            sortBoard(type);

            // 需先處理最右邊 & 最上面的數字
            if (type == MoveType.Right || type == MoveType.Up)
            {
                for (int x = (Board.GetLength(0) - 1); x >= 0; x--)
                {
                    for (int y = (Board.GetLength(1) - 1); y >= 0; y--)
                    {
                        action(new MoveModel(Board)
                        {
                            X = x,
                            Y = y
                        });
                    }
                }
            }
            else
            {
                for (int x = 0; x < Board.GetLength(0); x++)
                {
                    for (int y = 0; y < Board.GetLength(1); y++)
                    {
                        action(new MoveModel(Board)
                        {
                            X = x,
                            Y = y
                        });
                    }
                }
            }
            sortBoard(type);
        }

        private void sortBoard(MoveType type)
        {
            if (type == MoveType.None)
            {
                return;
            }

            int loopCount = 1;
            int endX = Board.GetLength(0);
            int endY = Board.GetLength(1);

            if (type == MoveType.Left || type == MoveType.Right)
            {
                loopCount = endX;
            }
            else if (type == MoveType.Up || type == MoveType.Down)
            {
                loopCount = endY;
            }

            for (int i = 0; i < loopCount; i++)
            {
                for (int x = 0; x < endX; x++)
                {
                    for (int y = 0; y < endY; y++)
                    {
                        var model = new MoveModel(Board)
                        {
                            X = x,
                            Y = y
                        };

                        switch (type)
                        {
                            case MoveType.Left:
                                {
                                    if (model.PreX == 0)
                                    {
                                        Board[(model.X - 1), model.Y] = model.Current;
                                        Board[model.X, model.Y] = 0;
                                        if (model.PreX != 0 || model.Current != 0)
                                        {
                                            HasMoveNumInThisRound = true;
                                        }
                                    }
                                    break;
                                }
                            case MoveType.Right:
                                {
                                    if (model.NextX == 0)
                                    {
                                        Board[(model.X + 1), model.Y] = model.Current;
                                        Board[model.X, model.Y] = 0;
                                        if (model.NextX != 0 || model.Current != 0)
                                        {
                                            HasMoveNumInThisRound = true;
                                        }
                                    }
                                    break;
                                }
                            case MoveType.Up:
                                {
                                    if (model.NextY == 0)
                                    {
                                        Board[model.X, (model.Y + 1)] = model.Current;
                                        Board[model.X, model.Y] = 0;
                                        if (model.NextY != 0 || model.Current != 0)
                                        {
                                            HasMoveNumInThisRound = true;
                                        }
                                    }
                                    break;
                                }
                            case MoveType.Down:
                                {
                                    if (model.PreY == 0)
                                    {
                                        Board[model.X, (model.Y - 1)] = model.Current;
                                        Board[model.X, model.Y] = 0;
                                        if (model.PreY != 0 || model.Current != 0)
                                        {
                                            HasMoveNumInThisRound = true;
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 是否還有空格
        /// </summary>
        private bool hasEmpty()
        {
            bool hasEmpty = false;

            LoopBoard(MoveType.None, (model) =>
            {
                if (model.Current == 0)
                {
                    hasEmpty = true;
                    return;
                }
            });

            return hasEmpty;
        }
    }
}
