using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    public class ChooseOneQuestion:Question
    {
        public ChooseOneQuestion(string body, int marks, List<Answer> answers, int correctAnsewrIndex):base(body, marks, answers)
        {
            QHeader = Header.ChooseOne;
            CorrectAnswer.Add(answers.FirstOrDefault(ans => ans.Index == correctAnsewrIndex));
        }
    }
}
