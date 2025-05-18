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

            //questions.Add(new TrueOrFalseQuestion("Humans use 100% of their brains", 2, 2));
            //questions.Add(new TrueOrFalseQuestion("All bacteria are harmful to humans", 2, 2));
            List<Answer> answerList = new List<Answer>();
            answerList.Add(new Answer(1, "Answer1"));
            answerList.Add(new Answer(2, "Answer2"));
            answerList.Add(new Answer(3, "Answer3t"));
            answerList.Add(new Answer(4, "Answer4"));
            //questions.Add(new ChooseAllQuestion("test choose ALl", 3, answerList, new int[] { 1, 2, 3 }));
            //questions.Add(new ChooseOneQuestion("test select one question", 2, answerList, 3));
            //Exam e1 = new PracticalExam(10, 5, subject, questions);
            PracticalExam p1 = new PracticalExam(20, 4, subject, questions);
            p1.ShowExam();
            //Console.WriteLine(e1.questionList);
        }
    }
}
