using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public Transform[] items; //array de spawn point
    public GameObject prefabItem;
    public int qtSpawn = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Embaralha a lista de spawn points e seleciona os primeiros `qtSpawn`
        List<Transform> shuffledPoints = items.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < Mathf.Min(qtSpawn, shuffledPoints.Count); i++)
        {
            // Instancia o item como filho do ponto de spawn
            GameObject spawnedItem = Instantiate(prefabItem, shuffledPoints[i].position, Quaternion.identity, shuffledPoints[i]);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
