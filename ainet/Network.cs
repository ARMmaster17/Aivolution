using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.IO;
using Accord.Neuro;
using Accord.Neuro.Learning;
using Accord.Neuro.Networks;
using Accord.Statistics;

namespace ainet
{
    public class Network
    {
        /// <summary>
        /// Network data structure that holds node configuration, weights, and neuron biases.
        /// </summary>
        private DeepBeliefNetwork _network;
        /// <summary>
        /// Learning model for unsupervised learning on hidden neurons.
        /// </summary>
        private DeepBeliefNetworkLearning _teacher;
        /// <summary>
        /// Learning model for supervised learning on entire network.
        /// </summary>
        private BackPropagationLearning _teacher2;

        private const int ReinforcedLearningIterations = 50;

        public Network(int sensorCount, int motorCount, int brainComplexity)
        {
            InitializeNetwork(sensorCount, brainComplexity, motorCount);
        }

        public Network(int sensorCount, int motorCount, int brainComplexity, DeepBeliefNetwork inheriteDeepBeliefNetwork)
        {
            // Deep clone so we have our own descendant to work with.
            _network = inheriteDeepBeliefNetwork.DeepClone();
            // Scramble weights for evolutionary variation.
            RandomizeWeights();
        }

        /// <summary>
        /// Evaluate the network based on current perception of environment.
        /// </summary>
        /// <param name="sensorInputs">Array of sensory inputs from percieved environment.</param>
        /// <returns>Motor part activation values.</returns>
        public double[] Decide(double[] sensorInputs)
        {
            return _network.Compute(sensorInputs);
        }

        /// <summary>
        /// After calling Decide(), this function should be called to reinforce the previous decision
        /// if it resulted in a positive change in percieved survivability in the organism.
        /// </summary>
        /// <param name="sensorInputs">Inputs given to network in previous Decide() call.</param>
        /// <param name="motorValues">Generated motor inputs from previous Decide() call.</param>
        public void Reinforce(double[] sensorInputs, double[] motorValues)
        {
            // Train the hidden nodes first using unsupervised learning.
            for (var layerIndex = 0; layerIndex < _network.Machines.Count - 1; layerIndex++)
            {
                _teacher.LayerIndex = layerIndex;
                double[][] trainingData = new[] {sensorInputs};
                double[][] layerData = _teacher.GetLayerInput(trainingData);
                for (int i = 0; i < ReinforcedLearningIterations; i++)
                {
                    double error = _teacher.RunEpoch(layerData);
                }
            }

            // Now train the entire network using supervised learning.
            for (var i = 0; i < ReinforcedLearningIterations; i++)
            {
                var error = _teacher2.RunEpoch(new[] {sensorInputs}, new[] {motorValues});
            }
        }

        /// <summary>
        /// After calling Decide(), this function should be called to reinforce the previous decision
        /// if it resulted in a positive change in percieved survivability in the organism.
        /// </summary>
        /// <param name="sensorInputs">Inputs given to netowrk in previous Decide() call.</param>
        public void Reinforce(double[] sensorInputs)
        {
            if (_network.Output != null)
            {
                Reinforce(sensorInputs, _network.Output);
            }
            else
            {
                throw new ArgumentNullException("motorValues", "Previous compute vectors not found for neural net. (Did you call Decide() first?)");
            }
        }

        /// <summary>
        /// Sets up the network and any needed supporting objects.
        /// </summary>
        /// <param name="sensorCount">Number of sensors on organism.</param>
        /// <param name="brainComplexity">Number of hidden neurons to include in network.</param>
        /// <param name="motorCount">Number of motor parts on organism.</param>
        private void InitializeNetwork(int sensorCount, int brainComplexity, int motorCount)
        {
            // Create a new empty network.
            _network = new DeepBeliefNetwork(sensorCount, brainComplexity, motorCount);
            // Scramble the weights.
            new GaussianWeights(_network, 0.1).Randomize();
            _network.UpdateVisibleWeights();
            // Initialize the learning algorithm to train the network.
            _teacher = new DeepBeliefNetworkLearning(_network)
            {
                Algorithm = (h, v, i) => new ContrastiveDivergenceLearning(h, v)
                {
                    LearningRate = 0.1,
                    Momentum = 0.5,
                    Decay = 0.001
                }
            };
            // Initialize supervised learning teacher.
            _teacher2 = new BackPropagationLearning(_network)
            {
                LearningRate = 0.1,
                Momentum = 0.5
            };
        }

        /// <summary>
        /// Randomizes weights in neural net computation. Utilized at initialization time and during environment-triggered shuffles.
        /// </summary>
        private void RandomizeWeights()
        {
            _network.Randomize();
        }
    }
}
