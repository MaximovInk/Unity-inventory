using MaximovInk.Utils;
using MaximovInk.Inventory;

public class GameManager : Singleton<GameManager> {
    private EventManager eventManager;
    public Character player;

    private void Start()
    {
        eventManager = EventManager.Instance;

        eventManager.onDrink += Manager_onDrink;
        eventManager.onEat += Manager_onEat;
        eventManager.onHeal += Manager_onHeal;
        eventManager.onItemChange += Manager_onItemChange;
        eventManager.onEquip += EventManager_onEquip;
    }

    private void EventManager_onEquip(int index)
    {

    }

    private void Manager_onItemChange(int id, int count, Slot from)
    {
        for (int i = 0; i < count; i++)
        {
            DataItem new_item = new DataItem(InventoryManager.Instance.ItemDatabase.items[id]);
            new_item.Condition = from.DataItem.Condition / from.DataItem.Item.MaxCondition * new_item.Item.MaxCondition;
            from.GetComponentInParent<Inventory>().AddItem(new_item);
        }
    }

    private void Manager_onHeal(float heal)
    {
        player.health += heal;
    }

    private void Manager_onEat(float eat)
    {
        player.eat += eat;
    }

    private void Manager_onDrink(float drink)
    {
        player.water += drink;
    }

    private void OnDestroy()
    {
        eventManager.onDrink -= Manager_onDrink;
        eventManager.onEat -= Manager_onEat;
        eventManager.onHeal -= Manager_onHeal;
        eventManager.onItemChange -= Manager_onItemChange;
    }
}
