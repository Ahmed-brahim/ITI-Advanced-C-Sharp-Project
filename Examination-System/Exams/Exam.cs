using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exams
{
    public class Exam
    {
        //Time, number of Questions, Question Answer Dictionary(Which will be used for Exam Correction)
        int timeInMinutes;
        int numberOfQuestions;
        public Subject subject;
        public QuestionList questionList;
        int score { get; set; } = -1;

        public Exam(int timeInMinutes, int numberOfQuestions, Subject subject, QuestionList questionList)
        {
            this.timeInMinutes = timeInMinutes;
            this.numberOfQuestions = numberOfQuestions;
            this.subject = subject;
            this.questionList = questionList;
        }

        public Dictionary<Question, Answer> QuestionAnswer { get; set; }
        public virtual void ShowExam()
        { }
    }
}
