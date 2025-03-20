using UnityEngine;

public class BallController : MonoBehaviour
{
    public WinCondition winCondition;

    private void Start()
    {
        winCondition = GameObject.Find("Cannon").GetComponent<WinCondition>();
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Alvo"))
        {
            winCondition.pontuacao++;
            Destroy(collision.gameObject);
        }
        

        Debug.Log($"Objeto {gameObject} colidiu com {collision.gameObject}");

        
    }
}
