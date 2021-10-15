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
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.BorderSize = 0;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddEllipse(ClientRectangle);
            this.Region = new Region(gPath);
            
            if (this.Tag.ToString() == "Play")
            {
                g.DrawImage(MusicPlayer.Properties.Resources.play_icon, new Point(0, 0));
            } else
            {
                g.DrawImage(MusicPlayer.Properties.Resources.pause_icon, new Point(0, 0));
            }
            base.OnPaint(e);
        }
    }
}
