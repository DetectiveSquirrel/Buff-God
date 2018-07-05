namespace Buff_God.Structs
{
    public class Profile
    {
        public string Name { get; set; }
        public string JsonFile { get; set; }
        public string StatusFile { get; set; }
        public BuffData BuffSettings { get; set; } = new BuffData();
        public string Directory { get; set; }
        public string ImageFolder { get; set; }
        public Status Status { get; set; } = new Status();
    }
}