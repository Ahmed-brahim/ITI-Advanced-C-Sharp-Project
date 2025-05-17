using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Answer
    {
        public int Index {  get; set; }
        public string AnswerBody {  get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null || obj.GetType() != typeof(Answer))
                return false;
            Answer other = (Answer)obj;
            return this.Index == other.Index && this.AnswerBody == other.AnswerBody;
        }
    }
}
