using System;

namespace PA4
{
    public class Game
    {
        public Character Player1 { get; set; }
        public Character Player2 { get; set; }

        public void Play()
        {
            Console.WriteLine("Welcome to Pirates of the Caribbean Battle Game!");
            Console.WriteLine("Player 1, please enter your name:");
            string player1Name = Console.ReadLine();
            Player1 = ChooseCharacter(player1Name);

            Console.WriteLine("Player 2, please enter your name:");
            string player2Name = Console.ReadLine();
            Player2 = ChooseCharacter(player2Name);

            Character currentPlayer = ChooseFirstAttacker();
            Character opponent = currentPlayer == Player1 ? Player2 : Player1;

            Console.WriteLine($"{currentPlayer.Name} will attack first.");

            while (!IsGameOver())
            {
                Console.WriteLine($"{currentPlayer.Name}, press any key to attack!");
                System.Console.WriteLine("###############################################");
                Console.ReadKey(true);

                Console.WriteLine($"{currentPlayer.Name} is attacking!");
                currentPlayer.Attack(opponent);

                Console.WriteLine($"{opponent.Name}'s stats:");
                Console.WriteLine(opponent.GetStats());

                // Swap the players
                Character temp = currentPlayer;
                currentPlayer = opponent;
                opponent = temp;
            }

            string winner = Player1.Health > 0 ? Player1.Name : Player2.Name;
            Console.WriteLine($"{winner} has won the game!");
        }


        public Character ChooseCharacter(string playerName)
        {

            Console.WriteLine($"{playerName}, please choose a character:");
            Console.WriteLine("1. Jack Sparrow");
            Console.WriteLine("2. Will Turner");
            Console.WriteLine("3. Davy Jones");


            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    return new JackSparrow(playerName);
                case 2:
                    return new WillTurner(playerName);
                case 3:
                    return new DavyJones(playerName);
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return ChooseCharacter(playerName);
            }
        }


        public Character ChooseFirstAttacker()
        {
            Random random = new Random();
            return random.Next(2) == 0 ? Player1 : Player2;
        }

        public void DisplayStats(Character character)
        {
            Console.WriteLine(character.GetStats());
        }

        public static float AttackEffectiveness(Character attacker, Character defender)
        {
            float typeBonus = 1.0f;

            if ((attacker is JackSparrow && defender is WillTurner) || (attacker is WillTurner && defender is DavyJones) || (attacker is DavyJones && defender is JackSparrow))
            {
                typeBonus = 1.2f;
            }

            return typeBonus;
        }

        public bool IsGameOver()
        {
            Console.WriteLine("player1 health is: "+Player1.Health+" and player2 health is: "+Player2.Health);
            return Player1.Health <= 0 || Player2.Health <= 0;
        }
    }
}