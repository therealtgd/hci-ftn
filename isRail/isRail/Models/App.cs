using BingMapsRESTToolkit;
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

        public Dictionary<RideBase, List<Ride>> RidesMap { get; set; }

        public List<string> Trains { get; set; }
        public Client Client { get; set; }
        public Manager Manager { get; set; }

        public List<User> Users { get; set; }

        public readonly NavigationStore NavigationStore;

        public Dictionary<Ride, List<TicketDetails>> Tickets { get; set; }


        public App()
        {
            RidesMap = new Dictionary<RideBase, List<Ride>>();
            InitializeApp();
            NavigationStore = new NavigationStore();
        }



        public void InitializeApp()
        {


            RideBase rideBase1 = new RideBase(
                1,
                new Station("Novi Sad", 45.265571, 19.829366),
                new Station("Beograd", 44.808510, 20.455799),
                new List<Station> { new Station("Backa Palanka", 45.249630, 19.396850),
                                    new Station("Zrenjanin", 45.365810, 20.403580),
                                    new Station("Subotica", 46.102779, 19.670427)}
            );
            RideBase rideBase2 = new RideBase(
                2,
                new Station("Subotica", 46.102779, 19.670427),
                new Station("Beograd", 44.808510, 20.455799),
                new List<Station> { new Station("Zrenjanin", 45.365810, 20.403580) }
            );
            RideBase rideBase3 = new RideBase(
                3,
                new Station("Niš", 43.316257, 21.877323),
                new Station("Sremska Mitrovica", 44.982293, 19.613703),
                new List<Station> { new Station("Backa Palanka", 45.249630, 19.396850),
                                    new Station("Zrenjanin", 45.365810, 20.403580),
                                    new Station("Subotica", 46.102779, 19.670427) }
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

            AddRide(ride1);
            AddRide(ride2);
            AddRide(ride3);

            Trains = new List<string>();
            Trains.Add("Lasta");
            Trains.Add("Orao");
            Trains.Add("Jastreb");
            Trains.Add("Pelikan");
            Trains.Add("Vrabac");
            Trains.Add("Noj");
            Trains.Add("Kokos");
            Trains.Add("Petao");
            Trains.Add("Pjevac");
            Trains.Add("Soko");
            Trains.Add("Kanarinac");
            Trains.Add("Golub");
            Trains.Add("Papagaj");
            Trains.Add("Svraka");
            Trains.Add("Gavarn");
            Trains.Add("LetiLetiKonj");

            Users = new List<User>();

            Client client1 = new Client("klijent", "klijent");
            Client client2 = new Client("testko", "testic");

            Users.Add(client1);
            Users.Add(client2);
            Users.Add(new Manager("menadzer", "menadzer"));
            ((Client)Users[0]).BoughtTickets.Add(ride3);

            Tickets = new Dictionary<Ride, List<TicketDetails>>();
            AddBoughtTicket(ride1, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(ride1, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(ride2, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(ride2, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(ride2, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(ride3, new TicketDetails(client2, DateTime.Now));
            AddBoughtTicket(ride3, new TicketDetails(client2, DateTime.Now));
            AddBoughtTicket(ride3, new TicketDetails(client2, DateTime.Now));
            AddBoughtTicket(ride3, new TicketDetails(client2, DateTime.Now));
            AddBoughtTicket(ride3, new TicketDetails(client2, DateTime.Now));

        }

        public LoginViewModel CreateLoginViewModel()
        {
            return new LoginViewModel(this);
        }

        public ClientMainViewModel CreateTicketPurchasingViewModel()
        {
            return new ClientMainViewModel(this);
        }

        public ManagerMainViewModel CreateManagerMainViewModel()
        {
            return new ManagerMainViewModel(this);

        }


        public ManagerEditRidesViewModel CreateEditRidesViewModel()
        {
            return new ManagerEditRidesViewModel(this);
        }

        public void AddRide(Ride ride)
        {
            if (RidesMap.ContainsKey(ride.RideBase))
                RidesMap[ride.RideBase].Add(ride);
            else
                RidesMap.Add(ride.RideBase, new List<Ride> { ride });
        }

        public void AddBoughtTicket(Ride ride, TicketDetails ticket)
        {
            ride.Buy();
            if (!Tickets.ContainsKey(ride))
                Tickets.Add(ride, new List<TicketDetails>());
            Tickets[ride].Add(ticket);
        }


    }
} 
