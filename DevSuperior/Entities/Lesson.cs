namespace Course.Entities
{
    abstract class Lesson
    {
        public string Title { get; set; }
        
        public Lesson(string title) {
            Title = title;
        }

        abstract public int Duration();
    }
}