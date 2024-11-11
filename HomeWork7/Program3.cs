

namespace HomeWork7
{
    internal class Program3
    {
        public class Planet
        {
            public string Name { get; }
            public int OrderFromSun { get; }
            public int LenghtOfEquator { get; }
            public Planet? PrevPlanet { get; }

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
            private Planet[] planets;

            public PlanetCatalog()
            {

                var Venus = new Planet("Venus", 2, 38025, null);
                var Earth = new Planet("Earth", 3, 40075, Venus);
                var Mars = new Planet("Mars", 4, 21344, Earth);
                planets = new Planet[3] { Venus, Earth, Mars };
            }

            public (int, int, string) GetPlanet(string name, Func<string,string> PlanetValidator)
            {
                var validationResult = PlanetValidator(name);
                if (validationResult != "")
                {
                    return (0, 0, validationResult);
                }
                Planet? planet = planets.Where(x => x.Name == name).FirstOrDefault();
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
            var requestnumber = 0;
            Func<string, string> frequentValidator = name =>
            {
                requestnumber++;
                return requestnumber % 3 == 0 ? "Too frequent requests" : "";
            };
            
            PlanetCatalog catalog = new PlanetCatalog();
            var planets = new string[3] { "Earth", "Limonia", "Mars" };
            foreach (var planet in planets)
            {
                var data = catalog.GetPlanet(planet, frequentValidator);
                if (data.Item3 == "")
                {
                    Console.WriteLine("Name: {0}, OrderFromSun: {1}, LenghtOfEquator: {2}", planet, data.Item1, data.Item2);
                }
                else
                {
                    Console.WriteLine(data.Item3);
                }
            }
            Console.WriteLine();
            //Задание со звездочкой
            Func<string, string> limoniaValidator = name =>
            {
                return name == "Limonia" ? "This is a forbidden planet" : "";
            };
            foreach (var planet in planets)
            {
                var data = catalog.GetPlanet(planet, limoniaValidator);
                if (data.Item3 == "")
                {
                    Console.WriteLine("Name: {0}, OrderFromSun: {1}, LenghtOfEquator: {2}", planet, data.Item1, data.Item2);
                }
                else
                {
                    Console.WriteLine(data.Item3);
                }
            }

        }
    }
}
