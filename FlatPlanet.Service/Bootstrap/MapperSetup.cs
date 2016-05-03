using AutoMapper;
using FlatPlanet.Data;
using FlatPlanet.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatPlanet.Service.Bootstrap
{
    public class MapperSetup
    {
        public static void Setup()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new FlatPlanetServiceToRepoProfile());
            });
        }

        public class FlatPlanetServiceToRepoProfile : Profile
        {
            protected override void Configure()
            {
                Mapper.CreateMap<CounterModel, Counter>();
                Mapper.CreateMap<Counter, CounterModel>();
            }
        }
    }
}
