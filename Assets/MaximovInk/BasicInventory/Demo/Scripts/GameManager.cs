using UnityEngine;
using MaximovInk.Utils;

public class GameManager : Singleton<GameManager> {
    public Player player = new Player();
    public float water_demand = 1f;
    public float eat_demand = 1f;

    public float period = 0f;

    private void Update()
    {
        if (period > 3)
        {
            period = 0;

            player.water -= eat_demand;
            player.water = Mathf.Clamp(player.water, 0, 100);

            player.eat -= eat_demand;
            player.eat = Mathf.Clamp(player.eat, 0, 100);

            if (player.water == 0 || player.eat == 0)
            {
                player.health -= 0.01f;
            }
        }
        period += Time.deltaTime;
    }

    [System.Serializable]
    public class Player
    {

        public float health = 100;

        public float water = 100;

        public float eat = 100;
    }
}
