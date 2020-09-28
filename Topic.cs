using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisDarbas1
{
    /// <summary>
    /// Class defining a topic
    /// </summary>
    class Topic
    {
        public string TopicName { get; set; }
        public double AverageDifficulty { get; set; }
        public int AmountOfQuestions { get; set; }

        /// <summary>
        /// Constructor for Topic class objects
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="average"></param>
        /// <param name="amount"></param>
        public Topic (string topic, double average, int amount)
        {
            this.TopicName = topic;
            this.AverageDifficulty = average;
            this.AmountOfQuestions = amount;
        }
    }
}
