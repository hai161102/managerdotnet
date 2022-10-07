using ManagerProjectDotNet.base_app.linear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerProjectDotNet.views.main.option
{
    internal class OptionsView : LinearLayout
    {
        public OptionsView(string width, string height, Control parent) : base(width, height, parent)
        {
            this.orientation = HORIZONTAL;
            for (int i = 0; i < 5; i++)
            {
                addView(getViewText());
            }
            notifiDataChanged();
        }

        private Label getViewText()
        {
            Label label = new Label();
            label.Text = "abc";
            return label;
        }

    }
}
