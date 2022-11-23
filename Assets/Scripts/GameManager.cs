using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] float PLAYER_LEVEL_SPAWN_DISTANCE;
    [SerializeField] int START_LEVEL_LOADING_AMOUNT;
    [SerializeField] GameObject[] tiles;
    [SerializeField] GameObject player;
    private Vector3 lastEndPoint;
    private void Start()
    {
        lastEndPoint = GameObject.Find("EndPoint").transform.position;
        for (int i = 0; i < START_LEVEL_LOADING_AMOUNT; i++)
        {
            SpawnLevelPart();
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || player.transform.position.y < -20)
        {
            SceneManager.LoadScene(0); 
        }
        else if(Vector3.Distance(player.transform.position, lastEndPoint) < PLAYER_LEVEL_SPAWN_DISTANCE)
        {
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        Transform levelPartTransform = Instantiate(tiles[UnityEngine.Random.Range(0, tiles.Length)].transform, lastEndPoint, Quaternion.identity);
        lastEndPoint = levelPartTransform.Find("EndPoint").position;
    }
}
