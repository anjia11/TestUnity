using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class RoomManager : MonoBehaviour
{
    [System.Serializable]
    public struct RoomData
    {
        public string roomName;
        public Vector3 playerSpawnPosition;
    }

    private static RoomManager _instance;
    public static RoomManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject managerObject = new GameObject("RoomManager");
                _instance = managerObject.AddComponent<RoomManager>();
            }
            return _instance;
        }
    }

    private RoomData currentRoomData;

    public delegate void RoomChanged(RoomData newRoomData);
    public static event RoomChanged OnRoomChanged;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            // Subscribing to scene changes
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Handle scene loaded event
        // For example, update currentRoomData based on the loaded scene
        // You can implement a mapping between scene names and room data
        UpdateCurrentRoomData();
    }

    private void UpdateCurrentRoomData()
    {
        // Implement logic to determine current room data based on the loaded scene
        // Example: You may have a dictionary that maps scene names to room data
        // For simplicity, let's assume a direct mapping between scene name and room data
        currentRoomData.roomName = SceneManager.GetActiveScene().name;

        // Trigger the event to inform other components that the room has changed
        OnRoomChanged?.Invoke(currentRoomData);
    }

    public IEnumerator ChangeRoom(RoomData roomData)
    {
        currentRoomData = roomData;
        SceneManager.LoadScene(roomData.roomName);
        
        yield return new WaitForSeconds(1);
        Instantiate(PlayerManager.Instance.playerPrefab, roomData.playerSpawnPosition, Quaternion.identity);
    }

    public void GetLoc(RoomData roomData)
    {
        currentRoomData = roomData;
    }

    public RoomData GetCurrentRoomData()
    {
        return currentRoomData;
    }
}
