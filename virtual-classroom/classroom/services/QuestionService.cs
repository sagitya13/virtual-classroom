using classroom.models;
using classroom.Repository;
using classroom.Repository.Interface;
using classroom.services.Interface;

namespace classroom.services
{
    public class QuestionService : IQuestionRepo
    {
        private readonly IQuestionRepo _questionRepo;

        public QuestionService(IQuestionRepo questionRepo)
        {
            _questionRepo = questionRepo;
        }
        
       

        public void DeleteQuestion(int id)
        {
            _questionRepo.DeleteQuestion(id);
        }

        public List<Question> GetQuestionById(int id)
        {
            return _questionRepo.GetQuestionById(id);
        }

        public List<Question> GetQuestions()
        {
            return _questionRepo.GetQuestions();
        }

        void IQuestionRepo.CreateQuestion(Question question)
        {
             _questionRepo.CreateQuestion(question);
        }

       

       
    }
    
}
