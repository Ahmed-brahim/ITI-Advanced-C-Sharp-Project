using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    public class ChooseAllQuestion:Question
    {
        public ChooseAllQuestion(string body, int marks, List<Answer> answers, int[] correctAnswerIdx) : base(body, marks, answers)
        {
            QHeader = Header.ChooseAll;
            for(int i = 0; i < correctAnswerIdx.Length; i++)
            {
                CorrectAnswer.Add(answers.FirstOrDefault(ans => ans.Index == correctAnswerIdx[i]));
            }
        }
    }
}
