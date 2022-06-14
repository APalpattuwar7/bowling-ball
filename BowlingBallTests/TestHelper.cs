using BowlingBall;
using System;

namespace BowlingBallTests
{
    internal class TestHelper
    {
        internal static void RollAllStrikes(Game game)
        {
            for (int i = 0; i < 10; i++)
            {
                game.Roll(10, 10);
                if(i == 9)
                {
                    game.Frames[i].ThirdRoll = 10;
                }
            }
        }

        internal static void RollAllSpares(Game game)
        {
            for (int i = 0; i < 10; i++)
            {
                game.Roll(9,1);
                if (i == 9)
                {
                    game.Frames[i].ThirdRoll = 9;
                }
            }
        }

        internal static void RollZero(Game game)
        {
            for (int i = 0; i < 10; i++)
            {
                game.Roll(0, 0);
            }
        }
    }
}