using Engine.Control;
using Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Engine.ObjectList
{
    public class GameObjectList : GameObjects.GameObject
    {
        protected List<GameObjects.GameObject> children = new();
        private readonly List<GameObject> toRemove = new();

        public GameObjectList()
        {
        }

        public void AddChild(GameObjects.GameObject obj)
        {
            obj.Parent = this;
            children.Add(obj);
            return;
        }

        public void AddBrother(GameObject obj)
        {
            obj.Parent = this.Parent;
            children.Add(obj);
            return;
        }
        public void RemoveObject(GameObject obj)
        {
            toRemove.Add(obj);
        }

        public override void Draw(SpriteBatch spritebatch, GameTime gametime)
        {
            base.Draw(spritebatch, gametime);
            foreach (GameObject gameObject in children)
            {
                gameObject.Draw(spritebatch, gametime);
            }
        }

        public override void FullReset()
        {
            base.FullReset();
            foreach (GameObject gameObject in children)
            {
                gameObject.FullReset();
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            for (int index = children.Count - 1; index >= 0; index--)
            {
                children[index].HandleInput(inputHelper);
            }
        }

        public override void Reset()
        {
            base.Reset();
            for (int index = 0; index < children.Count; index++)
            {
                children[index].Reset();
            }
        }

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
