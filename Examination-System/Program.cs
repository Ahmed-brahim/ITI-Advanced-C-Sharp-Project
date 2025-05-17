using Examination_System.Exams;
using Examination_System.Questions;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject("Science");
            QuestionList questions = new QuestionList($"{subject.Name}.txt");
            questions.Add(new TrueOrFalseQuestion("Humans use 100% of their brains", 2, 2));
            questions.Add(new TrueOrFalseQuestion("All bacteria are harmful to humans", 2, 2));
            Exam e1 = new PracticalExam(10, 5, subject, questions);
        }
    }
}
