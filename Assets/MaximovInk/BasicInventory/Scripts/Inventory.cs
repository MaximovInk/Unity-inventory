using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace MaximovInk.Inventory {
    public class Inventory : MonoBehaviour
    {
        public List<Slot> slots = new List<Slot>();

        private void Awake()
        {
            slots = GetComponentsInChildren<Slot>().ToList();
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