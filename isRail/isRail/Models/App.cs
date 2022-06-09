using BingMapsRESTToolkit;
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
        public Client Client { get; set; }

        public App()
        {
            Rides = new List<Ride>();
            InitializeApp();
        }

        public void InitializeApp()
        {
            SimpleWaypoint[] ride1_waypoints = { new SimpleWaypoint(45.249630, 19.396850),
                                                 new SimpleWaypoint(45.365810, 20.403580),
                                                 new SimpleWaypoint(46.102779, 19.670427) };
            Ride ride1 = new Ride(
                "Lasta",
                "Novi Sad",
                "Beograd",
                new List<string> { "Backa Palanka", "Zrenjanin", "Subotica" },
                DateTime.Now.AddHours(0.2),
                DateTime.Now.AddHours(0.5),
                1500,
                new BingMapsRESTToolkit.SimpleWaypoint(45.265571, 19.829366),
                new BingMapsRESTToolkit.SimpleWaypoint(44.808510, 20.455799),
                new List<SimpleWaypoint>(ride1_waypoints)
                );

            SimpleWaypoint[] ride2_waypoints = { new SimpleWaypoint(45.365810, 20.403580) };
            Ride ride2 = new Ride(
            "Jastreb",
            "Subotica",
            "Beograd",
            new List<string> { "Zrenjanin" },
            DateTime.Now.AddHours(1),
            DateTime.Now.AddHours(2),
            2000,
            new BingMapsRESTToolkit.SimpleWaypoint(46.102779, 19.670427),
            new BingMapsRESTToolkit.SimpleWaypoint(44.808510, 20.455799),
            new List<SimpleWaypoint>(ride2_waypoints));

            SimpleWaypoint[] ride3_waypoints = { new SimpleWaypoint(45.249630, 19.396850),
                                                 new SimpleWaypoint(45.365810, 20.403580),
                                                 new SimpleWaypoint(46.102779, 19.670427) };
            Ride ride3 = new Ride(
            "Orao",
            "Niš",
            "Sremska Mitrovica",
            new List<string> { "Backa Palanka", "Zrenjanin", "Subotica" },
            DateTime.Now.AddDays(1).AddHours(2),
            DateTime.Now.AddDays(1).AddHours(3),
            3000,
            new BingMapsRESTToolkit.SimpleWaypoint(43.316257, 21.877323),
            new BingMapsRESTToolkit.SimpleWaypoint(44.982293, 19.613703),
            new List<SimpleWaypoint>(ride3_waypoints));

            Rides = new List<Ride>();

            Rides.Add(ride1);
            Rides.Add(ride2);
            Rides.Add(ride3);

            Client = new Client("klijent", "klijent");
            Client.BoguthTickets.Add(ride1);
            
        }


    }
}
