namespace CasinoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Player joe = new Player() { Cash = 50, Name = "Joe" };

            Random random = new Random();
            Player player = new Player() { Cash = 100, Name = "The Player" };

            double odds = .75;
            //int pot;
            Console.WriteLine($"Welcome to the casino. The odds are {odds*100}%");
            while (true)
            {
                Console.Write("Set new odds (example 75):  ");
                string? input = Console.ReadLine();
                if (input == "") return;
                if (double.TryParse(input, out double newOdds))
                {
                    odds = newOdds/100;
                    Console.WriteLine($"The new odds are {odds*100}%");
                    while (player.Cash > 0)
                    {

                        player.WriteMyInfo();
                        double chance = random.NextDouble();

                        Console.Write("How much do you want to bet: ");
                        string? howMuch = Console.ReadLine();
                        if (howMuch == "") return;
                        if (int.TryParse(howMuch, out int amount))
                        {
                            Console.WriteLine($"You rolled {chance:0.00} vs {odds} chance \n");
                            if (odds < chance)
                            {
                                int pot = player.GiveCash(amount) * 2;
                                player.ReceiveCash(pot);
                                Console.WriteLine($"You win {pot}");
                            }
                            else
                            {
                                //int pot = player.GiveCash(amount);
                                player.GiveCash(amount);
                                Console.WriteLine("Bad luck, you lose");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid number.");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                Console.WriteLine("The house always wins.");
            }
        }
    }
}
