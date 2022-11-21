using Engine.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.GameObjects
{
    public abstract class GameObject : IGameObject
    {

        protected Vector2 Velocity { get; set; }
        private Vector2 localPosition = Vector2.Zero;
        public Vector2 StartPosition { get; set; }
        public Vector2 LocalPosition { get => localPosition; set => localPosition = value; }
        public GameObject Parent { get => parent; set => parent = value; }

        private GameObject parent;
        protected GameObject()
        {
            Velocity = Vector2.Zero;
        }

        public GameObject(Vector2 startPos) : this()
        {
            StartPosition = startPos;
        }

        public virtual void Draw(SpriteBatch spritebatch, GameTime gametime)
        {
            // empty
        }

        public virtual void FullReset()
        {
            throw new System.NotImplementedException();
        }

        public virtual void HandleInput(InputHelper inputHelper)
        {
            // empty
        }

        public virtual void Reset()
        {
            LocalPosition = StartPosition;
        }

        public virtual void Update(GameTime gametime)
        {
            LocalPosition += Velocity * (float)gametime.ElapsedGameTime.TotalSeconds;
        }
    }
}
