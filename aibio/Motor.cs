using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aibio
{
    namespace units
    {
        public abstract class Motor : Biopart
        {
            public Motor() : base()
            {

            }

            public override void Update()
            {
                // Do movement stuff.
                base.Update();
            }

            public override void Draw()
            {
                base.Draw();
            }

            public abstract void Activate(double activationValue);
        }
    }
}
