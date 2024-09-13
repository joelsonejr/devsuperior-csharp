namespace Course.Entities
{
    class Video : Lesson 
    {
        public string Url { get; set; }
        public int Seconds { get; set;}

        public Video(string url, int seconds, string title) : base (title)
        {
            Url = url;
            Seconds = seconds;
        }

        public override int Duration()
        {
            return Seconds;
        }
    }
}