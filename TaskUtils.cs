using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisDarbas1
{
    class TaskUtils
    {
        public static List<Topic> FindTopicTotalDifficulty(List<Question> Questions)
        {
            List<Topic> Topics = new List<Topic>();
            foreach (Question question in Questions)
            {
                if (Topics.Any(topic => topic.TopicName == question.Topic))
                {
                    Topics[Topics.FindIndex(topic => topic.TopicName == question.Topic)].AverageDifficulty += question.Difficulty;
                    Topics[Topics.FindIndex(topic => topic.TopicName == question.Topic)].AmountOfQuestions++;
                }
                else
                    Topics.Add(new Topic(question.Topic, question.Difficulty, 1));
            }
            return Topics;
        }

        public static List<Topic> FindTopicAverageDifficulty(List<Topic> Topics)
        {
            foreach (Topic topic in Topics)
                topic.AverageDifficulty /= topic.AmountOfQuestions;
            return Topics;
        }

        public static List<string> FindMostDifficultTopics(List<Topic> Topics)
        {
            List<string> DifficultTopics = new List<string>();
            double maxDifficulty = Topics.First().AverageDifficulty;
            foreach (Topic topic in Topics)
            {
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

        public static List<Author> FindAuthors(List<Question> Questions)
        {
            List<Author> Authors = new List<Author>();
            foreach (Question question in Questions)
            {
                if (Authors.Any(author => author.AuthorName == question.Author))
                {
                    Authors[Authors.FindIndex(author => author.AuthorName == question.Author)].AmountOfQuestions++;
                }
                else
                    Authors.Add(new Author(question.Author, 1));
            }
            return Authors;
        }

        public static List<Author> FindMostProductiveAuthors(List<Author> Authors)
        {
            List<Author> ProductiveAuthors = new List<Author>();
            int maxProductivity = Authors.First().AmountOfQuestions;
            foreach (Author author in Authors)
            {
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

        public static Question[] SelectQuestions(List<Question> Questions, int length)
        {
            Question[] SelectedQuestions = new Question[length];
            int[] RandomNumbers = new int[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int r = random.Next(0, Questions.Count);
                while (RandomNumbers.Contains(r))
                    r = random.Next(0, Questions.Count);
                SelectedQuestions[i] = Questions[r];
            }
            return SelectedQuestions;
        }
    }
}
