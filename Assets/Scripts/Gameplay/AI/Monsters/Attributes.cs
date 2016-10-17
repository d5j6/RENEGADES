
namespace RENEGADES.Gameplay.AI
{
    /// <summary>
    /// Class will hold data particular to an enemy
    /// </summary>
    /// 
    public enum DIFFICULTY { Easy,Normal,Hard,Nightmare}

    [System.Serializable]
    public class Attributes
    {
        public float SPEED;
        public float ATTACK_RANGE;
        public float ATTACK_SPEED;
        public float DAMAGE;
        public DIFFICULTY difficulty;

    }
}
