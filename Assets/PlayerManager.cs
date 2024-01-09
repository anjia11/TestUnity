using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject playerPrefab;
    private Vector3 _playerSpawnPos;
    private static PlayerManager _instance;
    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject playerObject = new GameObject("PlayerManager");
                _instance = playerObject.AddComponent<PlayerManager>();
            }
            return _instance;
        }
    }

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
        }
    }
}