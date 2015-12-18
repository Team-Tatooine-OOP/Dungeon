using System;
using OopProject;

namespace Dungen
{
    using Dungen.Intro;

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GameIntro gameIntro = new GameIntro();
            gameIntro.Run();

            using (var game = new GameEngine())
                game.Run();
        }
    }
#endif
}
