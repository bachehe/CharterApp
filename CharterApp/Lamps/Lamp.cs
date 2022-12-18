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
                new(LampEnum.Co),
                new(LampEnum.Cu),
                new(LampEnum.Cr),
                new(LampEnum.Mo)
            };
        }

        public LampEnum LampType { get; }
        public string LampName => LampType.ToString();

        private Lamp(LampEnum lampType)
        {
            LampType = lampType;
        }
    }
}
