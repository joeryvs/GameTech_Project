using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Engine.Control;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.GameObjects
{
    internal interface IGameObject
    {
        /// <summary>
        /// updates the position and or sprite of the object
        /// </summary>
        /// <param name="gametime">amount of time passed since last call</param>
        public void Update(GameTime gametime);

        /// <summary>
        /// Handles the input
        /// </summary>
        /// <param name="inputHelper">input helper used for IO methoden</param>
        public void HandleInput(InputHelper inputHelper );


        /// <summary>
        /// Draws the object at the GlobalPosition
        /// </summary>
        /// <param name="spritebatch">spritebatch needed to draw</param>
        /// <param name="gametime">It is usually provided</param>
        public void Draw(SpriteBatch spritebatch , GameTime gametime );

        /// <summary>
        /// mild reset
        /// </summary>
        public void Reset();

        /// <summary>
        /// complete reset to the initial state
        /// </summary>
        public void FullReset();



    }
}
