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
                private double _activationValue;
                private double _minSpeed;
                private double _maxSpeed;

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

                public virtual void Activate(double activationValue, ref Point organismLocation)
                {
                    if(activationValue >= 0.0f)
                        _activationValue = Math.Min(activationValue, 1.0f);
                    else
                        _activationValue = Math.Max(activationValue, -1.0f);
                }

                public double GetActivationValue()
                {
                    return _activationValue;
                }

                /// <summary>
                /// Calculates pain caused by current movements on a scale of 1-10.
                /// For regular Motor implementation, max pain that can be caused is from 0-2;
                /// </summary>
                /// <returns></returns>
                public virtual double CalculatePainIndex()
                {
                    return Math.Abs(_activationValue)*10/5;
                }
            }
        }
    }
}
// TODO: Remove overrides and replace with base.X() calls.
