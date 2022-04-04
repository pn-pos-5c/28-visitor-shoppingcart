using System;

namespace ElementLib
{
    public class Beverage : Good
    {
        public int Calories { get; set; }
        public double Alcohol { get; set; }

        public Beverage()
        {
            var random = new Random();
            Alcohol = random.Next(0, 80);
            Calories = random.Next(50, 300);
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitBeverage(this);
        }
    }
}
