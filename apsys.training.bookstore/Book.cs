using System;

namespace apsys.training.bookstore
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public Book Author { get; set; }
    }
}
