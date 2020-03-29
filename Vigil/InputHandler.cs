using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigil
{
    class InputHandler
    {
        KeyboardState _oldState;
        KeyboardState _newState;

        public Vector2 Parse( out bool Exit )
        {
            // Print to debug console currently pressed keys
            System.Text.StringBuilder sb = new StringBuilder();

            KeyboardState _oldState = _newState;
            _newState = Keyboard.GetState();

            Keys[] pressed_Key = _newState.GetPressedKeys();
            Vector2 playerSpeed = new Vector2();

            Exit = false;
            foreach (var key in _newState.GetPressedKeys())
            {
                sb.Append("Key: ").Append(key).Append(" pressed ");
                switch (key)
                {
                    case Keys.Escape: Exit = true; break;
                    case Keys.W: playerSpeed.X += 1; break;
                    case Keys.S: playerSpeed.X -= 1; break;
                    case Keys.D: playerSpeed.Y += 1; break;
                    case Keys.A: playerSpeed.Y -= 1; break;
                    default: break;
                }
            }

            return playerSpeed;
        }
    }
}
