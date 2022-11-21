using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Engine.Control
{
    public interface IInputHelper
    {
        public void UpdateTheStates(GameTime gametime);
        public bool IsKeyDown(Keys key);
        public bool IsKeyPressed(Keys key);
        public bool IsKeyReleased(Keys key);

        public bool IsAnyKeyDown(Keys[] keys);
        public bool IsAnyKeyDown(List<Keys> keys);

        public bool IsAnyKeyPressed(Keys[] keys);
        public bool IsAnyKeyPressed(List<Keys> keys);

        public bool IsAnyKeyReleased(List<Keys> keys);
        public bool IsAnyKeyReleased(Keys[] keys);

        public Vector2 CurrentMousePosition { get; }

        public Vector2 GameWorldMousePosition { get; }

        public bool LeftMouseButtonPressed { get; }

    }
}
