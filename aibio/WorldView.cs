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
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _viewDragMode = false;
        }

        private void WorldView_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
