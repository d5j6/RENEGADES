//Unity
using UnityEngine;

//C#
using System.Collections.Generic;


namespace RENEGADES.Managers
{
    
    /// <summary>
    /// Controlls the Dictionary that holds that number of players playing
    /// </summary>
    public class GameSettings : MonoBehaviour
    {
        public enum PlayerType { Assault,Engineer}

        /// <summary>
        /// Default Dictionary with Player 1 as an Assault Character
        /// </summary>
        private Dictionary<int, PlayerType> PLAYERS = new Dictionary<int, PlayerType> { { 1, PlayerType.Engineer } };

        private void Awake()
        {
            
        }

        public Dictionary<int,PlayerType> GetPlayers()
        {
            return PLAYERS;
        }

        public PlayerType GetType(int playerNumber)
        {
            return PLAYERS[playerNumber];
        }

        public void SetPlayerType(int player,PlayerType type)
        {
            PLAYERS[player] = type;
        }

        public void AddPlayer(int player,PlayerType type)
        {
            PLAYERS.Add(player, type);
        }

        public void RemovePlayer(int player)
        {
          if(PLAYERS.ContainsKey(player)) PLAYERS.Remove(player);
        }

    }
}
