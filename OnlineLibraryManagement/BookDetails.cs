using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    //Class
    public class BookDetails
    {

        //Field for BookID
        private static int s_bookId = 1000;

        //Properties
        public string BookID { get; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public int BookCount { get; set; }

        //Constructors
        public BookDetails(string bookName, string authorName, int bookCount)
        {
            s_bookId++;
            BookID = "BID" + s_bookId;
            BookName=bookName;
            AuthorName = authorName;
            BookCount = bookCount;
        }
    }
}