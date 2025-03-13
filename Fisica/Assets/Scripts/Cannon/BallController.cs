using UnityEngine;

public class BallController : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        Debug.Log($"Objeto {gameObject} colidiu com {collision.gameObject}");

        
    }
}
