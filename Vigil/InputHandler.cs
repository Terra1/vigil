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

        public Game1.ShipMovements Parse( out bool Exit )
        {
            // Print to debug console currently pressed keys
            System.Text.StringBuilder sb = new StringBuilder();

            KeyboardState _oldState = _newState;
            _newState = Keyboard.GetState();

            Keys[] pressed_Key = _newState.GetPressedKeys();
            Vector2 playerSpeed = new Vector2();

            Exit = false;
            Game1.ShipMovements shipMoves;
            shipMoves.VelocityChange = new Vector2();
            shipMoves.SpinChange = 0.0f;
            foreach (var key in _newState.GetPressedKeys())
            {
                sb.Append("Key: ").Append(key).Append(" pressed ");
                switch (key)
                {
                    case Keys.Escape: Exit = true; break;
                    case Keys.W: { 
                            if (_oldState.IsKeyUp(Keys.W)) shipMoves.VelocityChange.Y -= 1; break; }
                    case Keys.A: { 
                            if (_oldState.IsKeyUp(Keys.A)) shipMoves.VelocityChange.X -= 1; break; }
                    case Keys.S: { 
                            if (_oldState.IsKeyUp(Keys.S)) shipMoves.VelocityChange.Y += 1; break; }
                    case Keys.D: { 
                            if (_oldState.IsKeyUp(Keys.D)) shipMoves.VelocityChange.X += 1; break; }
                    case Keys.Q: { 
                            if (_oldState.IsKeyUp(Keys.Q)) shipMoves.SpinChange -= 0.01f; break; }
                    case Keys.E: { 
                            if (_oldState.IsKeyUp(Keys.E)) shipMoves.SpinChange += 0.01f; break; }
                    default: break;
                }
            }

            return shipMoves;
        }
    }
}
