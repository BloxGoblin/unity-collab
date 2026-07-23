using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public float[] inventory;

    public PlayerData (Player player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        inventory = GetInventory();
    }

    float[] GetInventory()
    {
        int index = 0;

        float[] inv = new float[InventoryManager.Instance.Items.Count];

        foreach (var item in InventoryManager.Instance.Items) //Save every items id
        {
            inv[index] = item.id;
            index += 1;
        }

        return inv;
    }
}
