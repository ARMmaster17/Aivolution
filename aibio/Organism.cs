using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aibio.units;
using ainet;

namespace aibio
{
    public class Organism
    {
        private Network _brainNetwork;
        private Sensor[] _sensors;
        private Motor[] _motors;

        public Organism(Sensor[] sensors, Motor[] motors, int complexity = 20)
        {
            _brainNetwork = new Network(sensors.Length, motors.Length, complexity);
            _sensors = sensors;
            _motors = motors;
        }

        public void Update()
        {
            // TODO: Stretch survivability testing across 2 simulation iterations.
            double[] requestedMovements = _brainNetwork.Decide(PollSensors());
        }

        private double[] PollSensors()
        {
            double[] result = new double[_sensors.Length];
            for (int i = 0; i < _sensors.Length; i++)
            {
                result[i] = _sensors[i].GetImpulseValue();
            }
            return result;
        }
    }
}
