using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Engine.Control
{
    public class InputHelper : IInputHelper
    {



        public readonly ExtendedGame game;
        protected System.TimeSpan ts;
        MouseState currentMouseState, previousMouseState;
        KeyboardState currentKeyboardState, previosKeyboardState;

        public InputHelper(ExtendedGame game)
        {
            this.game = game;
        }
        public void UpdateTheStates(GameTime gametime)
        {
            System.TimeSpan temp = gametime.TotalGameTime;
            if (ts == temp)
            {
                return;
            }
            previosKeyboardState = currentKeyboardState;
            previousMouseState = currentMouseState;

            // update vals
            currentMouseState = Mouse.GetState();
            currentKeyboardState = Keyboard.GetState();

            ts = temp;
            return;
        }
        public Vector2 CurrentMousePosition => currentMouseState.Position.ToVector2();

        public Vector2 GameWorldMousePosition => throw new System.NotImplementedException();

        public bool LeftMouseButtonPressed => currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;

        public bool IsKeyDown(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }

        public bool IsKeyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && previosKeyboardState.IsKeyUp(key);
        }

        public bool IsKeyReleased(Keys key)
        {
            return currentKeyboardState.IsKeyUp(key) && previosKeyboardState.IsKeyDown(key);
        }

        public bool IsAnyKeyDown(Keys[] keys)
        {
            foreach (Keys keys1 in keys)
            {
                if (IsKeyDown(keys1))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAnyKeyDown(List<Keys> keys)
        {
            return IsAnyKeyDown(keys.ToArray());
        }

        public bool IsAnyKeyPressed(Keys[] keys)
        {
            foreach (Keys item in keys)
            {
                if (IsKeyPressed(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAnyKeyPressed(List<Keys> keys)
        {
            return IsAnyKeyPressed(keys.ToArray());
        }

        public bool IsAnyKeyReleased(List<Keys> keys)
        {
            return IsAnyKeyReleased(keys.ToArray());
        }

        public bool IsAnyKeyReleased(Keys[] keys)
        {
            foreach (Keys item in keys)
            {
                if (IsKeyReleased(item))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
