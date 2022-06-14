namespace BowlingBall.Models
{
    public class Frame
    {
        public Frame(int pinsKnockedDownInFirstRoll, int pinsKnockedDownInSecondRoll)
        {
            FirstRoll = pinsKnockedDownInFirstRoll;
            SecondRoll = pinsKnockedDownInSecondRoll;
        }

        public int FirstRoll { get; set; }

        public int SecondRoll { get; set; }

        public int ThirdRoll { get; set; }
    }
}