using classroom.models;




namespace classroom.services.Interface
{
    public interface IQuestionnService
    {
        public void CreateQuestion(Question question);
        public void GetQuestionById(int id);
        void DeleteQuestion(int id);
        public List<Question> GetQuestions();
    }
}