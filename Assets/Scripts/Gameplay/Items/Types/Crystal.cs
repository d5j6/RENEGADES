
namespace RENEGADES.Gameplay.Items
{
    public class Crystal : Item
    {
        public int amount = 1;
        public override void PickUP()
        {
            base.PickUP();
            GetPlayer().UpdateCrystals(amount);
        }
    }
}
