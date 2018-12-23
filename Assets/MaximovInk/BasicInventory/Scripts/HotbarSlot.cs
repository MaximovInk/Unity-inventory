namespace MaximovInk.Inventory
{
    public class HotbarSlot : Slot
    {
        public Hotbar hotbar;

        protected override void onClick()
        {
            if (hotbar == null)
                return;
            hotbar.select(ID);
        }
    }
}
