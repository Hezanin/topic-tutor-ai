using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] 
    private string gameVersion = "1.0";
    [SerializeField]
    private string nickname = "Hezanin";

    public string GameVersion { get { return gameVersion; } }
    public string NickName { get { return nickname + Random.Range(0,999).ToString(); } }
}
