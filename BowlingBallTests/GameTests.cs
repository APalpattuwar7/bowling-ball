using BowlingBall;
using System.Linq;
using Xunit;

namespace BowlingBallTests
{
    public class GameTests
    {
        [Fact]
        public void GetScoreWhenNoStrikeOrSpare()
        {
            Game game = new();
            int expectedScore = 16;
            game.Roll(5, 3);
            game.Roll(2, 6);
            var score = game.GetScore();
            Assert.Equal(score, expectedScore);
        }

        [Fact]
        public void GetScoreWhenOneSpare()
        {
            Game game = new();
            int expectedScore = 30;
            game.Roll(5, 3);
            game.Roll(4, 6);
            game.Roll(5, 2);
            var score = game.GetScore();
            Assert.Equal(score, expectedScore);
        }

        [Fact]
        public void GetScoreWhenOneStrike()
        {
            Game game = new();
            int expectedScore = 32;
            game.Roll(5, 3);
            game.Roll(10, 0);
            game.Roll(5, 2);
            var score = game.GetScore();
            Assert.Equal(score, expectedScore);
        }

        [Fact]
        public void GetScoreWhenAllStrikes()
        {
            Game game = new();
            int expectedScore = 300;
            TestHelper.RollAllStrikes(game);
            var score = game.GetScore();
            Assert.Equal(score, expectedScore);
        }

        [Fact]
        public void GetScoreWhenAllSpares()
        {
            Game game = new();
            int expectedScore = 190;
            TestHelper.RollAllSpares(game);
            var score = game.GetScore();
            Assert.Equal(score, expectedScore);
        }

        [Fact]
        public void GetScoreWhenZeroPinsKnockedDownInAllFrames()
        {
            Game game = new();
            int expectedScore = 0;
            TestHelper.RollZero(game);
            var score = game.GetScore();
            Assert.Equal(score, expectedScore);
        }

        [Fact]
        public void GetScoreForAllFrames()
        {
            Game game = new();
            int expectedScore = 157;
            game.Roll(5, 3);
            game.Roll(10, 0);
            game.Roll(5, 2);
            game.Roll(5, 44);
            game.Roll(6, 4);
            game.Roll(10, 0);
            game.Roll(5, 3);
            game.Roll(5, 5);
            game.Roll(5, 3);
            game.Roll(5, 2);
            game.Frames.Last().ThirdRoll = 10;
            var score = game.GetScore();
            Assert.Equal(score, expectedScore);
        }

        [Fact]
        public void GetScoreForAllFramesWithLastFrameSpare()
        {
            Game game = new();
            int expectedScore = 170;
            game.Roll(5, 3);
            game.Roll(10, 0);
            game.Roll(5, 2);
            game.Roll(5, 44);
            game.Roll(6, 4);
            game.Roll(10, 0);
            game.Roll(5, 3);
            game.Roll(5, 5);
            game.Roll(5, 3);
            game.Roll(5, 5);
            game.Frames.Last().ThirdRoll = 10;
            var score = game.GetScore();
            Assert.Equal(score, expectedScore);
        }
    }
}
