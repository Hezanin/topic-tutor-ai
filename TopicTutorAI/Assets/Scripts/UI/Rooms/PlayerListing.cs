using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    public Player Player {get; private set;}
    public bool Ready = false;

    public void SetPlayerInfo(Player player)
    {
        this.Player = player;
        this.text.text = this.Player.NickName;
    }
}
