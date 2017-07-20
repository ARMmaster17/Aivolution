using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
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
        private bool _mouseInBounds;
        public float ZoomFactor;

        public WorldView()
        {
            InitializeComponent();
            pictureBox1.Dock = DockStyle.Fill;
            this.pictureBox1.MouseWheel += pictureBox1_MouseWheel;
            _fullWorldView = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _mouseInBounds = false;
            ZoomFactor = 100.0f;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _lastMousePosition = MousePosition;
            _viewDragMode = true;
            RedrawWorld();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _mouseInBounds = true;
            // Only continue if the mouse is currently pressed down over the viewport.
            if (!_viewDragMode) return;
            // Because this is an event, we capture the current value of MousePosition
            // in case it changes while we do the calculations.
            Point currentMousePosition = MousePosition;
            // Calculate delta by finding the difference between the two points.
            Point deltaMousePosition = Point.Subtract(currentMousePosition, (Size) _lastMousePosition);
            // Use delta value to modify viewport center relative to the world.
            _viewBaseCoord = Point.Subtract(_viewBaseCoord, (Size) deltaMousePosition);
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
            // Create the new frame in a separate buffer.
            Bitmap bufferBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            // Create graphics object to draw with.
            Graphics g = Graphics.FromImage(bufferBitmap);
            // Clear out the whole image with black.
            g.Clear(Color.Black);
            // Draw our testing rectangle.
            g.FillRectangle(Brushes.Red, new Rectangle(new Point(0, 0), new Size(40, 40)));
            Graphics g2 = Graphics.FromImage(_fullWorldView);
            g2.Clear(Color.Green);
            g2.DrawImage(bufferBitmap, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), new Rectangle(_viewBaseCoord, new Size(pictureBox1.Width * (int)(ZoomFactor / 100), pictureBox1.Height * (int)(ZoomFactor / 100))), GraphicsUnit.Pixel);
            // Set the image to the new bitmap object.
            pictureBox1.Image = _fullWorldView;
            //pictureBox1.Image = bufferBitmap;
            // Invalidate the control so it gets redrawn.
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            _mouseInBounds = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            _mouseInBounds = false;
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!_mouseInBounds) return;
            float scrollInput = e.Delta/10.0f;
            ZoomFactor += scrollInput;
            RedrawWorld();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
    }
}
