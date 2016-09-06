namespace Minesweaper
{
    public class GameScore
    {
        private string userName;
        private int userPoints;

        public GameScore(string userName, int userPoints)
        {
            this.userName = userName;
            this.userPoints = userPoints;
        }

        public string UserName
        {
            get { return this.userName; }
            private set { this.userName = value; }
        }

        public int UserPoints
        {
            get { return this.userPoints; }
            private set { this.userPoints = value; }
        }
    }
}