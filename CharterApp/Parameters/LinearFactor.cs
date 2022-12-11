namespace CharterApp.Models
{
    public class LinearFactor : IParametr
    {
        public string Name => "μ value";
        public string Unit => "";
        public double Value { get; set; }

        public bool Validate()
        {
            return Value >= 1 && Value <= 900;
        }
    }
}
 