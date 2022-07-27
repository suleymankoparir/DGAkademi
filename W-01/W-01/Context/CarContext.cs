using W_01.Models;

namespace W_01.Context
{
    public static class CarContext
    {
        public static List<BaseCar> Cars = new()
        {
            new Bmw { BrandName = "Bmw", Door = 2, Engine = 2, Wheel = 6 },
            new Mercedes { BrandName = "Mercedes", Door = 2, Engine = 2, Wheel = 8 },
            new Audi { BrandName = "Audi", Door = 5, Engine = 1, Wheel = 4 }
        };
    }
}
