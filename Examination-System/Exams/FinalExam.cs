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
        public FinalExam(int timeInMinutes, int numberOfQuestions, Subject subject) : base(timeInMinutes, numberOfQuestions, subject)
        {
        }

        public FinalExam(int timeInMinutes, int numberOfQuestions, Subject subject, QuestionList questionList) : base(timeInMinutes, numberOfQuestions, subject, questionList)
        {

        }

        public override void ShowExam()
        {
            //show questions
            for (int i = 0; i < numberOfQuestions; i++)
            {
                questionList[i].PrintExamQuestion(i + 1);
                Console.WriteLine();
                bool flag = true;
                //take answer
                int AnswerIdx;
                switch (questionList[i].QHeader)
                {
                    case Header.TrueOrFalse:
                        do
                        {
                            Console.Write("Enter your answer:");
                            flag = int.TryParse(Console.ReadLine(), out AnswerIdx);
                            if (AnswerIdx < 1 || AnswerIdx > 2)
                            {
                                flag = false;
                            }
                        } while (!flag);
                        QuestionAnswer.Add(questionList[i], base.GetAnswers(AnswerIdx, questionList[i]));
                        break;
                    case Header.ChooseOne:
                        do
                        {
                            Console.Write("Enter your answer:");
                            flag = int.TryParse(Console.ReadLine(), out AnswerIdx);
                            if (AnswerIdx < 1 || AnswerIdx > 4)
                            {
                                flag = false;
                            }
                        } while (!flag);
                        QuestionAnswer.Add(questionList[i], base.GetAnswers(AnswerIdx, questionList[i]));
                        break;
                    case Header.ChooseAll:
                        do
                        {
                            Console.Write("Enter your answer separated by comma (ex: 1,2,..):");
                            string answerString = Console.ReadLine();  //string
                            string[] ansSplit = answerString.Split(','); //string array
                            int[] ints = new int[ansSplit.Length];
                            for (int k = 0; k < ansSplit.Length; k++) //int array of idxs
                            {
                                flag = int.TryParse(ansSplit[k], out ints[k]);
                                if (!flag || ints[k] < 0 || ints[k] > 4) //check
                                {
                                    break;
                                }
                            }
                            if (flag)
                            {
                                QuestionAnswer.Add(questionList[i], base.GetAnswers(ints, questionList[i]));
                            }
                        } while (!flag);

                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("Congratulations you finished the Exam");
            Console.WriteLine();
            int[] scores = base.CalculateScore(); //0 => total score    1 => student score
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nYour Score is {scores[1]} from {scores[0]}");
            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}
