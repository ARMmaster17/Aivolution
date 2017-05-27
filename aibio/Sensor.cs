using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aibio
{
    namespace units
    {
        public abstract class Sensor : Biopart
        {
            public Sensor() : base()
            {
                
            }

            public abstract double GetImpulseValue();

            public override void Update()
            {
                // Do sensing stuff.
                base.Update();
            }

            public override void Draw()
            {
                base.Draw();
            }
        }
    }
}
