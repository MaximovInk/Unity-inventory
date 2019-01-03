using System.Collections.Generic;

namespace MaximovInk.Inventory
{
    public class Storage : InvInteractObject
    {
        public List<StorageItem> Items = new List<StorageItem>();

        public void Set(List<Slot> slots)
        {
            Items.Clear();
            for (int i = 0; i < slots.Count; i++)
            {
                Items.Add(new StorageItem() {
                    item = slots[i].DataItem.Item,
                    Condition = slots[i].DataItem.Condition ,
                    Count = slots[i].DataItem.Count
                });
            }
        }

        protected override void OnEnter()
        {
            if (instance_index_panel == -1)
                return;

            Inventory inventory = InventoryManager.Instance.InventoryPanels[instance_index_panel] as Inventory;
            Slot slotPrefab = InventoryManager.Instance.slotPrefab;

            if (slotPrefab == null || inventory == null)
                return;
            for (int i = 0; i < Items.Count; i++)
            {

                Slot slot = Instantiate(slotPrefab, inventory.transform);

                if (i < Items.Count )
                {
                    DataItem dataItem = new DataItem() { Item = Items[i].item , Count = Items[i].Count , Condition = Items[i].Condition};
                    slot.StartItem = dataItem;
                        
                }
            }
            InventoryManager.Instance.InventoryPanels[instance_index_panel].Init();
        }

        protected override void OnExit()
        {
        }
    }
}