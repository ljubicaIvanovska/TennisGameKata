using System;
using NUnit.Framework;

namespace Tennis
{
    public class TennisGame2Refactor : ITennisGame
    {
        private int p1point;
        private int p2point;

        private int maxScore;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;

        private Player player1;
        private Player player2;

        public TennisGame2Refactor(Player player1, Player player2)
        {
            player1 = player1;
            player2 = player2;
        }

        public void WonPoint(string playerName)
        {
            throw new System.NotImplementedException();
        }


        public string GetScore()
        {
            var score = "";
            // Set Lead Player and point difference
            Player leadPlayer = SetLeadPlayer();

            if (leadPlayer.PointDifference == 0)
            {
                score = GetScoreDeushe();
            }
            else
            {
                if (leadPlayer.PointDifference >= 1 && maxScore >= 4)
                {
                    score = GetScoreFourAndUp(leadPlayer);
                }
                else
                {
                    score = GetScoreOneToThree();
                }
            }

            return score;
        }
        private string GetScoreDeushe()
        {   return "Deuce";
        }
        private string GetScoreOneToThree()
        {
            return $"{Enum.GetName(typeof(ScoreEnum), player1.Score)}-{Enum.GetName(typeof(ScoreEnum), player2.Score)}";
        }

        private string GetScoreFourAndUp(Player leadPlayer)
        {
            string score;
            score = leadPlayer.PointDifference >= 2 ? $"Win for player {leadPlayer.Name}" 
                : $"Advantage player {leadPlayer.Name}";
            return score;
        }

        private Player SetLeadPlayer()
        {
            Player leadPlayer;
            if (player1.Score > player2.Score)
            {
                leadPlayer = player1;
            }
            else
            {
                leadPlayer = player2;
            }
            leadPlayer.PointDifference = Math.Abs(player1.Score - player2.Score);
            maxScore = leadPlayer.Score;
            return leadPlayer;
        }
        public void WonPoint(Player player)
        {
            player.WonPoint();
        }

    }
}

