using System;
using UnityEngine;
using UnityEngine.UI;

namespace MaximovInk.Inventory
{
    public class Slot : MonoBehaviour
    {
        public int ID;

        public DataItem StartItem;
       public DataItem DataItem
        {
            get { return data_item; }
            set  { data_item = value; refresh(); }
        }
        protected DataItem data_item = new DataItem();

        public Image image;

        protected Image sprite_image;
        protected Slider condition_slider;
        protected Text count_text;

        protected float clicked_timer = 1;
        protected bool clicked = false;

        private bool isInit = false;

        public virtual void Init()
        {
            if (!isInit)
            {
                condition_slider = GetComponentInChildren<Slider>();
                image = GetComponent<Image>();
                sprite_image = transform.GetChild(0).GetComponent<Image>();
                count_text = GetComponentInChildren<Text>();

                DataItem = StartItem;

                refresh();
            }

            isInit = true;
        }

        public virtual bool setItem(DataItem item)
        {
            if (DataItem == null)
            {
                DataItem = item;
                return true;
            }
            return false;
        }

        protected void set(Sprite sprite, Color color)
        {
            sprite_image.sprite = sprite;
            sprite_image.color = color;
        }

        public void refresh()
        {

            if (data_item.Condition <= 0 || data_item.Count <= 0 || data_item.Item == null)
            {
                data_item.Item = null;
                data_item.Count = 0;
                data_item.Condition = 0;
            }

            if (data_item.Item != null)
            {
                data_item.Condition = Mathf.Clamp(data_item.Condition, 0, data_item.Item.MaxCondition);

                if (DataItem.Item.Sprite != null)
                {
                    set(data_item.Item.Sprite, Color.white);
                }
                else
                {
                    set(null, Color.clear);
                }
            }
            else
            {
                set(null, Color.clear);
            }

            condition_slider.value = data_item.Item != null ? data_item.Condition / data_item.Item.MaxCondition : 0;
            condition_slider.gameObject.SetActive(condition_slider.value != 0 ? true : false);
            
            count_text.text = data_item.Item != null ? data_item.Count > 0 ? data_item.Count.ToString() : string.Empty : string.Empty;
        }

        public virtual void click()
        {
            onClick();
            if (clicked && DataItem.Item != null)
            {
                InventoryManager.Instance.SelectItem(this);
                clicked = false;
            }else
            {
                clicked = true;
            }       
        }

        protected virtual void onClick()
        {

        }

        private void Update()
        {
            if (clicked == true)
            {
                clicked_timer -= Time.deltaTime;
                if (clicked_timer < 0)
                {
                    clicked = false;
                    clicked_timer = 1;
                }
            }
        }
    }
}