namespace Tennis
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        void WonPoint(Player playerName);
        string GetScore();
    }
}

