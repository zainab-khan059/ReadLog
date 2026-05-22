namespace ReadLog.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }  // "Read", "Reading", "Want to Read"
        public int TotalPages { get; set; }
        public string CoverPath { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
