using AirlinesProje.DataAccess;
using AirlinesProje.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirlinesProje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyContext _context = new MyContext();
        public ObservableCollection<Airplane> Airplanes { get; set; } = new ObservableCollection<Airplane>();
        public ObservableCollection<Citie> Cities { get; set; } = new ObservableCollection<Citie>();
        public ObservableCollection<Pilot> Pilots { get; set; } = new ObservableCollection<Pilot>();
        public ObservableCollection<Schedule> Schedules { get; set; } = new ObservableCollection<Schedule>();
        public ObservableCollection<Ticket> Tickets { get; set; } = new ObservableCollection<Ticket>();

        public MainWindow()
        {
            InitializeComponent();
            _context.Database.CreateIfNotExists();

            this.DataContext = this;

            citieInfo.SelectedIndex = 0;
            airplanesInfo.SelectedIndex = 0;
            scheduleInfo.SelectedIndex = 0;


            LoadAirplane();
            LoadCitie();
            LoadPilot();
            LoadSchedule();
            LoadTicket();
        }

        private void LoadTicket()
        {
            if (_context.Tickets.Count() == 0)
            {
                AddTicket();
            }

            foreach (var ticket in _context.Tickets)
            {
                Tickets.Add(ticket);
            }
        }

        private void AddTicket()
        {
            var listTicket = new List<Ticket>
            {
                new Ticket { TicketId = 1, ScheduleId = 31, PassengerName = "Alice Johnson", SeatNumber = "A101", ClassType = "Economy" },
                new Ticket { TicketId = 2, ScheduleId = 32, PassengerName = "Bob Smith", SeatNumber = "B202", ClassType = "Business" },
                new Ticket { TicketId = 3, ScheduleId = 33, PassengerName = "Charlie Wang", SeatNumber = "C303", ClassType = "Premium" },
                new Ticket { TicketId = 4, ScheduleId = 34, PassengerName = "Emma Brown", SeatNumber = "D404", ClassType = "Economy" },
                new Ticket { TicketId = 5, ScheduleId = 35, PassengerName = "James Lee", SeatNumber = "E505", ClassType = "Business" },
                new Ticket { TicketId = 6, ScheduleId = 36, PassengerName = "Sophie Wilson", SeatNumber = "F606", ClassType = "Premium" }
            };

            _context.Tickets.AddRange(listTicket);
            _context.SaveChanges();
        }

        private void LoadSchedule()
        {
            if (_context.Schedules.Count() == 0)
            {
                AddSchedule();
            }

            foreach (var schedule in _context.Schedules)
            {
                Schedules.Add(schedule);
            }
        }

        private void AddSchedule()
        {
            var schedules = new List<Schedule>
            {
                new Schedule { ScheduleId = 1, FlightNumber = "AA101", DepartureCityID = 1, ArrivalCityID = 2, DepartureTime = DateTime.Parse("2024-02-07 08:00:00"), ArrivalTime = DateTime.Parse("2024-02-07 11:00:00"), PlaneId = 13, PilotId = 1 },
                new Schedule { ScheduleId = 2, FlightNumber = "BA202", DepartureCityID = 2, ArrivalCityID = 1, DepartureTime = DateTime.Parse("2024-02-07 10:00:00"), ArrivalTime = DateTime.Parse("2024-02-07 13:00:00"), PlaneId = 14, PilotId = 2 },
                new Schedule { ScheduleId = 3, FlightNumber = "JL303", DepartureCityID = 3, ArrivalCityID = 4, DepartureTime = DateTime.Parse("2024-02-08 12:00:00"), ArrivalTime = DateTime.Parse("2024-02-08 18:00:00"), PlaneId = 15, PilotId = 3 },
                new Schedule { ScheduleId = 4, FlightNumber = "DL404", DepartureCityID = 6, ArrivalCityID = 1, DepartureTime = DateTime.Parse("2024-02-08 14:00:00"), ArrivalTime = DateTime.Parse("2024-02-08 17:00:00"), PlaneId = 16, PilotId = 4 },
                new Schedule { ScheduleId = 5, FlightNumber = "QF505", DepartureCityID = 7, ArrivalCityID = 3, DepartureTime = DateTime.Parse("2024-02-09 09:00:00"), ArrivalTime = DateTime.Parse("2024-02-09 14:00:00"), PlaneId = 17, PilotId = 5 },
                new Schedule { ScheduleId = 6, FlightNumber = "TK606", DepartureCityID = 10, ArrivalCityID = 2, DepartureTime = DateTime.Parse("2024-02-10 11:00:00"), ArrivalTime = DateTime.Parse("2024-02-10 15:00:00"), PlaneId = 18, PilotId = 6 }
            };

            _context.Schedules.AddRange(schedules);
            _context.SaveChanges();
        }

        private void LoadPilot()
        {
            if (_context.Pilots.Count() == 0)
            {
                AddPilot();
            }

            foreach (var pilot in _context.Pilots)
            {
                Pilots.Add(pilot);
            }
        }

        private void AddPilot()
        {
            var pilots = new List<Pilot>
            {
                new Pilot { PilotId = 1, Name = "John Smith", LicenseNumber = "ABC123" },
                new Pilot { PilotId = 2, Name = "Emily Johnson", LicenseNumber = "XYZ789" },
                new Pilot { PilotId = 3, Name = "Michael Wang", LicenseNumber = "DEF456" },
                new Pilot { PilotId = 4, Name = "Sophia Garcia", LicenseNumber = "GHI789" },
                new Pilot { PilotId = 5, Name = "Daniel Kim", LicenseNumber = "JKL012" },
                new Pilot { PilotId = 6, Name = "Olivia Chen", LicenseNumber = "MNO345" }
            };

            _context.Pilots.AddRange(pilots);
            _context.SaveChanges();
        }

        private void LoadCitie()
        {
            if (_context.Cities.Count() == 0)
            {
                AddCitie();
            }

            foreach (var citie in _context.Cities)
            {
                Cities.Add(citie);
            }
        }

        private void AddCitie()
        {
            var cities = new List<Citie>
            {
                new Citie { CityId = 1, CityName = "New York", Country = "USA" },
                new Citie { CityId = 2, CityName = "London", Country = "UK" },
                new Citie { CityId = 3, CityName = "Tokyo", Country = "Japan" },
                new Citie { CityId = 4, CityName = "Paris", Country = "France" },
                new Citie { CityId = 5, CityName = "Dubai", Country = "UAE" },
                new Citie { CityId = 6, CityName = "Los Angeles", Country = "USA" },
                new Citie { CityId = 7, CityName = "Sydney", Country = "Australia" },
                new Citie { CityId = 8, CityName = "Toronto", Country = "Canada" },
                new Citie { CityId = 9, CityName = "Shanghai", Country = "China" },
                new Citie { CityId = 10, CityName = "Istanbul", Country = "Turkey" }
            };

            _context.Cities.AddRange(cities);
            _context.SaveChanges();
        }

        private void LoadAirplane()
        {
            if (_context.Airplanes.Count() == 0)
            {
                AddAirplane();
            }

            foreach (var airplane in _context.Airplanes)
            {
                Airplanes.Add(airplane);
            }
        }

        private void AddAirplane()
        {
            var airplanes = new List<Airplane>
            {
                new Airplane { PlaneId = 13, Model = "Boeing 747", Capacity = 400 },
                new Airplane { PlaneId = 14, Model = "Airbus A380", Capacity = 550 },
                new Airplane { PlaneId = 15, Model = "Boeing 777", Capacity = 350 },
                new Airplane { PlaneId = 16, Model = "Boeing 737", Capacity = 200 },
                new Airplane { PlaneId = 17, Model = "Airbus A320", Capacity = 180 },
                new Airplane { PlaneId = 18, Model = "Embraer E190", Capacity = 100 }
            };

            _context.Airplanes.AddRange(airplanes);
            _context.SaveChanges();
        }

        private void citieInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowTicketInfo();
        }

        private void airplanesInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowTicketInfo();
        }

        private void scheduleInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowTicketInfo();
        }
        private void ShowTicketInfo()
        {
            var selectedCitie = citieInfo.SelectedItem as Citie;
            var selectedAirplane = airplanesInfo.SelectedItem as Airplane;
            var selectedSchedule = scheduleInfo.SelectedItem as Schedule;


            if (selectedSchedule != null)
            {
                ticketId.Text = "Plane Id : " + selectedSchedule.PlaneId;
                scheduleId.Text = "Pilot Id : " + selectedSchedule.PilotId;
                departureTime.Text = "Flight : " + selectedSchedule.DepartureTime;
            }
        }

         private void Button_Click(object sender, RoutedEventArgs e)
         {
             MessageBox.Show("Ticket was successfully purchased", "Notice of Acquisition", MessageBoxButton.OK, MessageBoxImage.Information);
         }
    }
}
