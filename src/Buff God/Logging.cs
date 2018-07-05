using System.Diagnostics;
using System.Runtime.CompilerServices;
using SharpDX;

namespace Buff_God
{
    public partial class Core
    {
        public void MethodLog(string message)
        {
            LogMessage($"{GetCurrentMethod()}{message}", 5, Color.LawnGreen);
        }

        public void MethodLog(string message, int time)
        {
            LogMessage($"{GetCurrentMethod()}{message}", time, Color.LawnGreen);
        }

        public void MethodLog(string message, Color color)
        {
            LogMessage($"{GetCurrentMethod()}{message}", 5, color);
        }

        public void MethodLog(string message, int time, Color color)
        {
            LogMessage($"{GetCurrentMethod()}{message}", time, color);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return $"{GetType().Name}.{sf.GetMethod().Name}";
        }
    }
}