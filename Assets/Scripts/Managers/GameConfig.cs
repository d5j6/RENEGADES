//Unity
using UnityEngine;


namespace RENEGADES.Managers
{
    //Class will basically be used to get anything in the scene needing to be loading 
    public class GameConfig : MonoBehaviour
    {
        [Header("Game Manager Prefab")]
        [Tooltip("Prefab to Potentially Spawn GameManager")]
        public GameManager gameManager;
        
        private void Awake()
        {
            FindManager();
        }

        private void FindManager()
        {
            if (FindObjectOfType<GameManager>() == null) Instantiate(gameManager);
        }
    }
}
