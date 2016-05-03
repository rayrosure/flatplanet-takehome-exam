using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace FlatPlanet.Models
{
    public class ClickCounterModel
    {
        public int NumberOfClicks { get; set; }

        public bool HasClickedTooManyTimes
        {
            get { return NumberOfClicks >= 10; }
        }

        public void RegisterClick()
        {
            NumberOfClicks++;
        }

        public void ResetClicks()
        {
            NumberOfClicks = 0;
        }
    }
}