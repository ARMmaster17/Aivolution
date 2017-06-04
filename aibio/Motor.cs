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
        namespace Motors
        {
            public abstract class Motor : Biopart
            {
                public Motor() : base()
                {

                }

                public override void Update(Point organismCenter)
                {
                    // Do movement stuff.
                    base.Update(organismCenter);
                }

                public override void Draw(ref Graphics g, Point organismCenter)
                {
                    base.Draw(ref g, organismCenter);
                }

                public abstract void Activate(double activationValue);
            }
        }
    }
}
// TODO: Remove overrides and replace with base.X() calls.
