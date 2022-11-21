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
        /// <summary>
        /// updates the states
        /// </summary>
        /// <param name="gametime">gives you timespan safety</param>
        public void UpdateTheStates(GameTime gametime);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">the Key to check</param>
        /// <returns>true is key is down otherwise false</returns>
        public bool IsKeyDown(Keys key);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">The Key to check</param>
        /// <returns>true if key is now down and last frame up</returns>
        public bool IsKeyPressed(Keys key);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">The Key to check</param>
        /// <returns>true if key is up and last frame down</returns>
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
