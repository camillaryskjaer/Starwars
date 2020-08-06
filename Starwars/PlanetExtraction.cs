using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Starwars
{
    static class PlanetExtraction
    {
        public static IEnumerable<Planet> TaskOne(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets = 
                from p in planets 
                where p.Name.ToLower().StartsWith("m") 
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskTwo(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets = 
                from p in planets 
                where p.Name.ToLower().Contains("y") 
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskThree(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets = 
                from p in planets 
                where p.Name.Length > 9 && p.Name.Length < 15 
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskFour(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets = 
                from p in planets 
                //for læsevenlighedens skyld m.m. er det altid bedst at indkapsle betingelser i ()
                where ((p.Name.ToLower()[1] == 'a') && (p.Name.ToLower().EndsWith("e"))) 
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskFive(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets = 
                from p in planets 
                where p.RotationPeriod > 40 
                orderby p.RotationPeriod 
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskSix(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets = 
                from p in planets 
                where p.RotationPeriod > 10 && p.RotationPeriod < 20 
                orderby p.Name 
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskSeven(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets = 
                from p in planets 
                where p.RotationPeriod > 30 
                orderby p.Name, p.RotationPeriod 
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskEight(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets = 
                from p in planets 
                where (p.RotationPeriod < 30 || p.SurfaceWater > 50) && p.Name.ToLower().Contains("ba")
                orderby p.Name, p.SurfaceWater, p.RotationPeriod
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskNine(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets =
                from p in planets
                where p.SurfaceWater > 0
                orderby p.SurfaceWater descending 
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskTen(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets =
                from p in planets
                where p.Diameter != 0 && p.Population != 0
                orderby (4 * Math.PI * ((p.Diameter/2)*(p.Diameter/2))) / p.Population
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskEleven(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets = planets.Except(planets, new RotationComparer());

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskTwelve(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanetsOne =
                from p in planets
                where p.Name.ToLower().StartsWith("a") || p.Name.ToLower().EndsWith("s")
                select p;

            IEnumerable<Planet> selectedPlanetsTwo =
                from p in planets
                where p.Terrain != null && p.Terrain.Contains("rainforests")
                select p;

            IEnumerable<Planet> selectedPlanets = selectedPlanetsOne.Union(selectedPlanetsTwo);

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskThirteen(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets =
                from p in planets
                where p.Terrain != null && (p.Terrain.Contains("deserts") || p.Terrain.Contains("rocky deserts") || p.Terrain.Contains("desert"))
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskFourteen(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets =
                from p in planets
                where p.Terrain != null && (p.Terrain.Contains("swamp") || p.Terrain.Contains("swamps"))
                orderby p.RotationPeriod, p.Name
                select p;

            return selectedPlanets;
        }


        public static IEnumerable<Planet> TaskFifteen(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets =
                from p in planets
                where Regex.IsMatch(p.Name, @"(a|e|i|o|u)\1")
                select p;

            return selectedPlanets;
        }

        public static IEnumerable<Planet> TaskSixteen(List<Planet> planets)
        {
            IEnumerable<Planet> selectedPlanets =
                from p in planets
                where Regex.IsMatch(p.Name, @"(k|l|r|n)\1")
                orderby p.Name descending 
                select p;

            return selectedPlanets;
        }
    }
}
