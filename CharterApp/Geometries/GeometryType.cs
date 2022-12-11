namespace CharterApp.Models
{
    public class GeometryType<T> : IGeometryType where T : IGeometry, new()
    {
        public string GeometryName { get; }

        public GeometryType(string geometryName)
        {
            GeometryName = geometryName;
        }

        public IGeometry CreateGeometry() =>
            new T();
    }
}
