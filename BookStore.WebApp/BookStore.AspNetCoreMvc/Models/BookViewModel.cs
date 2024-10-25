namespace BookStore.AspNetCoreMvc.Models
{
    public class BookViewModel
    {
        public string Name { get; set; }

        public string BookType { get; set; }

        public string Authour { get; set; }

        public DateOnly PuslisherDate { get; set; }

        public string BookPublisherName { get; set; }

        public short BookPage { get; set; }

        public bool Status { get; set; }
    }
}
