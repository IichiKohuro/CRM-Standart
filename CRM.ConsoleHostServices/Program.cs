using System;
using System.Collections.Generic;
using System.Drawing;
using Console = Colorful.Console;

namespace CRM.ConsoleHostServices
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            var statusServices = true;

            List<char> logo = new List<char>()
            {
                '-', '-', '-', 'S', 'E', 'R', 'V', 'I', 'C', 'E', 'S', '-', '-', '-'
            };

            //Console.WriteLine("Хост сервисов ПЦН", Color.CornflowerBlue);
            //Console.WriteAscii("SERVICES", Color.CornflowerBlue);
            Console.WriteWithGradient(logo, Color.Crimson, Color.Fuchsia);
            Console.WriteLine(Environment.NewLine);

            if (statusServices)
                DrawScreen(true, true, true, false);

            while (exit == false)
            {                     
                Console.WriteLine("Ожидание команды (/? для помощи) ...", Color.PaleVioletRed);
                //Console.WriteLine(Environment.NewLine);
                var command = Console.ReadLine();

                if (statusServices)
                    DrawScreen(true, true, true, false);

                switch (command)
                {
                    case ("exit"):
                        exit = true;
                        break;

                    case ("/?"):
                        Console.WriteLine("СПИСОК ДОСТУПНЫХ КОМАНД:", Color.Yellow);
                        Console.WriteLine("exit - закрыть приложение.", Color.LightYellow);
                        Console.WriteLine("services info или -i - показывает все доступные сервисы.", Color.LightYellow);
                        Console.WriteLine("service [Название сервиса] run или -r - запуск сервиса.", Color.LightYellow);
                        Console.WriteLine("service [Название сервиса] stop или -s - остановка сервиса.", Color.LightYellow);
                        Console.WriteLine("service [Название сервиса] info или -i - описание сервиса (что он делает).", Color.LightYellow);
                        Console.WriteLine("status services show/hide или -s/-h - показать/скрыть информацию по сервисам вверху.", Color.LightYellow);
                        Console.WriteLine(Environment.NewLine);
                        break;

                    case ("status services show"):
                        statusServices = true;
                        break;

                    case ("status services -s"):
                        statusServices = true;
                        break;

                    case ("status services hide"):
                        statusServices = false;
                        Console.Clear();
                        Console.WriteWithGradient(logo, Color.Crimson, Color.Fuchsia);
                        Console.WriteLine(Environment.NewLine);
                        break;

                    case ("status services -h"):
                        statusServices = false;
                        Console.Clear();
                        Console.WriteWithGradient(logo, Color.Crimson, Color.Fuchsia);
                        Console.WriteLine(Environment.NewLine);
                        break;

                    case ("services info"):
                        ServicesInfo();
                        break;

                    case ("services -i"):
                        ServicesInfo();
                        break;

                    default:
                        Console.WriteLine("--Команда не опознана: {0} What is it???", command, Color.Gray);
                        Console.WriteLine(Environment.NewLine);
                        break;
                }
            }
        }

        static void ServicesInfo()
        {
            Console.WriteLine("Сервис 'Email'           - отвечает за отправку почты", Color.Goldenrod);
            Console.WriteLine("Сервис 'Send bids'       - отвечает за отправку заявок обслуживающим организациям", Color.Goldenrod);
            Console.WriteLine("Сервис 'Problem devices' - отвечает за отправку проблемных устройств РНКБ", Color.Goldenrod);
            Console.WriteLine("Сервис 'Reports'         - отвечает за формирование отчётов и докладов", Color.Goldenrod);
            Console.WriteLine(Environment.NewLine);
        }

        /// <summary>
        /// Рисует вверху экрана информационную панель
        /// </summary>
        /// <param name="statusEmailService">Статус сервиса Email</param>
        /// <param name="statusSendBidsService">Статус сервиса SendBids</param>
        /// <param name="statusProblemDevicesService">Статус сервиса ProblemDevices</param>
        /// <param name="statusReportsService">Статус сервиса Reports</param>
        static void DrawScreen(bool statusEmailService, bool statusSendBidsService,
            bool statusProblemDevicesService, bool statusReportsService)
        {
            List<char> logo = new List<char>()
            {
                '-', '-', '-', 'S', 'E', 'R', 'V', 'I', 'C', 'E', 'S', '-', '-', '-'
            };

            // Clear Console
            Console.Clear();
            Console.WriteWithGradient(logo, Color.Crimson, Color.Fuchsia);
            Console.WriteLine(Environment.NewLine);

            // Draw Statusbar again on the 'top'
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Сервис 'Email' {0}", statusEmailService ? "запущен" : "остановлен", statusEmailService ? Color.SeaGreen : Color.Crimson);
            Console.WriteLine("Сервис 'Send bids' {0}", statusSendBidsService ? "запущен" : "остановлен", statusSendBidsService ? Color.SeaGreen : Color.Crimson);
            Console.WriteLine("Сервис 'Problem devices' {0}", statusProblemDevicesService ? "запущен" : "остановлен", statusProblemDevicesService ? Color.SeaGreen : Color.Crimson);
            Console.WriteLine("Сервис 'Reports' {0}", statusReportsService ? "запущен" : "остановлен", statusReportsService ? Color.SeaGreen : Color.Crimson);
            Console.WriteLine("----------------------------------");
            Console.WriteLine(Environment.NewLine);

            // Draw additional stuff
        }
    }
}
