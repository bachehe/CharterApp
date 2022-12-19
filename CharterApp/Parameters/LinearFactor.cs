namespace CharterApp.Models
{
    public class LinearFactor : IParametr
    {
        public string Unit => "[μm]";
        public string Name => $"μ";
        public double Value { get; set; }

        public bool Validate()
        {
            return Value >= 1 && Value <= 900;
        }
    }
}
 