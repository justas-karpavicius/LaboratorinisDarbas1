using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisDarbas1
{
	/// <summary>
	/// Program
	/// </summary>
	class Program
	{
        //Constant for length of to-be-printed
        // array of questions
        private const int ArrLength = 5; 

		/// <summary>
		/// Main function
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			List<Question> Questions = InOutUtils.ReadQuestions("Data3.csv");
			InOutUtils.PrintData(Questions, "Data.txt");
			List<string> MostDifficultTopics = TaskUtils.FindMostDifficultTopics(TaskUtils.
				FindTopicAverageDifficulty(TaskUtils.FindTopicTotalDifficulty(Questions)));
			InOutUtils.PrintDifficultTopics(MostDifficultTopics);
			List<Author> MostProductiveAuthors = TaskUtils.
				FindMostProductiveAuthors(TaskUtils.FindAuthors(Questions));
			InOutUtils.PrintProductiveAuthors(MostProductiveAuthors);
            Question[] SelectedQuestions = new Question[ArrLength];
			SelectedQuestions = TaskUtils.SelectQuestions(Questions, ArrLength);
			InOutUtils.PrintQuestionsToCSVFile("Klausimai1.csv", SelectedQuestions, ArrLength);
		}
	}
}
