using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorinisDarbas1
{
    /// <summary>
    /// Class defining author
    /// </summary>
    class Author
    {
        public string AuthorName { get; set; }
        public int AmountOfQuestions { get; set; }

        /// <summary>
        /// Constructor for Author class objects
        /// </summary>
        /// <param name="author"></param>
        /// <param name="amount"></param>
        public Author(string author, int amount)
        {
            this.AuthorName = author;
            this.AmountOfQuestions = amount;
        }
    }
}
