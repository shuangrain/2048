using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace _2048.Core.Mode
{
    public class TimeMode : ClassicMode
    {
        private readonly Timer _timer = null;
        private int _maxLastSec = 10;
        private int _lastSec = 0;

        public TimeMode()
        {
            base.ModeType = Model.ModeType.TimeMode;

            _timer = new Timer(1000);
            _timer.Elapsed += (sender, args) =>
            {
                _lastSec--;
            };
        }

        public override void Initi()
        {
            base.Initi();

            _timer.Start();
            _lastSec = _maxLastSec;
        }

        public override bool IsLose()
        {
            bool isLose = base.IsLose();

            if (!isLose)
            {
                isLose = (_lastSec <= 0);
                if (isLose)
                {
                    _timer.Stop();
                }
            }

            return isLose;
        }

        public override void Left()
        {
            base.Left();
            addLastSec();
        }

        public override void Right()
        {
            base.Right();
            addLastSec();
        }

        public override void Up()
        {
            base.Up();
            addLastSec();
        }

        public override void Down()
        {
            base.Down();
            addLastSec();
        }

        public override string GetTipMessage()
        {
            string msg = base.GetTipMessage();

            msg += $", 剩餘時間：{_lastSec} 秒";

            return msg;
        }

        private void addLastSec()
        {
            if (HasAddNumInThisRound)
            {
                _lastSec++;

                if (_lastSec >= _maxLastSec)
                {
                    _lastSec = _maxLastSec;
                }
            }
        }
    }
}
