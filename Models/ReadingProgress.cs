namespace ReadLog.Models
{
    public class ReadingProgress
    {
        public int ProgressID { get; set; }
        public int BookID { get; set; }
        public int PagesRead { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}