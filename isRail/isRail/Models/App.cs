using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Models
{
    public class App
    {

        public List<Ride> Rides { get; set; }

        public App()
        {
            Rides = new List<Ride>();
            InitializeRides();
        }

        public void InitializeRides()
        {
            Ride ride1 = new Ride(
               "Lasta",
               "Novi Sad",
               "Beograd",
               new List<string> { "Backa Palanka", "Zrenjanin", "Subotica" },
               DateTime.Now,
               DateTime.Now.AddHours(0.5),
               1500);
            Ride ride2 = new Ride(
            "Jastreb",
            "Subotica",
            "Beograd",
            new List<string> { "Zrenjanin" },
            DateTime.Now,
            DateTime.Now.AddHours(1),
            2000);
            Ride ride3 = new Ride(
            "Orao",
            "Niš",
            "Sremska Mitrovica",
            new List<string> { "Backa Palanka", "Zrenjanin", "Subotica" },
            DateTime.Now,
            DateTime.Now.AddHours(3),
            3000);

            Rides.Add(ride1);
            Rides.Add(ride2);
            Rides.Add(ride3);
        }


    }
}
