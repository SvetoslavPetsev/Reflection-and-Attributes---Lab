namespace Stealer
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSettters("Stealer.Hacker");
            Console.WriteLine(result);

        }
    }
}
