using System;

namespace bdv
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Window())
                game.Run();
        }
    }
}
