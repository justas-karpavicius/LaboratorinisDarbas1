using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace LaboratorinisDarbas1
{
	/// <summary>
	/// Static class containing methods for input / output
	/// </summary>
	static class InOutUtils
	{
        /// <summary>
        /// Reads list of questions
        /// </summary>
        /// <param name="fileName">Name of input file</param>
        /// <returns>List of questions</returns>
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

		/// <summary>
		/// Prints input data to separate txt file
		/// </summary>
		/// <param name="Questions">List of questions</param>
		/// <param name="fileName">Name of txt file for output</param>
		public static void PrintData(List<Question> Questions, string fileName)
        {
			StreamWriter sw = new StreamWriter(@"C:\Users\Admins\source\repos\Objektinis programavimas 1\L1\LaboratorinisDarbas1\LaboratorinisDarbas1\" + fileName, false, Encoding.UTF8);
			//Prints initial template of data table
			sw.WriteLine(new string('-', 80));
			sw.WriteLine("|{0,7}| {1,-25} | {2,-25} | {3, 12} |",
				"Eil.Nr.", "Tema", "Autorius", "Sudėtingumas");
			sw.WriteLine(new string('-', 80));
			sw.WriteLine("| {0,-76} |", "Klausimas");
			sw.WriteLine(new string('-', 80));
			sw.WriteLine("| {0, -76} |", "Atsakymo variantai:");
			sw.WriteLine(new string('-', 80));
			sw.WriteLine("| {0,-18} | {1,-16} | {2,-18} | {3,-15} |",
				"Ats.var.Nr.1", "Ats.var.Nr.2", "Ats.var.Nr.3", "Ats.var.Nr.4");
			sw.WriteLine(new string('-', 80));
			sw.WriteLine("| {0, -76} |", "Teisingas atsakymas: ...");
            sw.WriteLine(new string('-', 80));
			//Prints data formatted into table
			int count = 1;
			foreach (Question question in Questions)
            {
                sw.WriteLine("| {0, 76} |", "");
				sw.WriteLine(new string('-', 80));
				sw.WriteLine("|{0,7}| {1,-25} | {2,-25} | {3, 12:F0} |",
					count++ + ".", question.Topic, question.Author, question.Difficulty);
				sw.WriteLine(new string('-', 80));
				//breaks lines when question text doesn't fit into one line
				bool QuestionTextPrinted = false;
				int counter = 0;
				while (!QuestionTextPrinted)
				{
					sw.Write("| ");
                    for (int i = 0; i < 76; i++)
                    {
						sw.Write(question.QuestionText[counter++]);
						if(counter == question.QuestionText.Length)
                        {
							for (int j = i; j < 75; j++)
								sw.Write(" ");
							QuestionTextPrinted = true;
							break;
                        }
                    }
					sw.WriteLine(" |");
				}
				sw.WriteLine(new string('-', 80));
				sw.WriteLine("| {0, -76} |", "Atsakymo variantai:");
				sw.WriteLine(new string('-', 80));
				sw.WriteLine("| {0,-18} | {1,-16} | {2,-18} | {3,-15} |",
					question.PossibleAnswer1, question.PossibleAnswer2,
					question.PossibleAnswer3, question.PossibleAnswer4);
				sw.WriteLine(new string('-', 80));
				sw.WriteLine("| {0, -76} |", "Teisingas atsakymas: " + question.Answer);
				sw.WriteLine(new string('-', 80));
			}
			sw.Close();
		}
        
		/// <summary>
		/// Prints list of most difficult topics to console
		/// </summary>
		/// <param name="Topics">List of most difficult topics</param>
        public static void PrintDifficultTopics(List<string> Topics)
        {
			Console.OutputEncoding = Encoding.UTF8; //Allows Lithuanian alphabet
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

        /// <summary>
        /// Prints list of most productive authors to console
        /// </summary>
        /// <param name="ProductiveAuthors">List of most productive authors</param>
        public static void PrintProductiveAuthors(List<Author> ProductiveAuthors)
        {
			Console.OutputEncoding = Encoding.UTF8; //Allows Lithuanian alphabet
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

        /// <summary>
        /// Prints array of questions to CSV file
        /// </summary>
        /// <param name="fileName">Output file name</param>
        /// <param name="Questions">Array of questions</param>
        /// <param name="length">Length of array</param>
        public static void PrintQuestionsToCSVFile(string fileName, Question[] Questions, int length)
		{
			Console.OutputEncoding = Encoding.UTF8; //Allows Lithuanian alphabet
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
