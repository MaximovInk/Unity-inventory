using UnityEngine.EventSystems;
using UnityEngine.UI;
using MaximovInk.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace MaximovInk.Inventory
{
    public class Tooltip : HideOnExitMouse<Tooltip> , IPointerExitHandler
    {
        public Text Name;
        public Text Description;
        public Image Sprite;
        private List<GameObject> actionButtons = new List<GameObject>();
        
        public void init(Slot slot)
        {
            DataItem item = slot.DataItem;
            gameObject.SetActive(true);
            Name.text = "Name: "+item.Item.name;
            Description.text = "Description: " +item.Item.Description;
            Sprite.sprite = item.Item.Sprite;

            Button actionButtonPrefab = InventoryManager.Instance.ActionButtonPrefab;

            Button dropButton = Instantiate(actionButtonPrefab, transform);
            dropButton.onClick.AddListener(() => { InventoryManager.Instance.DropItem(slot); slot.DataItem.Item = null; slot.refresh(); } );
            dropButton.GetComponentInChildren<Text>().text = "Drop";
            actionButtons.Add(dropButton.gameObject);

            for (int f = 0; f < item.Item.UseFunctions.Count; f++)
            {
                Button actionButton = Instantiate(actionButtonPrefab, transform);
                int function = f;

                actionButton.onClick.AddListener(() => { item.Item.Use(function, slot); gameObject.SetActive(false); });

                actionButton.GetComponentInChildren<Text>().text = item.Item.UseFunctions[f].name;
                actionButtons.Add(actionButton.gameObject);
            }
        }



        public void clear()
        {
            gameObject.SetActive(false);
            Name.text = string.Empty;
            Description.text = string.Empty;
            Sprite.sprite = null;

            for (int i = 0; i < actionButtons.Count; i++)
            {
                Destroy(actionButtons[i]);
            }
            actionButtons.Clear();
        }
    }
}