using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWeapon.Utils
{
    public class Time
    {
        private double _prevTime;
        private double _currentTime;

        // 프레임 사이의 시간(핵심)
        public static double DeltaTime { get; private set; }
        public static double ElapsedTime => _stopwatch.Elapsed.TotalSeconds;

        private static Stopwatch _stopwatch;

        public Time() => Init();

        public void Init()
        {
            _stopwatch = Stopwatch.StartNew();
            _currentTime = _stopwatch.Elapsed.TotalSeconds;
            _prevTime = _currentTime;
            DeltaTime = 0.0;
        }

        public void Tick()
        {
            _prevTime = _currentTime;
            _currentTime = _stopwatch.Elapsed.TotalSeconds;

            DeltaTime = _currentTime - _prevTime;
        }
    }
}
