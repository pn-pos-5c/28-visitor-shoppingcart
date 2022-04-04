namespace ElementLib
{
    public class ScaleVisitor : IVisitor
    {
        private double total = 0;

        public string ResultString => $"Total Weight: {total} kg";

        public IVisitor Reset()
        {
            total = 0;
            return this;
        }
        public void VisitBeverage(Beverage beverage)
        {
            total += beverage.Weight * beverage.NrUnits;
        }
        public void VisitCosmetic(Cosmetic cosmetic)
        {
            total += cosmetic.Weight * cosmetic.NrUnits;
        }
        public void VisitFood(Food food)
        {
            total += food.Weight * food.NrUnits;
        }
    }
}
