using UnityEngine;

namespace MaximovInk.Inventory
{
    public class Hotbar : Inventory
    {
        public int SelectedSlot;
        public Color SelectedColor = Color.HSVToRGB(0,0,86);

        protected override void OnInit()
        {
            base.OnInit();
            for (int i = 0; i < slots.Count; i++)
            {
                (slots[i] as HotbarSlot).hotbar = this;
            }
        }

        public void select(int index)
        {
            clear();
            if (index < slots.Count && slots[index].image != null)
                slots[index].image.color = SelectedColor;
        }
        private void clear()
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].image != null)
                    slots[i].image.color = Color.white;
            }
        }
    }
}
