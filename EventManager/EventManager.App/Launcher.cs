namespace EventManager.App
{
    using System;

    class Launcher
    {
        static void Main(string[] args)
        {
            var engine = new Engine.Engine();

            while (true)
            {
                Console.WriteLine("Input command: ");
                var command = Console.ReadLine()
                    .Trim()
                    .ToLower();

                if (command.Equals("end"))
                {
                    break;
                }

                try
                {
                    switch (command)
                    {
                        case "create":
                            var createData = ReadDataFromConsole();
                            engine.Create(createData);
                            break;
                        case "update":
                            var updateData = ReadDataFromConsole();
                            engine.Update(updateData);
                            break;
                        case "delete":
                            var eventName = ReadEventNameFromConsole();
                            engine.Delete(eventName);
                            break;
                        case "print all":
                            Console.WriteLine(engine.PrintAllEvents());
                            break;
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private static string[] ReadDataFromConsole()
        {
            var name = ReadEventNameFromConsole();

            var location = ReadEventLocationFromConsole();

            var start = ReadEventStartFromConsole();

            var end = ReadEventEndFromConsole();

            var result = new string[] { name, location, start, end };

            return result;
        }

        private static string ReadEventEndFromConsole()
        {
            Console.WriteLine("Input event end date (format \"dd/MM/yyyy HH:mm:ss\"): ");

            var end = Console.ReadLine()
                .Trim();

            return end;
        }

        private static string ReadEventStartFromConsole()
        {
            Console.WriteLine("Input event start date (format \"dd/MM/yyyy HH:mm:ss\"): ");

            var start = Console.ReadLine()
                .Trim();

            return start;
        }

        private static string ReadEventLocationFromConsole()
        {
            Console.WriteLine("Input event location: ");

            var location = Console.ReadLine()
                .Trim();

            return location;
        }

        private static string ReadEventNameFromConsole()
        {
            Console.WriteLine("Input event name: ");

            var name = Console.ReadLine()
                .Trim();

            return name;
        }
    }
}
