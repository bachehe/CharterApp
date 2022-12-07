namespace CharterApp.Models
{
    public interface IParametr
    {
        string Name { get; }
        string Unit { get; }
        double Value { get; set; }
    }
}
