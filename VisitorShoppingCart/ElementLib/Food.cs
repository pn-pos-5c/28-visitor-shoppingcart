using System;

namespace ElementLib
{
    public class Food : Good
    {
        public int Calories { get; set; }

        public Food()
        {
            var random = new Random();
            Calories = random.Next(100, 1000);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitFood(this);
        }
    }
}
