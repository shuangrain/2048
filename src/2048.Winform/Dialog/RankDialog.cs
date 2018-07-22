using _2048.Core.Model;
using _2048.Core.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048.Winform.Dialog
{
    public partial class RankDialog : Form
    {
        private readonly RankService _rankService = null;

        public RankDialog()
        {
            InitializeComponent();
            _rankService = new RankService();
        }

        private void RankDialog_Load(object sender, EventArgs e)
        {
            _rankService.GetScoreAsync(ModeType.None).ContinueWith(result =>
            {
                var list = result.Result;
                if (list == null)
                {
                    return;
                }

                var func = new Func<ModeType, IEnumerable<ListViewItem>>((modeType) =>
                {
                    return list.Where(x => x.ModeType == modeType).Select(x =>
                    {
                        ListViewItem listViewItem = new ListViewItem(x.Name);

                        listViewItem.SubItems.Add($"{x.Score} 分");
                        listViewItem.SubItems.Add($"{x.PlayTime} 秒");
                        listViewItem.SubItems.Add(x.CreateDT.ToString());

                        return listViewItem;
                    });
                });

                listClassic.Items.AddRange(func(ModeType.ClassicMode).ToArray());
                listTime.Items.AddRange(func(ModeType.TimeMode).ToArray());
                listMove.Items.AddRange(func(ModeType.MoveMode).ToArray());
                listBlock.Items.AddRange(func(ModeType.BlockMode).ToArray());

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
