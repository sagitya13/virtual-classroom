using classroom.models;

namespace classroom.Repository.Interface
{
    public interface IQuestionRepo

    {
        public void CreateQuestion(Question question);
        void DeleteQuestion(int id);
        public List<Question> GetQuestions();
    }

    }

