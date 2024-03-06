using classroom.models;




namespace classroom.services.Interface
{
    public interface IQuestionnService
    {
        public void CreateQuestion(Question question); 
        void DeleteQuestion(int id);
        public List<Question> GetQuestions();
    }
}