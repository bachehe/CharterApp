namespace CharterApp.Models
{
    public class AngleFactor : IParametr
    {
        public string Unit => "[°]";
        public string Name => $"Angle {Unit}";
        public string NamePsi => "Ѱ";
        public string NameTetha => "θ";
        public double Value { get; set; }

        public bool Validate()
        {
            return Value >= 0 && Value <= 90;
        }
    }
}
