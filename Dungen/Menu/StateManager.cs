using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Dungen.Menu
{
    class StateManager
    {
        private static GameState state;
        private static ContentManager content;
        private static State currState;
        public static GameState State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }
        public static Vector2 currentScreenSize = new Vector2(1366, 768);
        public static ContentManager Content
        {
            get
            {
                return content;
            }

            private set
            {
                content = value;
            }
        }

        public static void ChangeState(GameState State)
        {
            switch (State)
            {
                case GameState.MainMenu:
                    currState = new MainMenu(currentScreenSize);
                    break;
                case GameState.LevelStates:
                    break;
                case GameState.EndOfGame:
                    break;
            }
        }
    }
}
