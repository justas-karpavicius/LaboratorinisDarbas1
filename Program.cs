using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisDarbas1
{
	class Program
	{
        private const int ArrLength = 5;
		static void Main(string[] args)
		{
			List<Question> Questions = InOutUtils.ReadQuestions("Data.csv");
			InOutUtils.PrintData(Questions);
			List<string> MostDifficultTopics = TaskUtils.FindMostDifficultTopics(TaskUtils.
				FindTopicAverageDifficulty(TaskUtils.FindTopicTotalDifficulty(Questions)));
			InOutUtils.PrintDifficultTopics(MostDifficultTopics);
			List<Author> MostProductiveAuthors = TaskUtils.
				FindMostProductiveAuthors(TaskUtils.FindAuthors(Questions));
			InOutUtils.PrintProductiveAuthors(MostProductiveAuthors);
            Question[] SelectedQuestions = new Question[ArrLength];
			SelectedQuestions = TaskUtils.SelectQuestions(Questions, ArrLength);
			InOutUtils.PrintQuestionsToCSVFile("Results.csv", SelectedQuestions, ArrLength);
		}
	}
}
