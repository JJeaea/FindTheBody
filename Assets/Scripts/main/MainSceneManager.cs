using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MainSceneManager : MonoBehaviourPunCallbacks
{
    public GameObject sullePrefab; // 술래 프리팹
    public GameObject studentPrefab; // 학생 프리팹

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        string myRole = GameManager.instance.GetMyRole();

        GameObject prefabToInstantiate = null;

        if (myRole == "Sulle")
        {
            prefabToInstantiate = sullePrefab;
        }
        else if (myRole == "Student")
        {
            prefabToInstantiate = studentPrefab;
        }

        if (prefabToInstantiate != null)
        {
            PhotonNetwork.Instantiate(prefabToInstantiate.name, GetRandomSpawnPoint(), Quaternion.identity);
        }
        else
        {
            Debug.LogError("프리팹이 할당되지 않았습니다. 역할 확인 필요.");
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        Vector3[] spawnPoints = new Vector3[]
        {
            new Vector3(-10, 1, 2),
            new Vector3(-10, 1, 1),
            new Vector3(-11, 1, 0),
            new Vector3(-10, 1, -1),
            new Vector3(-9, 1, 0),

            // 여기서 위치 바꿔주시면 됩니다
        };

        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
    }
}
