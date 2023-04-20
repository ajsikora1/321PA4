using PA4.Interfaces;

namespace PA4
{
    public class Distract : IAttack
    {
        public void PrimaryAttack()
        {
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Jack Sparrow used distract.");
            System.Console.WriteLine(" ");
        }
    }
}