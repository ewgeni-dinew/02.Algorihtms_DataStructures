namespace PersonalID
{
    using System;

    class StartUp
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    Console.Write("Input ID: ");
                    var inputId = Console.ReadLine();

                    var id = new ID(inputId);

                    Console.WriteLine(true);
                    Console.WriteLine($"Birthdate: {id.GetBirthDate()}");
                    Console.WriteLine($"Gender: {id.PersonalGender}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(false);
                }
            }
            
        }
    }
}
