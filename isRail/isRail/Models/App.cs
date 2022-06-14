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
            RideBase rb1 = new RideBase(
                1,
                new Station("Novi Sad", 45.265571, 19.829366),
                new Station("Beograd", 44.808510, 20.455799),
                new List<Station> { new Station("Backa Palanka", 45.249630, 19.396850),
                                    new Station("Zrenjanin", 45.365810, 20.403580),
                                    new Station("Subotica", 46.102779, 19.670427)}
            );
            RideBase rb2 = new RideBase(
                2,
                new Station("Beograd", 44.808510, 20.455799),
                new Station("Novi Sad", 45.265571, 19.829366),
                new List<Station> { new Station("Subotica", 46.102779, 19.670427),
                    new Station("Zrenjanin", 45.365810, 20.403580),
                    new Station("Backa Palanka", 45.249630, 19.396850) }
            );
            RideBase rb3 = new RideBase(
                3,
                new Station("Subotica", 46.102779, 19.670427),
                new Station("Beograd", 44.808510, 20.455799),
                new List<Station> { new Station("Zrenjanin", 45.365810, 20.403580) }
            );
            RideBase rb4 = new RideBase(
                4,
                new Station("Beograd", 44.808510, 20.455799),
                new Station("Subotica", 46.102779, 19.670427),
                new List<Station> { new Station("Zrenjanin", 45.365810, 20.403580) }
            );
            RideBase rb5 = new RideBase(
                5,
                new Station("Niš", 43.316257, 21.877323),
                new Station("Sremska Mitrovica", 44.982293, 19.613703),
                new List<Station> { new Station("Backa Palanka", 45.249630, 19.396850),
                                    new Station("Zrenjanin", 45.365810, 20.403580),
                                    new Station("Subotica", 46.102779, 19.670427) }
            );
            RideBase rb6 = new RideBase(
                6,
                new Station("Sremska Mitrovica", 44.982293, 19.613703),
                new Station("Niš", 43.316257, 21.877323),
                new List<Station> { new Station("Subotica", 46.102779, 19.670427),
                                    new Station("Zrenjanin", 45.365810, 20.403580),
                                    new Station("Backa Palanka", 45.249630, 19.396850) }
            );
            RideBase rb7 = new RideBase(
                7,
                new Station("Sombor", 45.786066, 19.113873),
                new Station("Novi Sad", 45.265571, 19.829366),
                new List<Station> { new Station("Odzaci", 45.510498, 19.255294),
                                    new Station("Futog", 45.254535, 19.701410), }
            );
            RideBase rb8 = new RideBase(
                8,
                new Station("Novi Sad", 45.265571, 19.829366),
                new Station("Sombor", 45.786066, 19.113873),
                new List<Station> { new Station("Futog", 45.254535, 19.701410),
                    new Station("Odzaci", 45.510498, 19.255294)
                        }
            );

            Trains = new List<string>();
            // trains
            { 
                Trains.Add("Lasta");
                Trains.Add("Orao");
                Trains.Add("Jastreb");
                Trains.Add("Pelikan");
                Trains.Add("SpeedyBoi");
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
            }
            // ridebase 1 and 2
            Ride r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12,
                r13, r14, r15, r16, r17, r18, r19, r20, r21, r22, r23, r24,
                r25, r26, r27, r28, r29, r30, r31, r32, r33, r34, r35, r36,
                r37, r38, r39, r40, r41, r42, r43, r44, r45, r46, r47, r48;
            {
                r1 = new Ride(
                    rb1,
                    "Lasta",
                    DateTime.Now.AddHours(0.2),
                    DateTime.Now.AddHours(0.5),
                    1500);

                r2 = new Ride(
                    rb1,
                    "Soko",
                    DateTime.Now.AddHours(0.6),
                    DateTime.Now.AddHours(0.9),
                    1500);

                r3 = new Ride(
                    rb1,
                    "SpeedyBoi",
                    DateTime.Now.AddHours(1),
                    DateTime.Now.AddHours(1.3),
                    1500);

                r4 = new Ride(
                    rb1,
                    "Lasta",
                    DateTime.Now.AddHours(0.2).AddDays(1),
                    DateTime.Now.AddHours(0.5).AddDays(1),
                    1500);

                r5 = new Ride(
                    rb1,
                    "Soko",
                    DateTime.Now.AddHours(0.6).AddDays(1),
                    DateTime.Now.AddHours(0.9).AddDays(1),
                    1500);

                r6 = new Ride(
                    rb1,
                    "SpeedyBoi",
                    DateTime.Now.AddHours(1).AddDays(1),
                    DateTime.Now.AddHours(1.3).AddDays(1),
                    1500);

                r7 = new Ride(
                    rb2,
                    "Lasta",
                    DateTime.Now.AddHours(0.5),
                    DateTime.Now.AddHours(0.8),
                    1500);

                r8 = new Ride(
                    rb2,
                    "Soko",
                    DateTime.Now.AddHours(0.9),
                    DateTime.Now.AddHours(0.6),
                    1500);

                r9 = new Ride(
                    rb2,
                    "SpeedyBoi",
                    DateTime.Now.AddHours(1.3),
                    DateTime.Now.AddHours(1.6),
                    1500);

                r10 = new Ride(
                    rb2,
                    "Lasta",
                    DateTime.Now.AddHours(0.5).AddDays(1),
                    DateTime.Now.AddHours(0.8).AddDays(1),
                    1500);

                r11 = new Ride(
                    rb2,
                    "Soko",
                    DateTime.Now.AddHours(0.9).AddDays(1),
                    DateTime.Now.AddHours(1.2).AddDays(1),
                    1500);

                r12 = new Ride(
                    rb2,
                    "SpeedyBoi",
                    DateTime.Now.AddHours(1.3).AddDays(1),
                    DateTime.Now.AddHours(1.6).AddDays(1),
                    1500);
            }
            // ridebase 3 and 4
            {
                r13 = new Ride(
                    rb3,
                    "Noj",
                    DateTime.Now.AddHours(0.2),
                    DateTime.Now.AddHours(0.5),
                    1500);

                r14 = new Ride(
                    rb3,
                    "Gavarn",
                    DateTime.Now.AddHours(0.6),
                    DateTime.Now.AddHours(0.9),
                    1500);

                r15 = new Ride(
                    rb3,
                    "LetiLetiKonj",
                    DateTime.Now.AddHours(1),
                    DateTime.Now.AddHours(1.3),
                    1500);

                r16 = new Ride(
                    rb3,
                    "Kokos",
                    DateTime.Now.AddHours(0.2).AddDays(1),
                    DateTime.Now.AddHours(0.5).AddDays(1),
                    1500);

                r17 = new Ride(
                    rb3,
                    "Soko",
                    DateTime.Now.AddHours(0.6).AddDays(1),
                    DateTime.Now.AddHours(0.9).AddDays(1),
                    1500);

                r18 = new Ride(
                    rb3,
                    "SpeedyBoi",
                    DateTime.Now.AddHours(1).AddDays(1),
                    DateTime.Now.AddHours(1.3).AddDays(1),
                    1500);

                r19 = new Ride(
                    rb4,
                    "Noj",
                    DateTime.Now.AddHours(0.5),
                    DateTime.Now.AddHours(0.8),
                    1500);

                r20 = new Ride(
                    rb4,
                    "Gavarn",
                    DateTime.Now.AddHours(0.9),
                    DateTime.Now.AddHours(0.6),
                    1500);

                r21 = new Ride(
                    rb4,
                    "LetiLetiKonj",
                    DateTime.Now.AddHours(1.3),
                    DateTime.Now.AddHours(1.6),
                    1500);

                r22 = new Ride(
                    rb4,
                    "Kokos",
                    DateTime.Now.AddHours(0.5).AddDays(1),
                    DateTime.Now.AddHours(0.8).AddDays(1),
                    1500);

                r23 = new Ride(
                    rb4,
                    "Soko",
                    DateTime.Now.AddHours(0.9).AddDays(1),
                    DateTime.Now.AddHours(1.2).AddDays(1),
                    1500);

                r24 = new Ride(
                    rb4,
                    "SpeedyBoi",
                    DateTime.Now.AddHours(1.3).AddDays(1),
                    DateTime.Now.AddHours(1.6).AddDays(1),
                    1500);
            }
            // ridebase 5 and 6
            {
                r25 = new Ride(
                    rb5,
                    "Noj",
                    DateTime.Now.AddHours(0.5),
                    DateTime.Now.AddHours(3),
                    1500);

                r26 = new Ride(
                    rb5,
                    "Gavarn",
                    DateTime.Now.AddHours(1),
                    DateTime.Now.AddHours(3.5),
                    1500);

                r27 = new Ride(
                    rb5,
                    "LetiLetiKonj",
                    DateTime.Now.AddHours(3),
                    DateTime.Now.AddHours(5.5),
                    1500);

                r28 = new Ride(
                    rb5,
                    "Kokos",
                    DateTime.Now.AddHours(0.5).AddDays(1),
                    DateTime.Now.AddHours(3).AddDays(1),
                    1500);

                r29 = new Ride(
                    rb5,
                    "Soko",
                    DateTime.Now.AddHours(1).AddDays(1),
                    DateTime.Now.AddHours(3.5).AddDays(1),
                    1500);

                r30 = new Ride(
                    rb5,
                    "SpeedyBoi",
                    DateTime.Now.AddHours(3).AddDays(1),
                    DateTime.Now.AddHours(5.5).AddDays(1),
                    1500);

                r31 = new Ride(
                    rb6,
                    "Noj",
                    DateTime.Now.AddHours(3),
                    DateTime.Now.AddHours(5.5),
                    1500);

                r32 = new Ride(
                    rb6,
                    "Gavarn",
                    DateTime.Now.AddHours(3.5),
                    DateTime.Now.AddHours(6),
                    1500);

                r33 = new Ride(
                    rb6,
                    "LetiLetiKonj",
                    DateTime.Now.AddHours(5.5),
                    DateTime.Now.AddHours(8),
                    1500);

                r34 = new Ride(
                    rb6,
                    "Kokos",
                    DateTime.Now.AddHours(3).AddDays(1),
                    DateTime.Now.AddHours(5.5).AddDays(1),
                    1500);

                r35 = new Ride(
                    rb6,
                    "Soko",
                    DateTime.Now.AddHours(3.5).AddDays(1),
                    DateTime.Now.AddHours(6).AddDays(1),
                    1500);

                r36 = new Ride(
                    rb6,
                    "SpeedyBoi",
                    DateTime.Now.AddHours(5.5).AddDays(1),
                    DateTime.Now.AddHours(8).AddDays(1),
                    1500);
            }
            // ridebase 7 and 8
            {
                r37 = new Ride(
                    rb7,
                    "Petao",
                    DateTime.Now.AddHours(0.5),
                    DateTime.Now.AddHours(3),
                    1500);

                r38 = new Ride(
                    rb7,
                    "Papagaj",
                    DateTime.Now.AddHours(1),
                    DateTime.Now.AddHours(3.5),
                    1500);

                r39 = new Ride(
                    rb7,
                    "Svraka",
                    DateTime.Now.AddHours(3),
                    DateTime.Now.AddHours(5.5),
                    1500);

                r40 = new Ride(
                    rb7,
                    "Petao",
                    DateTime.Now.AddHours(0.5).AddDays(1),
                    DateTime.Now.AddHours(3).AddDays(1),
                    1500);

                r41 = new Ride(
                    rb7,
                    "Papagaj",
                    DateTime.Now.AddHours(1).AddDays(1),
                    DateTime.Now.AddHours(3.5).AddDays(1),
                    1500);

                r42 = new Ride(
                    rb7,
                    "Svraka",
                    DateTime.Now.AddHours(3).AddDays(1),
                    DateTime.Now.AddHours(5.5).AddDays(1),
                    1500);

                r43 = new Ride(
                    rb8,
                    "Petao",
                    DateTime.Now.AddHours(3),
                    DateTime.Now.AddHours(5.5),
                    1500);

                r44 = new Ride(
                    rb8,
                    "Papagaj",
                    DateTime.Now.AddHours(3.5),
                    DateTime.Now.AddHours(6),
                    1500);

                r45 = new Ride(
                    rb8,
                    "Svraka",
                    DateTime.Now.AddHours(5.5),
                    DateTime.Now.AddHours(8),
                    1500);

                r46 = new Ride(
                    rb8,
                    "Petao",
                    DateTime.Now.AddHours(3).AddDays(1),
                    DateTime.Now.AddHours(5.5).AddDays(1),
                    1500);

                r47 = new Ride(
                    rb8,
                    "Papagaj",
                    DateTime.Now.AddHours(3.5).AddDays(1),
                    DateTime.Now.AddHours(6).AddDays(1),
                    1500);

                r48 = new Ride(
                    rb8,
                    "Svraka",
                    DateTime.Now.AddHours(5.5).AddDays(1),
                    DateTime.Now.AddHours(8).AddDays(1),
                    1500);
            }

            {
                AddRide(r1);
                AddRide(r2);
                AddRide(r3);
                AddRide(r4);
                AddRide(r5);
                AddRide(r6); 
                AddRide(r7);
                AddRide(r8);
                AddRide(r9);
                AddRide(r10);
                AddRide(r11);
                AddRide(r12);
                AddRide(r13);
                AddRide(r14);
                AddRide(r15);
                AddRide(r16);
                AddRide(r17);
                AddRide(r18);
                AddRide(r19);
                AddRide(r20);
                AddRide(r21);
                AddRide(r22);
                AddRide(r23);
                AddRide(r24);
                AddRide(r25);
                AddRide(r26);
                AddRide(r27);
                AddRide(r28);
                AddRide(r29);
                AddRide(r30);
                AddRide(r31);
                AddRide(r32);
                AddRide(r33);
                AddRide(r34);
                AddRide(r35);
                AddRide(r36);
                AddRide(r37);
                AddRide(r38);
                AddRide(r39);
                AddRide(r40);
                AddRide(r41);
                AddRide(r42);
                AddRide(r43);
                AddRide(r44);
                AddRide(r45);
                AddRide(r46);
                AddRide(r47);
                AddRide(r48);
            }



            Users = new List<User>();

            Client client1 = new Client("klijent", "klijent");
            Client client2 = new Client("klijent2", "klijent2");

            Users.Add(client1);
            Users.Add(client2);
            Users.Add(new Manager("menadzer", "menadzer"));
            ((Client)Users[0]).BoughtTickets.Add(r3);
            ((Client)Users[0]).BoughtTickets.Add(r6);
            ((Client)Users[0]).BoughtTickets.Add(r40);
            ((Client)Users[0]).BoughtTickets.Add(r29);
            ((Client)Users[0]).BoughtTickets.Add(r16);
            ((Client)Users[0]).BoughtTickets.Add(r33);

            ((Client)Users[1]).BoughtTickets.Add(r5);
            ((Client)Users[1]).BoughtTickets.Add(r6);
            ((Client)Users[1]).BoughtTickets.Add(r41);
            ((Client)Users[1]).BoughtTickets.Add(r25);
            ((Client)Users[1]).BoughtTickets.Add(r18);
            ((Client)Users[1]).BoughtTickets.Add(r31);

            Tickets = new Dictionary<Ride, List<TicketDetails>>();
            AddBoughtTicket(r40, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(r3, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(r6, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(r29, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(r16, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(r33, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(r40, new TicketDetails(client1, DateTime.Now));

            AddBoughtTicket(r5, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(r6, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(r25, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(r18, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(r31, new TicketDetails(client1, DateTime.Now));
            AddBoughtTicket(r41, new TicketDetails(client1, DateTime.Now));
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
