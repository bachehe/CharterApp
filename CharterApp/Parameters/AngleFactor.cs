namespace CharterApp.Models
{
    public class AngleFactor : IParametr
    {
        public string Name => "Kąt padania";

        public string Unit => "°";

        public double Value { get; set; }
    }
}
