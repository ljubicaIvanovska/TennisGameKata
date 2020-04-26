using System;
using NUnit.Framework;

namespace Tennis
{
    public class TennisGame2Refactor : ITennisGame
    {
        private int maxScore;
        private Player _player1;
        private Player _player2;

        public TennisGame2Refactor(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
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
                score = GetScorePointsSame(maxScore);
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
        private string GetScorePointsSame(int equalScore)
        {
            string score;
            if (equalScore >= 3)
            {
                score = "Deuce";
            }
            else
            {
                score = $"{Enum.GetName(typeof(ScoreEnum), equalScore)}-All";
            }
            return score;
        }
        private string GetScoreOneToThree()
        {
            return $"{Enum.GetName(typeof(ScoreEnum), _player1.Score)}-{Enum.GetName(typeof(ScoreEnum), _player2.Score)}";
        }

        private string GetScoreFourAndUp(Player leadPlayer)
        {
            string score;
            score = leadPlayer.PointDifference >= 2 ? $"Win for {leadPlayer.Name}" 
                : $"Advantage {leadPlayer.Name}";
            return score;
        }

        private Player SetLeadPlayer()
        {
            Player leadPlayer;
            if (_player1.Score > _player2.Score)
            {
                leadPlayer = _player1;
            }
            else
            {
                leadPlayer = _player2;
            }
            leadPlayer.PointDifference = Math.Abs(_player1.Score - _player2.Score);
            maxScore = leadPlayer.Score;
            return leadPlayer;
        }
        public void WonPoint(Player player)
        {
            player.Score++;
        }

    }
}

