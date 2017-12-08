using System;

namespace beer
{
    public class EggWatch
    {
        int minutes;
        int seconds;
        string function = "";

        public EggWatch()
        {
        }

        public static void hejsa() {
            
        }

        public override string ToString()
        {
            return "" + minutes + ":" + seconds + " " + function;
        }
    }
}
