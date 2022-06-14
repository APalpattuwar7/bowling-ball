using BowlingBall.Models;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        public List<Frame> Frames { get; set; }

        private const int MAX_NO_OF_FRAMES = 10;
        private const int MAX_NO_OF_PINS = 10;

        public Game()
        {
            Frames = new List<Frame>(MAX_NO_OF_FRAMES);
        }


        public void Roll(int pinsKnockedDownInFirstRoll, int pinsKnockedDownInSecondRoll)
        {
            Frames.Add(new Frame(pinsKnockedDownInFirstRoll, pinsKnockedDownInSecondRoll));
        }


        public int GetScore()
        {
            int score = 0;
            foreach (var frame in Frames)
            {
                if(IsStrike(frame))
                {
                    score += MAX_NO_OF_PINS;
                    score += GetStrikeBonus(frame);
                }
                else if(IsSpare(frame))
                {
                    score += MAX_NO_OF_PINS;
                    score += GetSpareBonus(frame);
                } else
                {
                    score += SumOfTwoRolls(frame);
                }
            }
            return score;
        }


        private bool IsStrike(Frame frame)
        {
            return frame.FirstRoll == MAX_NO_OF_PINS;
        }


        private int GetStrikeBonus(Frame frame)
        {
            var currentFrameIndex = Frames.IndexOf(frame);
            if (currentFrameIndex == MAX_NO_OF_FRAMES - 1)
            {
                return frame.SecondRoll + frame.ThirdRoll;
            }

            var nextFrame = Frames[Frames.IndexOf(frame) + 1];
            return nextFrame.FirstRoll + nextFrame.SecondRoll;
        }


        private bool IsSpare(Frame frame)
        {
            return frame.FirstRoll + frame.SecondRoll == MAX_NO_OF_PINS;
        }


        private int GetSpareBonus(Frame frame)
        {
            var currentFrameIndex = Frames.IndexOf(frame);
            if (currentFrameIndex == MAX_NO_OF_FRAMES - 1)
            {
                return frame.ThirdRoll;
            }

            var nextFrame = Frames[Frames.IndexOf(frame) + 1];
            return nextFrame.FirstRoll;
        }


        private int SumOfTwoRolls(Frame frame)
        {
            return frame.FirstRoll + frame.SecondRoll;
        }
    }
}                