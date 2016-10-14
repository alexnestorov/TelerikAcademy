namespace XmlBasics
{
    internal class Exam
    {
        public Exam()
        {

        }
        public Exam(string name, string tutor, int score)
        {
            this.Name = name;
            this.Tutor = tutor;
            this.Score = score;

        }

        public string Name { get; set; }

        public string Tutor { get; set; }

        public int Score { get; set; }
    }
}