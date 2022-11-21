using Engine.Control;
using Engine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Engine.GameStates
{



    /// <summary>
    /// A class that contains all game states of the game, and that makes sure
    /// that the currently active game state updates and draws itself.
    /// </summary>
    public class GameStateManager : IGameObject
    {
        // The collection of all game states.
        Dictionary<string, GameState> gameStates;

        // A reference to the game state that is currently active.
        GameState currentGameState;

        /// <summary>
        /// Creates a new GameStateManager object.
        /// </summary>
        public GameStateManager()
        {
            gameStates = new Dictionary<string, GameState>();
            currentGameState = null;
        }

        /// <summary>
        /// Adds a game state to the collection.
        /// </summary>
        /// <param name="name">The name by which this game state should be indexed.</param>
        /// <param name="state">The game state to add.</param>
        public void AddGameState(string name, GameState state)
        {
            gameStates[name] = state;
        }

        /// <summary>
        /// Gets the game state with the given name, if it exists.
        /// </summary>
        /// <param name="name">The name of the game state to find.</param>
        /// <returns>The GameState with that name, or null if it could not be found.</returns>
        public GameState GetGameState(string name)
        {
            if (gameStates.ContainsKey(name))
                return gameStates[name];
            return null;
        }

        /// <summary>
        /// Switches to a different active game state.
        /// </summary>
        /// <param name="name">The name of the game state to set as the new active one.</param>
        public void SwitchTo(string name)
        {
            if (gameStates.ContainsKey(name))
                currentGameState = gameStates[name];
        }

        /// <summary>
        /// Makes sure that the currently active game state calls HandleInput.
        /// </summary>
        /// <param name="inputHelper">The input helper to use.</param>
        public void HandleInput(InputHelper inputHelper)
        {
            if (currentGameState != null)
                currentGameState.HandleInput(inputHelper);
        }

        /// <summary>
        /// Makes sure that the currently active game state calls Update.
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed in the game.</param>
        public void Update(GameTime gameTime)
        {
            if (currentGameState != null)
                currentGameState.Update(gameTime);
        }

        /// <summary>
        /// Makes sure that the currently active game state calls Draw.
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed in the game.</param>
        /// <param name="spriteBatch">A sprite batch object used for drawing sprites.</param>
        /// <param name="offset"></param>
        /// 
        public void Draw(SpriteBatch spritebatch, GameTime gametime)
        
        {
            if (currentGameState != null)
                currentGameState.Draw(spritebatch, gametime);
        }

        /// <summary>
        /// Makes sure that the currently active game state calls Reset.
        /// </summary>
        public void Reset()
        {
            if (currentGameState != null)
                currentGameState.Reset();
        }


        /// <summary>
        /// Makes sure that the currently active game state calls Fully Resets.
        /// </summary>
        public void FullReset()
        {
            if (currentGameState != null)
                currentGameState.FullReset();
        }
    }

}
