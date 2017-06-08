using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aibio.Units.Sensors;
using aibio.Units.Motors;
using ainet;

namespace aibio
{
    public class Organism
    {
        private Network _brainNetwork;
        private Sensor[] _sensors;
        private Motor[] _motors;

        private double _previousSurvivability;
        private double[] _previousSensorInputs;
        private double[] _previousMotorOutputs;

        private Point _worldLocation;

        public Organism(Point location, Sensor[] sensors, Motor[] motors, int complexity = 20)
        {
            _brainNetwork = new Network(sensors.Length, motors.Length, complexity);
            _sensors = sensors;
            _motors = motors;
            _previousSurvivability = 0;
            _worldLocation = location;
        }

        /// <summary>
        /// Inherited update function. Takes care of updating the state of the organism.
        /// </summary>
        public void Update()
        {
            // Check to see if our actions from last iteration changed our percieved survivability.
            double newSurvivability = CalculateSurvivability();
            // Verify by comparing it to the previous survivability count.
            if (newSurvivability > _previousSurvivability)
            {
                // Our actions last iteration improved our situation, reinforce it in the neural network
                _brainNetwork.Reinforce(_previousSensorInputs, _previousMotorOutputs);
            }
            // Finally, move our current survivability into the temporary one.
            _previousSurvivability = newSurvivability;

            // Update sensors so we have fresh data.
            UpdateSensors();
            // Poll the sensors.
            double[] sensorData = PollSensors();
            // Run sensor data through the network and decide what action to take.
            double[] requestedMovements = _brainNetwork.Decide(sensorData);
            // Activate motors.
            ActivateMotors(requestedMovements);

            // Store all data so it can be utilized in the next Update() iteration.
            _previousSensorInputs = sensorData;
            _previousMotorOutputs = requestedMovements;
        }

        /// <summary>
        /// Calls the Update() function on all sensors. This function is separate from PollSensors()
        /// because it only needs to be called once per iteration.
        /// </summary>
        private void UpdateSensors()
        {
            foreach (Sensor t in _sensors)
            {
                t.Update(_worldLocation);
            }
        }

        /// <summary>
        /// Polls all sensors for their impulse value.
        /// </summary>
        /// <returns>Array of all current sensor values.</returns>
        private double[] PollSensors()
        {
            // Create an array to hold the result.
            double[] result = new double[_sensors.Length];
            // Iterate through all sensors, getting their impulse values.
            for (int i = 0; i < _sensors.Length; i++)
            {
                result[i] = _sensors[i].GetImpulse();
            }
            // Return result as a double array.
            return result;
        }

        /// <summary>
        /// Activates motors based on result of ANN or manual movement specification.
        /// </summary>
        /// <param name="motorActivationValues">Array of motor activation values for each motor.</param>
        private void ActivateMotors(double[] motorActivationValues)
        {
            // Apply the motor values sequentially. The order doesn't really matter as long
            // as we are conistant. The ANN should be able to figure out the rest itself.
            for (int i = 0; i < _motors.Length; i++)
            {
                _motors[i].Activate(motorActivationValues[i], ref _worldLocation);
            }
        }

        /// <summary>
        /// Calculates current state of the organism (as percieved by sensors onboard the body).
        /// </summary>
        /// <returns>Percieved survivability.</returns>
        private double CalculateSurvivability()
        {
            // TODO: calculate survivabillity.
            return 0.0f;
        }
    }
}
