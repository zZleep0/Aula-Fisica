using UnityEngine;

public class BallController : MonoBehaviour
{
    public WinCondition winCondition;

    public ParticleSystem explosionParticleSystem;
    public float radius = 5f;
    public float explosionForce = 700f;

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

        Instantiate(explosionParticleSystem, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObjectCollider in colliders)
        {
            Rigidbody rigidbody = nearbyObjectCollider.GetComponent<Rigidbody>();

            if (rigidbody != null && (rigidbody != gameObject.GetComponent<Rigidbody>()))
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, radius, explosionForce);
            }
        }

        Destroy(gameObject);

        //Debug.Log($"Objeto {gameObject} colidiu com {collision.gameObject}");
        
    }
}
