using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisDarbas1
{
    /// <summary>
    /// Class defining static methods used to complete tasks of program.
    /// </summary>
    class TaskUtils
    {
        /// <summary>
        /// Returns list of topics, with name, total difficulty and amount
        /// of questions.
        /// </summary>
        /// <param name="Questions">List of questions</param>
        /// <returns>List<Topic></returns>
        public static List<Topic> FindTopicTotalDifficulty(List<Question> Questions)
        {
            List<Topic> Topics = new List<Topic>();
            foreach (Question question in Questions)
            {
                //If topic already exists in new list, add to average,
                //else, add new topic to list, set difficulty to current topic
                //difficulty, set amount of questions to 1
                if (Topics.Any(topic => topic.TopicName == question.Topic))
                {
                    //finds index of already existing topic
                    int index = Topics.FindIndex(topic => topic.TopicName == question.Topic);
                    Topics[index].AverageDifficulty += question.Difficulty;
                    Topics[index].AmountOfQuestions++;
                }
                else
                    Topics.Add(new Topic(question.Topic, question.Difficulty, 1));
            }
            return Topics;
        }

        /// <summary>
        /// Finds average difficulty for each topic.
        /// </summary>
        /// <param name="Topics">List of topics with calculated total difficulty</param>
        /// <returns>List of topics with calculated average difficulty</returns>
        public static List<Topic> FindTopicAverageDifficulty(List<Topic> Topics)
        {
            foreach (Topic topic in Topics)
                topic.AverageDifficulty /= topic.AmountOfQuestions;
            return Topics;
        }

        /// <summary>
        /// Returns list of most difficult topics
        /// </summary>
        /// <param name="Topics">List of topics with calculated average difficulty</param>
        /// <returns>List of most difficult topics (one most difficult or
        /// multiple if same difficulty)</returns>
        public static List<string> FindMostDifficultTopics(List<Topic> Topics)
        {
            List<string> DifficultTopics = new List<string>();
            //set initial maximum difficulty for comparisons
            double maxDifficulty = Topics.First().AverageDifficulty;
            foreach (Topic topic in Topics)
            {
                //if found more difficult topic, remove others, add current
                //unless same difficulty as previous most difficult topic, then add
                if (topic.AverageDifficulty > maxDifficulty)
                {
                    DifficultTopics.Clear();
                    DifficultTopics.Add(topic.TopicName);
                    maxDifficulty = topic.AverageDifficulty;
                }
                else if (topic.AverageDifficulty == maxDifficulty)
                    DifficultTopics.Add(topic.TopicName);
            }
            return DifficultTopics;
        }

        /// <summary>
        /// Returns list of authors
        /// </summary>
        /// <param name="Questions">List of questions</param>
        /// <returns>List of authors</returns>
        public static List<Author> FindAuthors(List<Question> Questions)
        {
            List<Author> Authors = new List<Author>();
            foreach (Question question in Questions)
            {
                //if author exists, add to his AmountOfQuestions
                //else, add new author, set amount of questions to 1
                if (Authors.Any(author => author.AuthorName == question.Author))
                {
                    //finds index of existing author
                    int index = Authors.FindIndex(author => author.AuthorName == question.Author);
                    Authors[index].AmountOfQuestions++;
                }
                else
                    Authors.Add(new Author(question.Author, 1));
            }
            return Authors;
        }

        /// <summary>
        /// Returns list of authors with most created questions
        /// </summary>
        /// <param name="Authors">List of authors</param>
        /// <returns>List of authors with most created questions</returns>
        public static List<Author> FindMostProductiveAuthors(List<Author> Authors)
        {
            List<Author> ProductiveAuthors = new List<Author>();
            //set initial highest amount of questions attributed to author for
            //comparisons
            int maxProductivity = Authors.First().AmountOfQuestions;
            foreach (Author author in Authors)
            {
                //if author is more productive, clear existing list, add new
                //author
                //if author is just as productive, add to list
                if (author.AmountOfQuestions > maxProductivity)
                {
                    ProductiveAuthors.Clear();
                    ProductiveAuthors.Add(author);
                    maxProductivity = author.AmountOfQuestions;
                }
                else if (author.AmountOfQuestions == maxProductivity)
                    ProductiveAuthors.Add(author);
            }
            return ProductiveAuthors;
        }

        /// <summary>
        /// Returns a specified number of randomly selected questions
        /// </summary>
        /// <param name="Questions">List of questions</param>
        /// <param name="length">Number of questions to selected</param>
        /// <returns>Specified number of randomly selected questions</returns>
        public static Question[] SelectQuestions(List<Question> Questions, int length)
        {
            Question[] SelectedQuestions = new Question[length];
            int[] RandomNumbers = new int[length]; //array of unique random numbers
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int r = random.Next(0, Questions.Count);
                //while generated random number already exists, generate new
                while (Array.Exists(RandomNumbers, element => element == r))
                    r = random.Next(0, Questions.Count);
                SelectedQuestions[i] = Questions[r];
            }
            return SelectedQuestions;
        }
    }
}
