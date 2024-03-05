using classroom.models;

namespace classroom.Repository.Interface
{
    public interface IQuestionRepo

    {
        public void CreateQuestion(Question question);
        public List<Question> GetQuestionById(int id);
        void DeleteQuestion(int id);
        public List<Question> GetQuestions();
    }

    }

