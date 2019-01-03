using UnityEngine;
using MaximovInk.Utils;

namespace MaximovInk.Inventory
{
    public class InventoryPanel : AdvancedMonoBehaviaur
    {
        public Sprite icon;
        public int IconIndex = -1;
        public InvInteractObject @object;

        public void Init()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {

        }
    }
}
