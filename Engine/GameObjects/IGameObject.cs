using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Engine.GameObjects
{
    internal interface IGameObject
    {
        public void Update(Microsoft.Xna.Framework.GameTime gametime);

        public void HandleInput( Engine.Control.InputHelper inputHelper );

        public void Draw( Microsoft.Xna.Framework.Graphics.SpriteBatch spritebatch ,Microsoft.Xna.Framework.GameTime gametime );

        public void Reset();

        public void FullReset();



    }
}
