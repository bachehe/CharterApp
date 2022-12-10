namespace CharterApp.Models
{
    public class AngleFactor : IParametr
    {
        public string Name => "Angle";

        public string Unit => "°";

        public double Value { get; set; }

        public bool Validate()
        {
            return Value >= 0 && Value <= 90;
        }
    }
}
