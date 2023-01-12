namespace CharterApp.Models
{
    public class LinearFactor : IParametr
    {
        public string Unit => "[μm]";
        public string Name => "μ";
        public double Value { get; set; }
        public bool Validate()
        {
            return Value >= 0 && Value <= 9999;
        }
    }
}
 