using System.Collections.Generic;

namespace QuizLibraryHost
{
    public interface IQuestionRepository
    {

        void AddQuestion(Question newQuestion);
        void DeleteQuestion(int id);

        // Lokesh : added for the view model for the user
        // The below statement only works if the GetQuestion () call is invoked from the repository
        // this also means that the viewmodel has to be created first before the repository 
        QuestionViewModel GetQuestion();
        
        // Lokesh : end added

        // Lokesh note : the method bellow will be used both by Webapi as well as MvC
        // but in different methods in the EfRepository to call the Question 
        Question GetQuestionById(int id);

        // Lokesh : end note
        List<Question> GetQuestions();
        void UpdateQuestion(Question UpdateQuestion);


       //        List<Question> GetQuestions(int maxNumberOfQuestions);
    
    }
}