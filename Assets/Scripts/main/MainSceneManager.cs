using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MainSceneManager : MonoBehaviourPunCallbacks
{
    public GameObject sullePrefab; // ���� ������
    public GameObject studentPrefab; // �л� ������

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
            Debug.LogError("�������� �Ҵ���� �ʾҽ��ϴ�. ���� Ȯ�� �ʿ�.");
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

            // ���⼭ ��ġ �ٲ��ֽø� �˴ϴ�
        };

        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
    }
}
