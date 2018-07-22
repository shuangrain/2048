using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Core.Mode
{
    public class MoveMode : ClassicMode
    {
        private int _maxLastStep = 5;
        private int _lastStep = 0;

        public MoveMode()
        {
            base.ModeType = Model.ModeType.MoveMode;
        }

        public override void Initi()
        {
            base.Initi();

            _lastStep = _maxLastStep;
        }

        public override bool IsLose()
        {
            bool isLose = base.IsLose();

            if (!isLose)
            {
                isLose = (_lastStep <= 0);
            }

            return isLose;
        }

        public override void Left()
        {
            base.Left();
            addLastStep();
        }

        public override void Right()
        {
            base.Right();
            addLastStep();
        }

        public override void Up()
        {
            base.Up();
            addLastStep();
        }

        public override void Down()
        {
            base.Down();
            addLastStep();
        }

        public override string GetTipMessage()
        {
            string msg = base.GetTipMessage();

            msg += $", 剩餘步數：{_lastStep} 步";

            return msg;
        }

        private void addLastStep()
        {
            if (HasAddNumInThisRound)
            {
                _lastStep++;

                if (_lastStep >= _maxLastStep)
                {
                    _lastStep = _maxLastStep;
                }
            }
            else
            {
                _lastStep--;
            }
        }
    }
}
