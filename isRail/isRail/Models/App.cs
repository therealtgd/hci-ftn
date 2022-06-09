using isRail.Stores;
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

        public List<Ride> Rides { get; set; }
        public Client Client { get; set; }
        public Manager Manager { get; set; }

        public List<User> Users { get; set; }

        public readonly NavigationStore _navigationStore;


        public App()
        {
            Rides = new List<Ride>();
            InitializeApp();
            _navigationStore = new NavigationStore();
        }

        public void InitializeApp()
        {
            Ride ride1 = new Ride(
                "Lasta",
                "Novi Sad",
                "Beograd",
                new List<string> { "Backa Palanka", "Zrenjanin", "Subotica" },
                DateTime.Now.AddHours(0.2),
                DateTime.Now.AddHours(0.5),
                1500);
            Ride ride2 = new Ride(
            "Jastreb",
            "Subotica",
            "Beograd",
            new List<string> { "Zrenjanin" },
            DateTime.Now.AddHours(1),
            DateTime.Now.AddHours(2),
            2000);
            Ride ride3 = new Ride(
            "Orao",
            "Niš",
            "Sremska Mitrovica",
            new List<string> { "Backa Palanka", "Zrenjanin", "Subotica" },
            DateTime.Now.AddDays(1).AddHours(2),
            DateTime.Now.AddDays(1).AddHours(3),
            3000);

            Rides = new List<Ride>();

            Rides.Add(ride1);
            Rides.Add(ride2);
            Rides.Add(ride3);


            
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


    }
}
