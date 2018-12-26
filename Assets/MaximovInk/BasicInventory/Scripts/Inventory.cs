using System.Collections.Generic;
using System.Linq;

namespace MaximovInk.Inventory {
    public class Inventory : InventoryPanel
    {
        public List<Slot> slots = new List<Slot>();

        protected override void OnInit()
        {
            slots = GetComponentsInChildren<Slot>().ToList();
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].ID = i;
                slots[i].Init();
            }
        }

        public void AddItem(DataItem item)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].DataItem.Item == null)
                {
                    slots[i].DataItem = new DataItem(item);
                    return;
                }
            }
        }

        public void RemoveItem(int index_slot)
        {
            if (index_slot < slots.Count)
            {
                slots[index_slot].DataItem.Item = null;
                slots[index_slot].refresh();
            }
        }
    }
}