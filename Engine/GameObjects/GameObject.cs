using Engine.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.GameObjects
{
    public abstract class GameObject : IGameObject
    {

        private GameObject parent;

        /// <summary>
        /// The current velocity of this game object, in units per second.
        /// </summary>
        protected Vector2 Velocity { get; set; }
        private Vector2 localPosition = Vector2.Zero;

        /// <summary>
        /// the position at which the object begins
        /// </summary>
        public Vector2 StartPosition { get; set; }

        /// <summary>
        /// The position of this game object, relative to its parent in the game-object hierachy.
        /// </summary>
        public Vector2 LocalPosition
        {
            get { return localPosition; }
            set { localPosition = value; }
        }

        /// <summary>
        /// The (optional) parent of this object in the game-object hierarchy.
        /// If the object has a parent, then its position depends on its parent's position.
        /// </summary>
        public GameObject Parent { get => parent; set => parent = value; }


        /// <summary>
        /// Whether or not this game object is currently visible.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Random object borrowed from Extended game
        /// </summary>
        public System.Random Random { get { return ExtendedGame.Random; } }

        /// <summary>
        /// Gets this object's global position in the game world, by adding its local position to the global position of its parent.
        /// </summary>
        public Vector2 GlobalPosition
        {
            get
            {
                return this.Parent == null ? LocalPosition : LocalPosition + Parent.GlobalPosition;
            }
        }
        protected GameObject()
        {
            Velocity = Vector2.Zero;
            Visible = true;
        }

        public GameObject(Vector2 startPos) : this()
        {
            StartPosition = startPos;
        }

        /// <summary>
        /// Draws this GameObject. By default, nothing happens, but other classes can override this method.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use.</param>
        /// <param name="gameTime">An object containing information about the time that has passed.</param>
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }

        

        /// <summary>
        /// Performs input handling for this GameObject. 
        /// By default, this method does nothing, but you can override it.
        /// </summary>
        /// <param name="inputHelper">An object with information about player input.</param>
        public virtual void HandleInput(InputHelper inputHelper)
        {
        }


        /// <summary>
        /// Resets this game object to an initial state.
        /// For example, this can be useful for restarting a level of the game.
        /// Override this method so that it resets everything it needs to.
        /// </summary>
        public virtual void Reset()
        {
            Velocity = Vector2.Zero;
        }
        public virtual void FullReset()
        {
            this.LocalPosition = this.StartPosition;
            this.Reset();
        }

        public virtual void Update(GameTime gametime)
        {
            LocalPosition += Velocity * (float)gametime.ElapsedGameTime.TotalSeconds;
        }
    }
}
