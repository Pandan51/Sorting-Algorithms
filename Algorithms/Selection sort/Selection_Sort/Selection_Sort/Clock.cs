using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Selection_Sort
{
    public class Clock
    {
        System.Timers.Timer aTimer;
        private static int timeSec = 0;
        private static bool timerElapsed;
        private static int elapseTime;


        public Clock(int intervalMS = 1000, int timeGoal = 1000)
        {
            aTimer = new System.Timers.Timer(intervalMS);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timerElapsed = false;
            elapseTime = timeGoal/1000;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Hello World!");
            timeSec++;
            if(timeSec >= elapseTime)
            {
                timerElapsed = true;
            }
        }
        public void ShowTime()
        {
            int hours = timeSec / 3600;
            int minutes = (timeSec - hours*3600) / 60;
            int seconds = timeSec % 60;
            Console.WriteLine($"HH:MM  SSSS");
            Console.WriteLine($"{hours}:{minutes}  {seconds}");
            //Console.WriteLine($"{hours*3600}:{minutes*60}  {seconds}");
        }
        public int GetTime()
        {
            return timeSec;
        }
        public void ResetTimer()
        {
            timeSec = 0;
        }
        public void StartClock()
        {
            aTimer.Enabled = true;
        }
        public void StopClock()
        {
            aTimer.Enabled = false;
        }
        public bool IsElapsed()
        {
            return timerElapsed;
        }
        public void RepeatedShowTime()
        {
            Console.Clear();
            this.ShowTime();
            Console.WriteLine(this.IsElapsed());
        }
    }
}
