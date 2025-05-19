using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
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
        public List<Answer> CorrectAnswer { get; set; } = new List<Answer>();
        #region Constructors
        public Question()
        {

        }
        public Question(string body, Header header, int marks, List<Answer> answers, Answer correctAnswer)
        {
            Body = body;
            QHeader = header;
            Marks = marks;
            Answers = answers;
            CorrectAnswer.Add(correctAnswer);
        }
        public Question(string body, int marks, List<Answer> answers)
        {
            Body = body;
            Marks = marks;
            Answers = answers;
        }
        protected Question(string body, int marks, List<Answer> answers, Answer correctAnswer)
        {
            Body = body;
            Marks = marks;
            Answers = answers;
            CorrectAnswer.Add(correctAnswer);
        }

        protected Question(string body, int marks, Answer correctAnswer)
        {
            Body = body;
            Marks = marks;
            CorrectAnswer.Add(correctAnswer);
        }

        public Question(string body, int marks)
        {
            Body = body;
            Marks = marks;
        }
        #endregion
        #region Metods
        public string getCorrectAnswersIdx()
        {
            int[] idx = new int[CorrectAnswer.Count()];
            for(int i = 0; i < idx.Length; i++)
            {
                idx[i] = CorrectAnswer[i].Index;
            }
            return string.Join(',', idx); 
        }
        public void PrintExamQuestion(int index)
        {
            Console.WriteLine($"{index}- {QHeader}: {Body}");
            foreach(var ans in Answers)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(ans);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        #endregion
        public override string ToString()
        {
            string ans = string.Empty;
            string Cans = string.Empty;
            foreach(var i in Answers)
            {
                ans += i.ToString();
            }
            foreach(var i in CorrectAnswer)
            { 
                Cans += i.ToString();
            }
            return $"-header:{this.QHeader}\n-Body: {Body}\n-answers: {ans}\n-Marks: {Marks}\n-Correct Answer: {Cans}\n\n";
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            Question question = obj as Question;
            return  question.Body == this.Body && question.QHeader == this.QHeader && question.Marks == this.Marks;
        }
        public string PrintCorrectAns()
        {
            string Cans = null;
            foreach (var i in CorrectAnswer)
            {
                Cans += i.ToString();
            }
            return Cans;
        }
    }
    public enum Header
    {
        TrueOrFalse,
        ChooseOne,
        ChooseAll
    }
}
