using System.Collections.Generic;

namespace CharterApp.Lamps
{
    public class Lamp
    {
        public static List<Lamp> Lamps { get; }

        static Lamp()
        {
            Lamps = new()
            {
                new(LampEnum.Mo),
                new(LampEnum.Cu),
                new(LampEnum.Co),
                new(LampEnum.Cr),
            };
        }

        public LampEnum LampType { get; }
        public string LampName => LampType.ToString();

        public Lamp(LampEnum lampType) //private
        {
            LampType = lampType;
        }
    }
}
