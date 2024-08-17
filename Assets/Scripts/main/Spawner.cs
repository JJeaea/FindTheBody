using Photon.Pun;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public Transform[] spawnPoints;

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnObjects();
        }
    }

    void SpawnObjects()
    {
        foreach (var prefab in objectPrefabs)
        {
            
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];

            
            PhotonNetwork.Instantiate(prefab.name, spawnPoint.position, Quaternion.identity);
        }
    }
}