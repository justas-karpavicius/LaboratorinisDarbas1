using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace LaboratorinisDarbas1
{
	static class InOutUtils
	{
		public static List<Question> ReadQuestions(string fileName)
		{
			List<Question> Questions = new List<Question>();
			string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
				string[] Values = line.Split(';');
				Question question = new Question(Values[0], double.Parse(Values[1]),
				Values[2], Values[3], Values[4], Values[5], Values[6], Values[7], Values[8]);
				Questions.Add(question);
			}
			return Questions;
		}

		public static void PrintData(List<Question> Questions)
        {
			Console.WriteLine(new string('-', 80));
			Console.WriteLine("|{0,7}| {1,-25} | {2,-25} | {3, 12} |",
				"Eil.Nr.", "Tema", "Autorius", "Sudėtingumas");
			Console.WriteLine(new string('-', 80));
			Console.WriteLine("| {0,-76} |", "Klausimas");
			Console.WriteLine(new string('-', 80));
			Console.WriteLine("| {0, -76} |", "Atsakymo variantai:");
			Console.WriteLine(new string('-', 80));
			Console.WriteLine("| {0,-18} | {1,-16} | {2,-18} | {3,-15} |",
				"Ats.var.Nr.1", "Ats.var.Nr.2", "Ats.var.Nr.3", "Ats.var.Nr.4");
			Console.WriteLine(new string('-', 80));
			Console.WriteLine("| {0, -76} |", "Teisingas atsakymas: ...");
			Console.WriteLine(new string('-', 80));
			int count = 1;
			foreach (Question question in Questions)
            {
                Console.WriteLine("| {0, 76} |", "");
				Console.WriteLine(new string('-', 80));
				Console.WriteLine("|{0,7}| {1,-25} | {2,-25} | {3, 12:F0} |",
					count++ + ".", question.Topic, question.Author, question.Difficulty);
				Console.WriteLine(new string('-', 80));
				bool QuestionTextPrinted = false;
				int counter = 0;
				while (!QuestionTextPrinted)
				{
					Console.Write("| ");
                    for (int i = 0; i < 76; i++)
                    {
						Console.Write(question.QuestionText[counter++]);
						if(counter == question.QuestionText.Length)
                        {
							for (int j = i; j < 75; j++)
								Console.Write(" ");
							QuestionTextPrinted = true;
							break;
                        }
                    }
					Console.WriteLine(" |");
				}
				Console.WriteLine(new string('-', 80));
				Console.WriteLine("| {0, -76} |", "Atsakymo variantai:");
				Console.WriteLine(new string('-', 80));
				Console.WriteLine("| {0,-18} | {1,-16} | {2,-18} | {3,-15} |",
					question.PossibleAnswer1, question.PossibleAnswer2,
					question.PossibleAnswer3, question.PossibleAnswer4);
				Console.WriteLine(new string('-', 80));
				Console.WriteLine("| {0, -76} |", "Teisingas atsakymas: " +
					question.Answer);
				Console.WriteLine(new string('-', 80));
			}
			Console.WriteLine("");
			//foreach (Dog dog in Dogs)
			//{
			//	Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |",
			//   dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
			//}
			//Console.WriteLine(new string('-', 74));
		}
        //public static void PrintQuestions(List<Question> Questions)
        //{
        //	//Console.WriteLine("Protmūšio klausimai:");
        //	//Console.Write("--------------------------------------------------------------------------------\r\n");
        //	//Console.Write("| Tema     | Sudė-| Klausimas		              | Atsakymo    | Teisingas   |\r\n");
        //	//Console.Write("|          | tin- |			                      | Variantas   | Atsakymas   |\r\n");
        //	//Console.Write("|          | gu-  |				                  |             |             |\r\n");
        //	//Console.Write("|          | mas  |                                |             |             |\r\n");
        //	//Console.Write("--------------------------------------------------------------------------------\r\n");
        //	//foreach (Question question in Questions)
        //	//{
        //	//	Console.WriteLine("| {0,-8} | {1, 4} | {2,-30} | {3,-11} | {4,-11} |",
        //	//    question.Topic, question.Difficulty, question.QuestionText,
        //	//	question.PossibleAnswers[1], question.PossibleAnswers[question.IndexOfAnswer]);
        //	//}
        //	Console.WriteLine("Protmūšio klausimai:");
        //	foreach (Question question in Questions)
        //	{
        //		Console.WriteLine("| {0} | {1:f} | {2} | {3} | {4} | {5} | {6} | {7} | {8} |",
        //		question.Topic, question.Difficulty, question.Author,
        //		question.QuestionText, question.PossibleAnswer1, question.PossibleAnswer2,
        //		question.PossibleAnswer3, question.PossibleAnswer4, question.Answer);
        //	}
        //	Console.WriteLine("");
        //}

        //public static void PrintTopics(List<Topic> Topics)
        //      {
        //	Console.WriteLine("Protmūšio temos:");
        //	foreach (Topic topic in Topics)
        //	{
        //		Console.WriteLine("| {0} | {1:f} | {2} |",
        //              topic.TopicName, topic.AverageDifficulty, topic.AmountOfQuestions);
        //	}
        //	Console.WriteLine("");
        //}

        public static void PrintDifficultTopics(List<string> Topics)
        {
			Console.WriteLine(new string('-', 80));
			Console.WriteLine("| {0, -76} |", "Sunkiausios temos:");
			Console.WriteLine(new string('-', 80));
			foreach (string topic in Topics)
			{
				Console.WriteLine("| {0, -76} |", topic);
				Console.WriteLine(new string('-', 80));
			}
			Console.WriteLine("");
        }

        //public static void PrintAuthors(List<Author> Authors)
        //{
        //	Console.WriteLine("Protmūšio klausimų autoriai:");
        //	foreach (Author author in Authors)
        //		Console.WriteLine("| {0} | {1} |", author.AuthorName, author.AmountOfQuestions);
        //	Console.WriteLine("");
        //}

        public static void PrintProductiveAuthors(List<Author> ProductiveAuthors)
        {
			Console.WriteLine(new string('-', 80));
			Console.WriteLine("| {0, -76} |", "Daugiausia klausimų sukūrę autoriai:");
			Console.WriteLine(new string('-', 80));
			foreach (Author author in ProductiveAuthors)
			{
				Console.WriteLine("| {0, -76} |", author.AuthorName + ", " +
					author.AmountOfQuestions);
				Console.WriteLine(new string('-', 80));
			}
			Console.WriteLine("");
		}

		public static void PrintQuestionsToCSVFile(string fileName, Question[] Questions, int length)
		{
			string[] lines = new string[length + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",
            "Tema", "Sudėtingumas", "Autorius", "Klausimo tekstas",
			"Atsakymo var. nr. 1", "Atsakymo var. nr. 2", "Atsakymo var. nr. 3",
			"Atsakymo var. nr. 4", "Atsakymas");
			for (int i = 0; i < length; i++)
			{
				lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",
				Questions[i].Topic, Questions[i].Difficulty, Questions[i].Author,
				Questions[i].QuestionText, Questions[i].PossibleAnswer1,
				Questions[i].PossibleAnswer2, Questions[i].PossibleAnswer3,
				Questions[i].PossibleAnswer4, Questions[i].Answer);
			}
			File.WriteAllLines(fileName, lines, Encoding.UTF8);
		}
	}
}
