using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VendingMacine.Money;
using VendingMacine.MoneySlot;
using VendingMacine.VendingMachines;

namespace VendingMacine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //register service for DI
            var builder = new HostBuilder().ConfigureServices((hostContext, services) => {

                services.AddScoped<MainForm>();
                services.AddTransient<INote, Note>();
                services.AddTransient<IMoney, Money.Money>();
                services.AddTransient<ICoin, Coin>();
                services.AddTransient<ICardBalance, CardBalance>();
                services.AddTransient<ICardSlot, CardSlot>();
                services.AddTransient<ICoinsBalance, CoinsBalance>();
                services.AddTransient<ICoinSlot, CoinSlot>();
                services.AddTransient<INoteBalance, NoteBalance>();
                services.AddTransient<INoteSlot, NoteSlot>();
                services.AddTransient<IMoneySlot, MoneySlot.MoneySlot>();
                services.AddTransient<ISnackMachine, SnackMachine>();
                services.AddLogging(conf=> conf.AddConsole());
            });

            var host = builder.Build();
            using(var serviceScop= host.Services.CreateScope())
            {
                var services = serviceScop.ServiceProvider;
                try
                {
                    var mainForms = services.GetRequiredService<MainForm>();

                    Application.Run(mainForms);
                    Console.WriteLine("Success");
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Error Occured {e?.Message?? e?.InnerException?.Message}");
                }
            }
        }
    }
}
