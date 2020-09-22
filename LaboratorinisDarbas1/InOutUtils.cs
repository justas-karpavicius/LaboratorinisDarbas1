using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
				int  = Values.Length - 5;
				List<string> possibleAnswers
				Question question = new Question(Values[0], double.Parse(Values[1]), Values[2], Values[3],
					CamountOfPA, possibleAnswers, int.Parse(Values[8]));
				Questions.Add(question);
			}
			return Questions;
		}
	}
}
