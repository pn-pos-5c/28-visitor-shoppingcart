namespace ElementLib
{
    public class CashVisitor : IVisitor
    {
        private double total = 0;

        public string ResultString => $"Total Price: {total} €";

        public IVisitor Reset()
        {
            total = 0;
            return this;
        }
        public void VisitBeverage(Beverage beverage)
        {
            total += beverage.PricePerUnit * beverage.NrUnits;
        }
        public void VisitCosmetic(Cosmetic cosmetic)
        {
            total += cosmetic.PricePerUnit * cosmetic.NrUnits;
        }
        public void VisitFood(Food food)
        {
            total += food.PricePerUnit * food.NrUnits;
        }
    }
}
