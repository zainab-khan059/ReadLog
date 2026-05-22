namespace ReadLog.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int BookID { get; set; }
        public int Rating { get; set; }  // 1-5
        public string Notes { get; set; }
        public DateTime DateReviewed { get; set; }
    }
}
