using UnityEngine;
using UnityEngine.UI;

namespace MaximovInk.Inventory
{
    public class Slot : MonoBehaviour
    { 
        public DataItem StartItem;
        public DataItem DataItem
        {
            get { return data_item; }
            set  { data_item = value; refresh(); }
        }
        private DataItem data_item = new DataItem();

        private Image sprite_image;

        private Text count_text;

        private Slider condition_slider;

        private float clicked_timer = 1;
        private bool clicked = false;

        private void Awake()
        {
            
            sprite_image = transform.GetChild(0).GetComponent<Image>();
            count_text = GetComponentInChildren<Text>();
            condition_slider = GetComponentInChildren<Slider>();
            refresh();
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

        private void Start()
        {
            DataItem = StartItem;
        }

        private void set(Sprite sprite, Color color)
        {
            sprite_image.sprite = sprite;
            sprite_image.color = color;
        }

        public void refresh()
        {
            
            if(data_item.Condition <= 0 || data_item.Count <= 0 || data_item.Item == null)
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

            count_text.text = data_item.Item != null ? data_item.Count > 0 ? data_item.Count.ToString() :string.Empty : string.Empty;

            condition_slider.value = data_item.Item != null ? data_item.Condition /data_item.Item.MaxCondition  : 0;

            condition_slider.gameObject.SetActive(condition_slider.value != 0 ? true : false);
        }

        public void click()
        {
            if (clicked && DataItem.Item != null)
            {
                InventoryManager.Instance.SelectItem(this);
                clicked = false;
            }else
            {
                clicked = true;
            }       
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