namespace HomeWork7
{
    internal class Program1
    {

        public static void Run()
        {
            var Venus1 = new { Name = "Venus", OrderFromSun = 2, LenghtOfEquator = 38025, PrevPlanet = (object)null };
            var Earth = new { Name = "Earth", OrderFromSun = 3, LenghtOfEquator = 40075, PrevPlanet = (object)Venus1 };
            var Mars = new { Name = "Mars", OrderFromSun = 4, LenghtOfEquator = 21344, PrevPlanet = (object)Earth };
            var Venus2 = new { Name = "Venus", OrderFromSun = 2, LenghtOfEquator = 38025, PrevPlanet = (object)Mars };
            var planets = new[] { Venus1, Earth, Mars, Venus2 };

            foreach (var planet in planets)
            {
                Console.WriteLine($"Name: {planet.Name}, Order from Sun: {planet.OrderFromSun}, Equator Length: {planet.LenghtOfEquator}");
                Console.WriteLine($"Is equivalent to Venus? {planet.Equals(Venus1)}");
            }
        }
    }
}
