namespace CasinoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Player[] players = new Player[2];
            players[0] = new Player() { Cash = 100, Name = "Bob" };
            players[1] = new Player() { Cash = 50, Name = "Joe" };

            Player currentPlayer = new();
            double odds = .75;

            Console.WriteLine($"Welcome to the casino. The odds are {odds*100}%");
            while (true)
            {
                Console.Write("Set new odds (example 75):  ");
                string? input = Console.ReadLine();
                if (input == "") return;
                if (double.TryParse(input, out double newOdds))
                {
                    odds = newOdds / 100;
                    Console.WriteLine($"The new odds are {odds * 100}% \n");
                    
                    while (true)
                    {
                        foreach (Player player in players)
                        {
                            
                            Console.WriteLine($"{player.Name} has {player.Cash} cash.");                           
                            
                        }
                        Console.WriteLine();
                        Console.Write("Select a player) (1 (Bob), 2 (Joe):  ");
                        string? playerSelection = Console.ReadLine();
                        if (playerSelection == "") return;
                        if (int.TryParse(playerSelection, out int selection))
                        {
                            currentPlayer = players[selection - 1];
                            Console.WriteLine($"You are playing as {currentPlayer.Name}");
                            Console.WriteLine();
                            while (currentPlayer.Cash > 0)
                            {

                                currentPlayer.WriteMyInfo();
                                double chance = random.NextDouble();

                                Console.Write("How much do you want to bet: ");
                                string? howMuch = Console.ReadLine();
                                if (howMuch == "") return;
                                if (int.TryParse(howMuch, out int amount))
                                {
                                    Console.WriteLine($"You rolled {chance:0.00} vs {odds} chance \n");
                                    if (odds < chance)
                                    {
                                        int pot = currentPlayer.GiveCash(amount) * 2;
                                        currentPlayer.ReceiveCash(pot);
                                        Console.WriteLine($"You win {pot}");
                                    }
                                    else
                                    {
                                        //int pot = player.GiveCash(amount);
                                        currentPlayer.GiveCash(amount);
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
