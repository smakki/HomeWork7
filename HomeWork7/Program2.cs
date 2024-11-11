

namespace HomeWork7
{
    internal class Program2
    {
        public class Planet
        {
            public string Name { get;} 
            public int OrderFromSun { get;}
            public int LenghtOfEquator { get;}
            public Planet PrevPlanet { get;}

            public Planet(string name, int orderFromSun, int lenghtOfEquator, Planet prevPlanet)
            {
                Name = name;
                OrderFromSun = orderFromSun;
                LenghtOfEquator = lenghtOfEquator;
                PrevPlanet = prevPlanet;
            }
        }

        public class PlanetCatalog
        {
            private int requestnumber = 0;
            private Planet[] planets ;

            public PlanetCatalog()
            {
                
                var Venus = new Planet ( "Venus",  2,  38025, null );
                var Earth = new Planet( "Earth", 3, 40075, Venus );
                var Mars = new Planet ( "Mars", 4, 21344, Earth );
                planets = new Planet[3] { Venus, Earth, Mars };
            }

            public (int, int, string) GetPlanet(string name)
            {
               
               if (++requestnumber == 3) 
                {
                    requestnumber = 0;
                    return (0, 0, "Too frequent requests");
                }
               Planet? planet = planets.Where(x=>x.Name  == name).FirstOrDefault();
                if (planet == null)
                {
                    return (0, 0, "Not found");
                }
                else
                {
                    return (planet.OrderFromSun, planet.LenghtOfEquator, "");
                }
            }
        }
        public static void Run()
        {
            PlanetCatalog catalog = new PlanetCatalog();
            var planets = new string[3] {"Earth", "Limonia", "Mars"};
            foreach (var planet in planets)
            {
                var data = catalog.GetPlanet(planet);
                if (data.Item3 == "")
                {
                    Console.WriteLine("Name: {0}, OrderFromSun: {1}, LenghtOfEquator: {2}", planet,data.Item1, data.Item2);
                }
                else
                {
                    Console.WriteLine(data.Item3);
                }
            }
            
        }
    }
}
