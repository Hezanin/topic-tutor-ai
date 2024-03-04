using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinRoomCanvas createOrJoinRoomCanvas;
    [SerializeField]
    private CurrentRoomCanvas currentRoomCanvas;

    public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas { get { return createOrJoinRoomCanvas; } }
    public CurrentRoomCanvas CurrentRoomCanvas { get { return  currentRoomCanvas; } }
}
