using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    public class ChooseAllQuestion:Question
    {
        public ChooseAllQuestion(string body, int marks, List<Answer> answers, Answer correctAnswer) : base(body, marks, answers, correctAnswer)
        {
            QHeader = Header.ChooseOne;
        }
    }
}
