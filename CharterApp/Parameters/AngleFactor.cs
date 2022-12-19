namespace CharterApp.Models
{
    public class AngleFactor : IParametr
    {
        public string Unit => "[°]";
        public string Name => $"θ"; // Ѱ for stress, θ for other

        public double Value { get; set; }

        public bool Validate()
        {
            return Value >= 0 && Value <= 90;
        }
    }
}
