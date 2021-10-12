using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public class RoundButton : Button
    {
        public RoundButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            //this.ForeColor = this.BackColor;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Selectable, false);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddEllipse(ClientRectangle);
            this.Region = new Region(gPath);
            base.OnPaint(pevent);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }
    }
}
