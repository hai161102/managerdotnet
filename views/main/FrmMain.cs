using ManagerProjectDotNet.base_app.linear;
using ManagerProjectDotNet.views.main.option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerProjectDotNet.views.main
{
    internal class FrmMain : LinearLayout
    {
        public FrmMain(string width, string height, Control parent) : base(width, height, parent)
        {
            this.orientation = VERTICAL;
            OptionsView options = new OptionsView(width, height, this);
            this.addView(options);
            notifiDataChanged();
        }
    }
}
