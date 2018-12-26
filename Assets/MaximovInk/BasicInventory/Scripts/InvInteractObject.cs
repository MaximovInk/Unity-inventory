using UnityEngine;

namespace MaximovInk.Inventory
{
    public abstract class InvInteractObject : MonoBehaviour
    {
        public InventoryPanel panel;

        protected abstract void OnEnter();

        protected abstract void OnExit();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.ToLower() == "player")
            {
                OnEnter();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag.ToLower() == "player")
            {
                OnExit();
            }
        }
    }
}