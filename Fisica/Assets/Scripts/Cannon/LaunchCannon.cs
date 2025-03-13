using UnityEngine;

public class LaunchCannon : MonoBehaviour
{
    public GameObject projectile;
    public float velocity = 700f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Lançamento da bola
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, velocity, 0));

            
        }
    }
}
