using NUnit.Framework;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public Transform[] items; //array de spawn point
    public GameObject prefabItem;
    public int qtSpawn = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(prefabItem, items[Random.Range(0, items.Length)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
