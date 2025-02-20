using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Color randomColorWithAlpha = GetRandomColorWithAlpha();

        GetComponent<Renderer>().material.color = randomColorWithAlpha;
    }

    Color GetRandomColorWithAlpha()
    {
        return new Color (Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 0.25f);
    }
}
