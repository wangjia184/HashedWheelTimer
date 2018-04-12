using System;

using HWT;
namespace HashWheelTimerApp
{

    class Program
    {


        /// <summary>
        /// Task fired repeatedly
        /// </summary>
        class IntervalTimerTask : TimerTask
        {
            public void Run(Timeout timeout)
            {
                Console.WriteLine($"IntervalTimerTask is fired at {DateTime.UtcNow.Ticks / 10000000L}");
                timeout.Timer.NewTimeout(this, TimeSpan.FromSeconds(2));
            }
        }

        /// <summary>
        /// Task only be fired for one time
        /// </summary>
        class OneTimeTask : TimerTask
        {
            readonly string _userData;
            public OneTimeTask(string data)
            {
                _userData = data;
            }

            public void Run(Timeout timeout)
            {
                Console.WriteLine($"{_userData} is fired at {DateTime.UtcNow.Ticks / 10000000L}");
            }
        }


        static void Main(string[] args)
        {
            HashedWheelTimer timer = new HashedWheelTimer( TimeSpan.FromSeconds(1), 5, 0);

            timer.NewTimeout(new OneTimeTask("A"), TimeSpan.FromSeconds(5));
            timer.NewTimeout(new OneTimeTask("B"), TimeSpan.FromSeconds(4));
            var timeout = timer.NewTimeout(new OneTimeTask("C"), TimeSpan.FromSeconds(3));
            timer.NewTimeout(new OneTimeTask("D"), TimeSpan.FromSeconds(2));
            timer.NewTimeout(new OneTimeTask("E"), TimeSpan.FromSeconds(1));

            timeout.Cancel();

            timer.NewTimeout(new IntervalTimerTask(), TimeSpan.FromSeconds(5));
            Console.WriteLine($"{DateTime.UtcNow.Ticks / 10000000L} : Started");
            Console.ReadKey();
        }



    }

    
}
