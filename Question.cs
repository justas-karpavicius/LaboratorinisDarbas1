using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisDarbas1
{
	/// <summary>
	/// Class defining a question
	/// </summary>
	class Question
	{
		public string Topic { get; set; }
		public double Difficulty { get; set; }
		public string Author { get; set; }
		public string QuestionText { get; set; }
		public string PossibleAnswer1 { get; set; }
		public string PossibleAnswer2 { get; set; }
		public string PossibleAnswer3 { get; set; }
		public string PossibleAnswer4 { get; set; }
		public string Answer { get; set; }

		/// <summary>
		/// Constructor for Question class objects
		/// </summary>
		/// <param name="topic"></param>
		/// <param name="difficulty"></param>
		/// <param name="author"></param>
		/// <param name="questionText"></param>
		/// <param name="possibleAnswer1"></param>
		/// <param name="possibleAnswer2"></param>
		/// <param name="possibleAnswer3"></param>
		/// <param name="possibleAnswer4"></param>
		/// <param name="answer"></param>
		public Question(string topic, double difficulty, string author, string questionText,
			string possibleAnswer1, string possibleAnswer2, string possibleAnswer3,
			string possibleAnswer4, string answer)
		{
			this.Topic = topic;
			this.Difficulty = difficulty;
			this.Author = author;
			this.QuestionText = questionText;
			this.PossibleAnswer1 = possibleAnswer1;
			this.PossibleAnswer2 = possibleAnswer2;
			this.PossibleAnswer3 = possibleAnswer3;
			this.PossibleAnswer4 = possibleAnswer4;
			this.Answer = answer;
		}
	}
}		
