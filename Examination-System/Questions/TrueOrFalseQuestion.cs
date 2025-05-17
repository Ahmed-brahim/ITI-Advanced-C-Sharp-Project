using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    public class TrueOrFalseQuestion : Question
    { 
        
        public TrueOrFalseQuestion(string body, int marks, int correctAnswerIndex) : base(body, marks)
        {
            base.Answers.Add(new Answer(1, "True"));
            base.Answers.Add(new Answer(2, "False"));
            QHeader = Header.TrueOrFalse;
            base.CorrectAnswer = Answers.FirstOrDefault(ans => ans.Index == correctAnswerIndex);
        }
    }
}
