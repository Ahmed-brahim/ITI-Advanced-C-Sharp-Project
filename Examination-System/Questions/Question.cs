using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    public class Question
    {
        public string Body { get; set; }
        public Header QHeader { get; set; }
        public int Marks { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public Answer CorrectAnswer { get; set; }
        public Question(string body, Header header, int marks, List<Answer> answers, Answer correctAnswer)
        {
            Body = body;
            QHeader = header;
            Marks = marks;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
        protected Question(string body, int marks, List<Answer> answers, Answer correctAnswer)
        {
            Body = body;
            Marks = marks;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
        public Question()
        {
            
        }

        protected Question(string body, int marks, Answer correctAnswer)
        {
            Body = body;
            Marks = marks;
            CorrectAnswer = correctAnswer;
        }

        public Question(string body, int marks)
        {
            Body = body;
            Marks = marks;
        }
    }
    public enum Header
    {
        TrueOrFalse,
        ChooseOne,
        ChooseAll
    }
}
