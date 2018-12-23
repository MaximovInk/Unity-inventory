using UnityEngine;

namespace MaximovInk.Inventory {
    public class DragItem : MonoBehaviour
    {
        public DataItem item;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            if (item == null || item.Item == null || item.Item.GetDroppedSprite() == null)
                return;

            Sprite sprite = item.Item.GetDroppedSprite();
            GetComponent<SpriteRenderer>().sprite = sprite;
            Vector2 S = GetComponent<SpriteRenderer>().sprite.bounds.size;
            GetComponent<BoxCollider2D>().size = S * 1.2f;
        }

        public void Take()
        {
            InventoryManager.Instance.MainInventory.AddItem(item);
            Destroy(gameObject);
        }
    }
}