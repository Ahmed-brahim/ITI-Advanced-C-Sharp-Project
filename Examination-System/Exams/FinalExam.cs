using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exams
{
    public class FinalExam:Exam
    {
        public FinalExam(int timeInMinutes, int numberOfQuestions, Subject subject, QuestionList questionList) : base(timeInMinutes, numberOfQuestions, subject, questionList)
        {

        }

        public override void ShowExam()
        {
            base.ShowExam();
        }
    }
}
