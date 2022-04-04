namespace ElementLib
{
    public class AlcVisitor : IVisitor
    {
        private double contentSum = 0;
        private int count = 0;

        public string ResultString
        {
            get
            {
                var avg = 0.0;
                if (count > 0) avg = contentSum / count;
                return $"Average Alcohol: {avg}";
            }
        }

        public IVisitor Reset()
        {
            contentSum = 0;
            count = 0;
            return this;
        }

        public void VisitBeverage(Beverage beverage)
        {
            contentSum += beverage.Alcohol * beverage.NrUnits;
            count += beverage.NrUnits;
        }
        public void VisitCosmetic(Cosmetic cosmetic) { }
        public void VisitFood(Food food) { }
    }
}
