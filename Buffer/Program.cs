using System;

namespace Buffer
{
    internal class Program
    {
        private static FiFo buffer;
        
        private static void Main(string[] args)
        {
            Console.WriteLine("Wie viel Plätze soll dein Array haben?");
            bool userBool = int.TryParse(Console.ReadLine(), out int userEingabe);

            if (userBool == true)
            {
                buffer = new FiFo(userEingabe);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Eingabe ungültig.\nHöchster Index ist 10.\n");
                buffer = new FiFo();
            }

            Menue();
            Console.ReadLine();
        }
        

        private static void Menue()
        {
            bool schleife = true;
            while (schleife)
            {
                Console.WriteLine("Optionen:\nClear\nAdd\nGet value\nGet pointer\nAusgabe\nExit\n");
                string userEingabe = Console.ReadLine();

                if (userEingabe == "Clear")
                {
                    buffer.Clear();
                }
                else if (userEingabe == "Add")  
                {
                    Console.WriteLine("Füttere den Buffer mit einer Zahl\n");
                    bool inputIsNumber = int.TryParse(Console.ReadLine(), out int eingabe);
                    if (inputIsNumber)
                    {
                        buffer.Add(eingabe);
                    }
                    else
                    {
                        Console.WriteLine("Ungültige eingabe!\n");
                    }
                    Console.Clear();
                }
                else if (userEingabe == "Get value")    
                {
                    Console.Clear();
                    int zahlAusgabe = buffer.GetValue();
                    Console.WriteLine("Dein Tailwert ist: " + zahlAusgabe + "\n");
                }
                else if (userEingabe == "Get pointer")
                {
                    Console.WriteLine("Head-index: " + buffer.Head);
                    Console.WriteLine("Tail-index: " + buffer.Tail + "\n");
                }
                else if (userEingabe == "Ausgabe")  
                {
                    Console.Clear();
                    int[] ausgabe = buffer.GetStack();

                    foreach (int item in ausgabe)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (userEingabe == "Exit")
                {
                    schleife = false;
                }
                else
                {
                    Console.WriteLine("Option eingabe ist ungültig!\n");
                }                
            }
        }
    }
}