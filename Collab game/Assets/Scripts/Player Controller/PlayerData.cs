using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;

    public PlayerData (Player player)
    {
        position = new float[3];
        position[0] = player.transform.Find("PlayerObj").transform.position.x;
        position[1] = player.transform.Find("PlayerObj").transform.position.y;
        position[2] = player.transform.Find("PlayerObj").transform.position.z;
    }
}
