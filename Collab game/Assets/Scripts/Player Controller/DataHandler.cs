using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public void Save(Player player)
    {
        SaveSystem.SavePlayerData(player);
    }

    public void Load(Player player)
    {
        PlayerData data = SaveSystem.LoadPlayerData(player);

        //Load saved position
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        player.transform.Find("PlrObj").transform.position = position;
    }
}
