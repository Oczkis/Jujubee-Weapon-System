using UnityEngine;

public class PlayerManager : MonoBehaviour, IManager
{
    public Player LocalPlayer { get; private set; }

    public void SetLocalPlayer(Player player) => LocalPlayer = player;
}
