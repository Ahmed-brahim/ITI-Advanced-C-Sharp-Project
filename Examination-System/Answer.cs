using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Answer
    {
        int index;
        public string AnswerBody {  get; set; }
        public int Index { 
            get { return index; }
            set {
                if(value > 0 && value < 5)
                    index = value;
                else
                    Console.WriteLine("Index must be between 1 and 4");
            }
        }
        public Answer(int index, string answerBody)
        {
            Index = index;
            AnswerBody = answerBody;
        }
        public override string ToString()
        {
            return $"\n   {index}) {this.AnswerBody}";
        }
        public override bool Equals(object? obj)
        {
            if(obj == null || obj.GetType() != typeof(Answer))
                return false;
            Answer other = (Answer)obj;
            return this.Index == other.Index && this.AnswerBody.ToLower() == other.AnswerBody.ToLower();
        }
    }
}
