using SharpDX;

namespace Buff_God.Structs
{
    public class Colors
    {
        public Color Text { get; set; }
        public Color TextBackground { get; set; }

        public Colors()
        {
            Text = Color.White;
            TextBackground = new Color(0, 0, 0, 220);
        }
    }
}