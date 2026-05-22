namespace ReadLog.Models
{
    public class Goal
    {
        public int GoalID { get; set; }
        public int UserID { get; set; }
        public int TargetBooks { get; set; }
        public int CompletedBooks { get; set; }
        public int Year { get; set; }
    }
}