using UnityEngine;

public class Portal : MonoBehaviour
{
    public RoomManager.RoomData TargetRoomData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RoomManager.Instance.ChangeRoom(TargetRoomData);
        }
    }
}
