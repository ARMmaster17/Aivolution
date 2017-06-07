using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aibio
{
    public partial class WorldView : UserControl
    {
        private bool _viewDragMode;
        private Bitmap _fullWorldView;
        private Point _viewBaseCoord;
        private Point _lastMousePosition;

        public WorldView()
        {
            InitializeComponent();
            _fullWorldView = new Bitmap(100, 100);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _lastMousePosition = MousePosition;
            _viewDragMode = true;
            RedrawWorld();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Only continue if the mouse is currently pressed down over the viewport.
            if (!_viewDragMode) return;
            // Because this is an event, we capture the current value of MousePosition
            // in case it changes while we do the calculations.
            Point currentMousePosition = MousePosition;
            // Calculate delta by finding the difference between the two points.
            Point deltaMousePosition = _lastMousePosition - (Size) currentMousePosition;
            // Use delta value to modify viewport center relative to the world.
            _viewBaseCoord += (Size) deltaMousePosition;
            // Cycle _lastMousePosition for the next movement calculation.
            _lastMousePosition = currentMousePosition;
            // Refresh the draw surface.
            RedrawWorld();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _viewDragMode = false;
            RedrawWorld();
        }

        private void WorldView_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            RedrawWorld();
        }

        private void RedrawWorld()
        {
            Bitmap bufferBitmap = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(bufferBitmap);
            g.Clear(Color.Black);
            g.FillRectangle(Brushes.Red, 50, 50, 20, 20);
            Graphics g2 = Graphics.FromImage(_fullWorldView);
            g2.DrawImage(bufferBitmap, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), new Rectangle(_viewBaseCoord, new Size(pictureBox1.Width, pictureBox1.Height)), GraphicsUnit.Pixel);
            pictureBox1.Image = _fullWorldView;
            // Invalidate the control so it gets redrawn.
            pictureBox1.Invalidate();
        }
    }
}
