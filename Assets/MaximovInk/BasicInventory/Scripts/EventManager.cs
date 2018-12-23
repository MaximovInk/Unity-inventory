using UnityEngine;
using MaximovInk.Utils;

namespace MaximovInk.Inventory
{
    public class EventManager : Singleton<EventManager>
    {
        public delegate void OnEquip(int index);
        public delegate void OnHeal(float health);
        public delegate void OnEat(float eat);
        public delegate void OnDrink(float drink);
        public delegate void OnItemChange(int id , int count, Slot from);

        public event OnEquip onEquip;
        public event OnHeal onHeal;
        public event OnEat onEat;
        public event OnDrink onDrink;
        public event OnItemChange onItemChange;

        public void UseFunction(UseFunction function, Slot from)
        {
            for (int i = 0; i < function.events.Count; i++)
            {
                UsableEvent(function.events[i],from);
            }
        }

        private void UsableEvent(USABLE_EVENT _event, Slot from)
        {
            string[] parameters = _event.value.Split('/');

            if (parameters.Length == 0)
                return;

            if (from.DataItem.Item == null)
                return;

            float first_param = 0;

            float.TryParse(parameters[0], out first_param);

            float second_param = 1;

            if (parameters.Length > 1)
            {
                float.TryParse(parameters[1], out second_param);
                from.DataItem.Condition -= (from.DataItem.Item.MaxCondition / second_param / from.DataItem.Count);
            }
            else
            {
                from.DataItem.Count -= 1;
            }

            switch (_event.type)
            {
                case USE_TYPE.EQUIP:
                    if (onEquip != null)
                    {
                        onEquip((int)Mathf.Clamp( first_param,0,999));
                    }
                    break;
                case USE_TYPE.HEAL:
                    float heal = first_param;
                    if (onHeal != null)
                    {
                        onHeal(heal);
                    }
                    break;
                case USE_TYPE.EAT:
                    float eat = second_param;
                    eat *= from.DataItem.Condition / from.DataItem.Item.MaxCondition;
                    if (onEat != null)
                    {
                        onEat(eat);
                    }
                    break;
                case USE_TYPE.DRINK:
                    float water = second_param;
                    water *= from.DataItem.Condition / from.DataItem.Item.MaxCondition;
                    if (onDrink != null)
                    {
                        onDrink(water);
                    }
                    break;
                case USE_TYPE.CHANGE:
                    int id = (int)Mathf.Clamp(first_param, 0, 999);
                    if (id >= InventoryManager.Instance.ItemDatabase.items.Length)
                        return;

                    if (onItemChange != null)
                    {
                        onItemChange(id, (int)Mathf.Clamp(second_param,1,999), from);
                    }
                    break;
            }
            from.refresh();
        }
    }
}