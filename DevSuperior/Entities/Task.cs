namespace Course.Entities
{
    class Task : Lesson
    {
        public string Description { get; set; }
        public int QuestionCount { get; set; }

        public Task(string description, int questionCount, string title) : base (title)
        {
            Description = description;
            QuestionCount = questionCount;
        }

        public override int Duration()
        {
            int durationInSeconds = 5 * 60 * QuestionCount;

            return durationInSeconds;
        }
    }
}