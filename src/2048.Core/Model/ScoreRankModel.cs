using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Core.Model
{
    public class ScoreRankModel
    {
        public ModeType ModeType { get; set; }

        public string Name { get; set; }

        public int Score { get; set; }

        public int PlayTime { get; set; }

        public DateTime CreateDT { get; set; }
    }
}
