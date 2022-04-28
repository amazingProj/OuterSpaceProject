using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL dAL = new DAL();
            Dictionary<string,string> dic = dAL.GetPictureOfTheDay();
            using (var ctx = new PlanetContext())
            {
                var planet = new Planet()
                {
                    ImagesPath = "/Icons/jupiter.png",
                    Name = "JUPITER",


                    mass = 1898, // to string pr le km
                    diameter = 142984,
                    density = 1326,
                    gravity = 23.1,
                    rotation_period = 9.9,
                    distance_from_sun = 778.6,
                    mean_temperature = -110,

                    Description = "Mars is the fourth planet from the Sun and the second-smallest planet in the Solar System, being larger than only Mercury. In English, Mars carries the name of the Roman god of war and is often called the .[17][18] The latter refers to the effect of the iron oxide prevalent on Mars's surface, which gives it a striking reddish appearance in the sky.[19] Mars is a terrestrial planet with a thin atmosphere, with surface features such as impact craters, valleys, dunes, and polar ice caps."
                };
                ctx.Planets.Add(planet);

                /*ctx.Planets.Add(new Planet() { ImagesPath = "/Icons/earth.png", Name = "EARTH", Description = " While Earth is only the fifth largest planet in the solar system, it is the only world in our solar system with liquid water on the surface. Just slightly larger than nearby Venus, Earth is the biggest of the four planets closest to the Sun, all of which are made of rock and metal" });
                ctx.Planets.Add(new Planet() { ImagesPath = "/Icons/mercury.png", Name = "MERCURY", Description = "The smallest planet in our solar system and nearest to the Sun, Mercury is only slightly larger than Earth's Moon.From the surface of Mercury, the Sun would appear more than three times as large as it does when viewed from Earth, and the sunlight would be as much as seven times brighter.Despite its proximity to the Sun, Mercury is not the hottest planet in our solar system – that title belongs to nearby Venus,                thanks to its dense atmosphere.Because of Mercury's elliptical – egg-shaped – orbit, and sluggish rotation, the Sun appears to rise briefly, set, and rise again from some parts of the planet's surface.The same thing happens in reverse at sunset." });
                ctx.Planets.Add(new Planet() { ImagesPath = "/Icons/mars.png", Name = "MARS", Description = "Small PLANET AND.......??" });
                ctx.Planets.Add(new Planet() { ImagesPath = "/Icons/venus.png", Name = "VENUS", Description = "Small PLANET AND.......??" });
                ctx.Planets.Add(new Planet() { ImagesPath = "/Icons/saturn.png", Name = "SATURN", Description = "Small PLANET AND.......??" });
                ctx.Planets.Add(new Planet() { ImagesPath = "/Icons/uranus.png", Name = "URANUS", Description = "Small PLANET AND.......??" });
                ctx.Planets.Add(new Planet() { ImagesPath = "/Icons/neptune.png", Name = "NEPTUNE", Description = "Small PLANET AND.......??" });
                */
                ctx.SaveChanges();
            }
            
        }
    }
}
