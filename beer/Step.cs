using System;
using System.Collections.Generic;

namespace beer
{
    public class Step
    {
        public string text;
        public int minutes;

        public Step(string text, int minutes )
        {
            this.text = text;
            this.minutes = minutes;
        }
    }
}
