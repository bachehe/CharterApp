namespace CharterApp.Models
{
    public interface IGeometryType
    {
        string GeometryName { get; }
        IGeometry CreateGeometry();
    }
}
