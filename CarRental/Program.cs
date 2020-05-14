using CarRentals.Entities;
using CarRentals.Services;
using System;
using System.Globalization;

namespace CarRentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data");
            Console.Write("Car model: ");
            string carModel = Console.ReadLine();
            Console.Write("Pickup (dd/mm/yyyy hh:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);
            Console.Write("Return (dd/mm/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);
            Console.Write("Enter price per hour: ");
            double pricePerHour = double.Parse(Console.ReadLine());
            Console.Write("Enter price per day: ");
            double pricePerDay = double.Parse(Console.ReadLine());

            
            CarRental carRental = new CarRental(start, finish, new Vehicle(carModel));
            RentalService rentalService = new RentalService(pricePerHour, pricePerDay, new BrazilTaxService());
            rentalService.ProcessInvoice(carRental);
            Console.WriteLine();
            Console.WriteLine("Invoice:");
            Console.WriteLine(carRental.Invoice);
        }
    }
}
