//Unity
using UnityEngine;
using UnityEngine.SceneManagement;

//C#
using System.Collections.Generic;

namespace RENEGADES.Managers
{
    public class LevelLoader : MonoBehaviour
    {
        public enum Levels
        {
            MainMenu,
            Game
        }

        private Dictionary<Levels, int> LevelLookUp = new Dictionary<Levels, int>()
        {
            {Levels.MainMenu,0 },
            {Levels.Game,1 }
        };

        public void LoadLevel(Levels level)
        {
            SceneManager.LoadScene(LevelLookUp[level]);
        }
    }
}
