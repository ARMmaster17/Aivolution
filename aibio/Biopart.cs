using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace aibio
{
    namespace Units
    {
        /// <summary>
        /// Abstract class for all biological parts attached to organisms.
        /// </summary>
        public abstract class Biopart
        {
            public Biopart()
            {
                
            }

            public virtual void Update(Point organismCenter)
            {
                
            }

            public virtual void Draw(ref Graphics g, Point organismCenter)
            {
                
            }
        }
    }
}
