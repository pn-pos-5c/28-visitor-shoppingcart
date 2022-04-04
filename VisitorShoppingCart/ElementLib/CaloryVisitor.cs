namespace ElementLib
{
    public class CaloryVisitor : IVisitor
    {
        private int total = 0;

        public string ResultString => $"Calories: {total}";

        public IVisitor Reset()
        {
            total = 0;
            return this;
        }

        public void VisitBeverage(Beverage beverage)
        {
            total += beverage.Calories * beverage.NrUnits;
        }

        public void VisitCosmetic(Cosmetic cosmetic) { }
        public void VisitFood(Food food)
        {
            total += food.Calories * food.NrUnits;
        }
    }
}
