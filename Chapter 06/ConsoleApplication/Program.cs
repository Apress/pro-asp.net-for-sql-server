using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Caching;
using Chapter05.ClassLibrary;
using Chapter05.ConsoleApplication;

namespace ConsoleApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            // use simulator as the default action
            string action = ChoseAction();
            CachingMode mode = ChoseMode();

            if ("simulator".Equals(action))
            {
                Simulator simulator = new Simulator(3, 10);
                simulator.SetCachingMode(mode);
                simulator.Run();
            }
            else if ("monitor".Equals(action))
            {
                Monitor monitor = new Monitor();
                monitor.SetCachingMode(mode);
                monitor.Run();
            }
            else
            {
                Console.WriteLine("Action not recognized: " + action);
            }
        }

        private static string ChoseAction()
        {
            string action;

            Console.WriteLine("Select a Caching Mode:");
            Console.WriteLine("1) Simulator");
            Console.WriteLine("2) Monitor");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    action = "simulator";
                    break;
                case "2":
                    action = "monitor";
                    break;
                default:
                    Console.WriteLine("Choice not recognized, try again.");
                    action = ChoseAction();
                    break;
            }
            return action;
        }

        private static CachingMode ChoseMode()
        {
            CachingMode mode;

            Console.WriteLine("Select a Caching Mode:");
            Console.WriteLine("1) Off");
            Console.WriteLine("2) AbsoluteExpiration");
            Console.WriteLine("3) Polling");
            Console.WriteLine("4) Notification");
            Console.WriteLine("5) SqlDependency");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    mode = CachingMode.Off;
                    break;
                case "2":
                    mode = CachingMode.AbsoluteExpiration;
                    break;
                case "3":
                    mode = CachingMode.Polling;
                    break;
                case "4":
                    mode = CachingMode.Notification;
                    break;
                case "5":
                    mode = CachingMode.SqlDependency;
                    break;
                default:
                    Console.WriteLine("Choice not recognized, try again.");
                    mode = ChoseMode();
                    break;
            }
            return mode;
        }
    }
}
