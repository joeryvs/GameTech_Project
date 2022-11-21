using System.Collections.Generic;
using System.IO;

namespace Engine
//namespace Engine
{
    /// <summary>
    /// An abstract class that represents a game with multiple levels and their statuses.
    /// </summary>
    public abstract class ExtendedGameWithLevels : ExtendedGame
    {
        /// <summary>
        /// custom string to remove duplicate code
        /// </summary>
        private const string LevelStatusPath = "Content/Levels/levels_status.txt";
        public const string StateName_Title = "title";
        public const string StateName_Help = "help";
        public const string StateName_LevelSelect = "levelselect";
        public const string StateName_Playing = "playing";
        public const string StateName_Error = "error";

        static readonly List<LevelStatus> progress = new List<LevelStatus>();

        /// <summary>
        /// The total number of levels in the game.
        /// </summary>
        public static int NumberOfLevels
        {
            get { return progress.Count; }
        }

        /// <summary>
        /// Loads the player's level progress from a text file.
        /// </summary>
        protected void LoadProgress()
        {
            // clear the level progress list
            progress.Clear();
            // read the lines of the "levels_status" file; add a LevelStatus for each line
            string[] pr = File.ReadAllLines(LevelStatusPath);
            foreach (string line in pr)
            {
                progress.Add(StrToLevelStatus(line));
            }
            return;
        }
        /// <summary>
        /// method to convert a LevelStatus to a string
        /// </summary>
        /// <param name="ls">the levelStatus you want to convert to a string</param>
        /// <returns>return a string depending on the levelstatus</returns>
        private static string LsToString(LevelStatus ls)
        {
            return ls switch
            {
                LevelStatus.Locked => "locked",
                LevelStatus.Unlocked => "unlocked",
                LevelStatus.Solved => "solved",
                _ => "locked",
            };
        }
        /// <summary>
        /// Method that converts a string in to a LevelStatus
        /// </summary>
        /// <param name="fileLine">the input string</param>
        /// <returns>a levelstatus depending on the input string</returns>
        private static LevelStatus StrToLevelStatus(string fileLine)
        {
            return fileLine.ToLower() switch
            {
                "locked" => LevelStatus.Locked,
                "unlocked" => LevelStatus.Unlocked,
                "solved" => LevelStatus.Solved,
                _ => (LevelStatus)0,
            };
        }

        /// <summary>
        /// Gets the <see cref="LevelStatus"/> of the level with the given index.
        /// </summary>
        /// <param name="levelIndex">The index of the level to check,<param>
        /// <returns>The <see cref="LevelStatus"/> of the requested level.</returns>
        public static LevelStatus GetLevelStatus(int levelIndex)
        {
            return progress[levelIndex - 1];
        }

        /// <summary>
        /// Sets the <see cref="LevelStatus"/> of the given level to the given value.
        /// </summary>
        /// <param name="levelIndex">The index of the level to change.<param>
        /// <param name="status">The new desired status of the level.</param>
        static void SetLevelStatus(int levelIndex, LevelStatus status)
        {
            progress[levelIndex - 1] = status;
        }

        /// <summary>
        /// Marks a certain level as solved, then unlocks the next level (if applicable), 
        /// and finally saves the player's progress again.
        /// </summary>
        /// <param name="levelIndex">The index of the level to mark as solved.</param>
        public static void MarkLevelAsSolved(int levelIndex)
        {
            // mark this level as solved
            SetLevelStatus(levelIndex, LevelStatus.Solved);

            // if there is a next level, mark it as unlocked
            if (levelIndex < NumberOfLevels && GetLevelStatus(levelIndex + 1) == LevelStatus.Locked)
            { SetLevelStatus(levelIndex + 1, LevelStatus.Unlocked); }

            // store the new level status
            SaveProgress();
        }

        /// <summary>
        /// Saves the player's progress to a file.
        /// </summary>
        static void SaveProgress()
        {
            // write to the "levels_status" file; add a LevelStatus for each line
            StreamWriter w = new StreamWriter(LevelStatusPath);
            foreach (LevelStatus status in progress)
            {
                w.WriteLine(LsToString(status));
            }
            w.Close();
            return;
        }

        /// <summary>
        /// Sends the player to the next level in the game if such a level exists, 
        /// or to the level selection screen otherwise.
        /// </summary>
        /// <param name="levelIndex">The index of the current level.</param>
        public static void GoToNextLevel(int levelIndex)
        {
            // if this is the last level, go back to the level selection menu
            if (levelIndex == NumberOfLevels)
                GameStateManager.SwitchTo(StateName_LevelSelect);

            // otherwise, go to the next level
            else
                GetPlayingState().LoadLevel(levelIndex + 1);
        }

        /// <summary>
        /// Returns the game state with key StateName_Playing, cast to an IPlayingState object. 
        /// Each specific game should make sure that this game state actually exists.
        /// </summary>
        /// <returns>The game state with key StateName_Playing, cast to an IPlayingState object.</returns>
        public static IPlayingState GetPlayingState()
        {
            return (IPlayingState)GameStateManager.GetGameState(StateName_Playing);
        }
    }
}