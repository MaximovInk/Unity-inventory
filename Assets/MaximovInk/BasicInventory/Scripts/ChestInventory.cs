namespace MaximovInk.Inventory
{
    public class ChestInventory : Inventory
    {
        public override void SlotsChanged()
        {
            (@object as Storage).Set(slots);
        }
    }
}