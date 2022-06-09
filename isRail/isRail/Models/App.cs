﻿using isRail.Stores;
using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Models
{
    public class App
    {

        public List<RideBase> RideBases { get; set; }
        public List<Ride> Rides { get; set; }

        public List<string> Trains { get; set; }
        public Client Client { get; set; }
        public Manager Manager { get; set; }

        public List<User> Users { get; set; }

        public readonly NavigationStore NavigationStore;


        public App()
        {
            Rides = new List<Ride>();
            InitializeApp();
            NavigationStore = new NavigationStore();
        }

      

        public void InitializeApp()
        {
            RideBase rideBase1 = new RideBase(
                "Novi Sad",
                "Beograd",
                new List<string> { "Backa Palanka", "Zrenjanin", "Subotica" });
            
            RideBase rideBase2 = new RideBase(
                            "Subotica",
                            "Beograd",
                            new List<string> { "Zrenjanin" });
            RideBase rideBase3 = new RideBase(
                           "Niš",
                           "Sremska Mitrovica",
                           new List<string> { "Backa Palanka", "Zrenjanin", "Subotica" }
                           );

            Ride ride1 = new Ride(
                rideBase1,
                "Lasta",
                DateTime.Now.AddHours(0.2),
                DateTime.Now.AddHours(0.5),
                1500);
            
            Ride ride2 = new Ride(
                rideBase2,
                "Jastreb",
                DateTime.Now.AddHours(1),
                DateTime.Now.AddHours(2),
                2000);
           
            Ride ride3 = new Ride(
                rideBase3,
                "Orao",
                DateTime.Now.AddDays(1).AddHours(2),
                DateTime.Now.AddDays(1).AddHours(3),
                3000);

            RideBases = new List<RideBase>();
            RideBases.Add(rideBase1);
            RideBases.Add(rideBase2);
            RideBases.Add(rideBase3);

            Rides = new List<Ride>();
            Rides.Add(ride1);
            Rides.Add(ride2);
            Rides.Add(ride3);

            Trains = new List<string>();
            Trains.Add("Lasta");
            Trains.Add("Orao");
            Trains.Add("Jastreb");
            
            Users = new List<User>();
            Users.Add(new Client("klijent", "klijent"));
            Users.Add(new Manager("menadzer", "menadzer"));
            
        }

        public LoginViewModel CreateLoginViewModel()
        {
            return new LoginViewModel(this);
        }

        public ClientTicketPurchasingViewModel CreateTicketPurchasingViewModel()
        {
            return new ClientTicketPurchasingViewModel(this);
        }

        public ManagerMainViewModel CreateManagerMainViewModel()
        {
            return new ManagerMainViewModel(this);

        }


        public ManagerEditRidesViewModel CreateEditRidesViewModel()
        {
            return new ManagerEditRidesViewModel(this);
        }


    }
}
