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
        public int numberOfQuestions;
        public Subject Subject;
        public QuestionList questionList;
        int score { get; set; } = -1;
        public Dictionary<Question, List<Answer>> QuestionAnswer { get; set; } = new Dictionary<Question, List<Answer>>();

        public Exam(int timeInMinutes, int numberOfQuestions, Subject subject, QuestionList questionList)
        {
            this.timeInMinutes = timeInMinutes;
            this.numberOfQuestions = numberOfQuestions;
            this.Subject = subject;
            this.questionList = questionList;
        }
        public Exam(int timeInMinutes, int numberOfQuestions, Subject subject)
        {
            this.timeInMinutes = timeInMinutes;
            this.numberOfQuestions = numberOfQuestions;
            this.Subject = subject;
            this.questionList = new QuestionList($"{subject.Name}.txt");
        }

        public virtual void ShowExam()
        { }
        public List<Answer> GetAnswers(int idx, Question q)
        {
            List<Answer> answer = new List<Answer>();
            answer.Add(q.Answers.FirstOrDefault(ans => ans.Index == idx));
            return answer;
        }
        public List<Answer> GetAnswers(int[] idx, Question q)
        {
            List<Answer> answer = new List<Answer>();
            foreach (int i in idx) {
                answer.Add(q.Answers.FirstOrDefault(ans => ans.Index == i));
            }
            return answer;
        }
        public int[] CalculateScore()
        {
            int totalScore = 0;
            int score = 0;
            foreach(var d in QuestionAnswer)
            {
                totalScore += d.Key.Marks;
                if(d.Key.QHeader == Header.ChooseOne || d.Key.QHeader == Header.TrueOrFalse)
                {
                    if (d.Key.CorrectAnswer[0] == d.Value[0])
                        score += d.Key.Marks;
                }
                else
                {
                    bool flag = false;
                    foreach(var s in d.Value)
                    {
                        if (d.Key.CorrectAnswer.Any(ans => ans == s))
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        score += d.Key.Marks;
                    }
                }
            }
            return new int[] { totalScore, score};
        }
    }
}
