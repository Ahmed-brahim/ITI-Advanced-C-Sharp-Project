using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Examination_System.Questions
{
    public class QuestionList : List<Question>
    {
        string _filePath;

        public QuestionList(string filePath)
        {
            _filePath = filePath;
            LoadQuestionsFromFile();
        }

        public new void Add(Question question)
        {
            base.Add(question);
            LogQuestionToFile(question);
        }

        private void LogQuestionToFile(Question question)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(_filePath))
                {
                    writer.WriteLine($"HEADER:{question.QHeader}");
                    writer.WriteLine($"BODY:{question.Body}");
                    writer.WriteLine($"MARKS:{question.Marks}");

                    // Write all answers
                    writer.WriteLine("ANSWERS_START");
                    foreach (var answer in question.Answers)
                    {
                        writer.WriteLine($"{answer.Index}:{answer.AnswerBody}");
                    }
                    writer.WriteLine("ANSWERS_END");

                    // Write correct answer
                    writer.WriteLine($"CORRECT_ANSWER:{question.getCorrectAnswersIdx()}");
                    writer.WriteLine("QUESTION_END");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to question log: {ex.Message}");
            }
        }

        private void LoadQuestionsFromFile()
        {
            if (!File.Exists(_filePath))
                return;

            try
            {
                using (StreamReader reader = File.OpenText(_filePath))
                {
                    string line;
                    Question currentQuestion = null;
                    List<Answer> currentAnswers = null;
                    bool readingAnswers = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("HEADER:"))
                        {
                            currentQuestion = new Question();
                            currentAnswers = new List<Answer>();
                            currentQuestion.QHeader = (Header)Enum.Parse(typeof(Header), line.Substring(7));
                        }
                        else if (line.StartsWith("BODY:"))
                        {
                            currentQuestion.Body = line.Substring(5);
                        }
                        else if (line.StartsWith("MARKS:"))
                        {
                            currentQuestion.Marks = int.Parse(line.Substring(6));
                        }
                        else if (line == "ANSWERS_START")
                        {
                            readingAnswers = true;
                        }
                        else if (line == "ANSWERS_END")
                        {
                            readingAnswers = false;
                            currentQuestion.Answers = currentAnswers;
                        }
                        else if (line.StartsWith("CORRECT_ANSWER:"))
                        {
                            string correctIndex = line.Substring(15); //1,2,3
                            string[] idx = correctIndex.Split(',');
                            int[] idx_ints = new int[idx.Length];
                            for(int i = 0; i < idx_ints.Length; i++)
                            {
                                idx_ints[i] = int.Parse(idx[i]);
                                currentQuestion.CorrectAnswer.Add(currentAnswers.FirstOrDefault(a => a.Index == idx_ints[i]));
                            }
                            //currentQuestion.CorrectAnswer = currentAnswers.First(a => a.Index == correctIndex);
                            base.Add(currentQuestion);
                        }
                        else if (readingAnswers)
                        {
                            var parts = line.Split(':');
                            currentAnswers.Add(new Answer(int.Parse(parts[0]), parts[1]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading questions from file: {ex.Message}");
            }
        }

        //public void SaveAllQuestions()
        //{
        //    try
        //    {
        //        // Overwrite the file with all current questions
        //        using (StreamWriter writer = new StreamWriter(_filePath, false))
        //        {
        //            foreach (var question in this)
        //            {
        //                writer.WriteLine($"HEADER:{question.QHeader}");
        //                writer.WriteLine($"BODY:{question.Body}");
        //                writer.WriteLine($"MARKS:{question.Marks}");

        //                writer.WriteLine("ANSWERS_START");
        //                foreach (var answer in question.Answers)
        //                {
        //                    writer.WriteLine($"{answer.Index}:{answer.AnswerBody}");
        //                }
        //                writer.WriteLine("ANSWERS_END");

        //                writer.WriteLine($"CORRECT_ANSWER:{question.getCorrectAnswersIdx()}");
        //                writer.WriteLine("QUESTION_END");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error saving all questions: {ex.Message}");
        //    }
        //}
        public override string ToString()
        {
            string res = new string("");
            foreach (var question in this) { 
                res += question.ToString();
            }
            return res;
        }
    }
}