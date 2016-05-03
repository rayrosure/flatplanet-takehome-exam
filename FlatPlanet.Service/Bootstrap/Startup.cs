using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(FlatPlanet.Service.Bootstrap.Startup), "Start")]

namespace FlatPlanet.Service.Bootstrap
{
    using System;

    public static class Startup
    {

        public static void Start()
        {
            MapperSetup.Setup();
        }


    }
}

