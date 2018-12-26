using UnityEngine;

namespace MaximovInk.Inventory
{
    public class InventoryPanel : MonoBehaviour
    {
        public Sprite icon;
        public int IconIndex = -1;

        public void Init()
        {
            OnInit();
        }

        protected virtual void OnInit()
        {

        }
    }
}
