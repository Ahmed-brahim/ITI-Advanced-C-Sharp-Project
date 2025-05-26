using Examination_System.Exams;
using Examination_System.Questions;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //generate subject matched with files name
            Subject s1 = new Subject("English");
            Subject s2 = new Subject("Math");
            Subject s3 = new Subject("Computer");
            Subject s4 = new Subject("History");
            Subject s5 = new Subject("Geography");
            //generate subjects list
            List<Subject> list = new List<Subject>() {s1, s2, s3, s4, s5};

            #region interfacing
            Console.WriteLine("Exam Subjects:");
            for(int i = 0; i < list.Count(); i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{i+1}) {list[i].Name}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            int choice;
            bool flag = false;
            do {
                Console.Write("enter your choice: ");
                flag = int.TryParse(Console.ReadLine(), out choice);
                if(flag && (choice < 1 || choice > list.Count()))
                {
                    flag = false;
                }
            }while(!flag);
            Console.Clear();
            int examCh = 0;
            Console.WriteLine("start With:\n1- Practical Exam\n2- Final Exam");
            do
            {
                Console.Write("Enter Your Choice:");
                flag = int.TryParse(Console.ReadLine(), out examCh);
                if (flag && (examCh < 1 || examCh > 2))
                {
                    flag = false;
                }
            } while (!flag);
            Console.Clear();
            Exam e1 = null;
            switch (examCh)
            {
                case 1:
                    e1 = new PracticalExam(20, 5, list[choice - 1]);
                    e1.ShowExam();
                    break;
                case 2:
                    e1 = new FinalExam(50, 3, list[choice - 1]); // 10 => number of questions
                    e1.ShowExam();
                    return;
            }
            #endregion
        }
    }
}












//Subject subject = new Subject("Science");
//QuestionList questions = new QuestionList($"{subject.Name}.txt");

//questions.Add(new TrueOrFalseQuestion("Humans use 100% of their brains", 2, 2));
//questions.Add(new TrueOrFalseQuestion("All bacteria are harmful to humans", 2, 2));
//List<Answer> answerList = new List<Answer>();
//answerList.Add(new Answer(1, "Answer1"));
//answerList.Add(new Answer(2, "Answer2"));
//answerList.Add(new Answer(3, "Answer3t"));
//answerList.Add(new Answer(4, "Answer4"));
//questions.Add(new ChooseAllQuestion("test choose ALl", 3, answerList, new int[] { 1, 2, 3 }));
//questions.Add(new ChooseOneQuestion("test select one question", 2, answerList, 3));
//Exam e1 = new PracticalExam(10, 5, subject, questions);
//PracticalExam p1 = new PracticalExam(20, 4, subject, questions);
//p1.ShowExam();
//Console.WriteLine(e1.questionList);