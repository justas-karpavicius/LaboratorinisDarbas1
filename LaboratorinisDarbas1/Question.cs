using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisDarbas1
{
	class Question
	{
		public string Topic { get; set; }
		public double Difficulty { get; set; }
		public string Author { get; set; }
		public string QuestionText { get; set; }
		public List<string> PossibleAnswers { get; set; }
		public int IndexOfAnswer { get; set; }

		public Question(string topic, double difficulty, string author, string questionText,
			List<string> possibleAnswers, int indexOfAnswer)
		{
			this.Topic = topic;
			this.Difficulty = difficulty;
			this.Author = author;
			this.QuestionText = questionText;
			this.PossibleAnswers = possibleAnswers;
			this.IndexOfAnswer = indexOfAnswer;
		}
	}
}		
