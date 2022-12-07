namespace CharterApp.Models
{
    public class LinearFactor : IParametr
    {
        public string Name => "współczynnik liniowy";
        public string Unit => "";
        public double Value { get; set; }

    }
}
