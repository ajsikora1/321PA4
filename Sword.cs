using PA4.Interfaces;

namespace PA4
{
    public class Sword : IAttack
    {
        public void PrimaryAttack()
        {
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Will Turner used sword.");
            System.Console.WriteLine(" ");
        }
    }
}