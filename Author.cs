using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisDarbas1
{
    class Author
    {
        public string AuthorName { get; set; }
        public int AmountOfQuestions { get; set; }
        public Author(string author, int amount)
        {
            this.AuthorName = author;
            this.AmountOfQuestions = amount;
        }
    }
}
