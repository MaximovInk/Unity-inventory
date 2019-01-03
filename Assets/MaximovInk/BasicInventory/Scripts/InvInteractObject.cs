using UnityEngine;

namespace MaximovInk.Inventory
{
    public abstract class InvInteractObject : MonoBehaviour
    {
        public InventoryPanel panel;

        protected int instance_index_panel = -1;

        protected abstract void OnEnter();

        protected abstract void OnExit();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.ToLower() == "player")
            {
                instance_index_panel = InventoryManager.Instance.InstantiateInventoryPanel(panel);
                InventoryManager.Instance.InventoryPanels[instance_index_panel].@object = this;
            }
            OnEnter();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag.ToLower() == "player")
            {
                if (instance_index_panel != -1)
                {
                    InventoryManager.Instance.RemoveInventoryPanel(instance_index_panel);
                    instance_index_panel = -1;
                }

               
            }
            OnExit();
        }
    }
}