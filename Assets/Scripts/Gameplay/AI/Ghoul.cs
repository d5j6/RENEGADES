namespace RENEGADES.Gameplay.AI
{
    public class Ghoul : Enemy
    {
        //set custom speed for ghoul
        private const float SPEED = 5;

        public override void MOVE(float s)
        {
            base.MOVE(SPEED);

        }
    }
}
