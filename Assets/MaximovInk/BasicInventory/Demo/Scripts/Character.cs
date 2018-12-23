using UnityEngine;

public class Character : MonoBehaviour {
    public float eat;
    public float water;
    public float health;

    public float water_demand = 1f;
    public float eat_demand = 1f;

    public float period = 0f;

    private void Update()
    {
        if (period > 3)
        {
            period = 0;

            water -= eat_demand;
            water = Mathf.Clamp(water, 0, 100);

            eat -= eat_demand;
            eat = Mathf.Clamp(eat, 0, 100);

            if (water == 0 || eat == 0)
            {
                health -= 0.01f;
            }
        }
        period += Time.deltaTime;
    }


}
