using Engine.Control;
using Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Engine.ObjectList
{
    /// <summary>
    /// A non-visual game object that has a list of game objects as its children.
    /// </summary>
    public class GameObjectList : GameObjects.GameObject
    {

        /// <summary>
        /// The child objects of this game object.
        /// </summary>
        protected List<GameObject> children = new();
        private readonly List<GameObject> toRemove = new();

        /// <summary>
        /// Creates a new GameObjectList with an empty list of children.
        /// </summary>
        public GameObjectList()
        {
        }

        /// <summary>
        /// Adds an object to this GameObjectList, and sets this GameObjectList as the parent of that object.
        /// </summary>
        /// <param name="obj">The game object to add.</param>
        public void AddChild(GameObject obj)
        {
            obj.Parent = this;
            children.Add(obj);
            return;
        }

        /// <summary>
        /// Adds an object to this GameObjectList, and sets the parent of the GameObjectList as the parent of that object.
        /// So that it position isn't dependant on the position of this list
        /// </summary>
        /// <param name="obj">The game object to add.</param>
        public void AddBrother(GameObject obj)
        {
            obj.Parent = this.Parent;
            children.Add(obj);
            return;
        }

        /// <summary>
        /// Functionality to remove a object from the list without causing an Exeption
        /// </summary>
        /// <param name="obj">The game object to remove.</param>
        public void RemoveObject(GameObject obj)
        {
            toRemove.Add(obj);
        }

        /// <summary>
        /// Performs the Draw method for all game objects in this GameObjectList.
        /// </summary>
        /// <param name="spriteBatch">A sprite batch object used for drawing sprites.</param>
        /// <param name="gameTime">An object containing information about the time that has passed in the game.</param>
        public override void Draw(SpriteBatch spritebatch, GameTime gametime)
        {
            if (!Visible)
                return;

            foreach (GameObject obj in children)
                obj.Draw(spritebatch,gametime);
        }

        /// <summary>
        /// Performs the Full-Reset method for all game objects in this GameObjectList.
        /// </summary>
        public override void FullReset()
        {
            base.FullReset();
            foreach (GameObject gameObject in children)
            {
                gameObject.FullReset();
            }
        }

        /// <summary>
        /// Performs input handling for all game objects in this GameObjectList.
        /// </summary>
        /// <param name="inputHelper">An object required for handling player input.</param>
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            for (int index = children.Count - 1; index >= 0; index--)
            {
                children[index].HandleInput(inputHelper);
            }
        }

        /// <summary>
        /// Performs the Reset method for all game objects in this GameObjectList.
        /// </summary>
        public override void Reset()
        {
            for (int index = 0; index < children.Count; index++)
            {
                children[index].Reset();
            }
        }

        /// <summary>
        /// Performs the Update method for all game objects in this GameObjectList.
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed in the game.</param>
        public override void Update(GameTime gametime)
        {
            base.Update(gametime);
            foreach (GameObject gameObject in children)
            {
                gameObject.Update(gametime);
            }
            foreach (GameObject lastItem in toRemove)
            {
                children.Remove(lastItem);
            }
            toRemove.Clear();
        }
    }
}
