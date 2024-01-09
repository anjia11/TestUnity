using UnityEngine;
public class Door : MonoBehaviour
{
    public RoomManager.RoomData TargetRoomData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(RoomManager.Instance.ChangeRoom(TargetRoomData));
        }
    }
}
