using System;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace beer
{
    public class ButtonTimer
    {
        int seconds = 1000;
        Boolean stop = false;
        Boolean running = false;
        Button timer;

        public ButtonTimer(int seconds, Button timer)
        {
            this.timer = timer;
        }

        public void Trigger()
        {
            if (running && stop)
            {
                running = false;
                stop = false;
            }
            if (!running && !stop)
            {
                StartTimer();
                running = true;
            }
            else if (running && !stop) stop = true;
        }

        async void StartTimer()
        {
            //System.Diagnostics.Debug.WriteLine("hejsa");
            while (!stop && seconds != 0)
            {
                await Task.Delay(1000);
                seconds--;
                int m = (int)Math.Floor((double)(seconds / 60));
                int s = seconds - 60 * m;
                timer.Text = "" + m + ":" + s;
            }
            if (seconds != 0) timer.Text += " (paused)";

        }

    }
}
