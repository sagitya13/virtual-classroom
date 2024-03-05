namespace classroom.models
{
   

    public class Assignment
    {
        public int id { get; set; }
        public int questionId { get; set; }
        public string AssignmentTitle { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal MaxPoints { get; set; }
        public int NumberOfQuestions { get; set; }
        public int result { get; set; }
    }
}
