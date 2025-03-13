using UnityEngine;

public class CannonReaction : MonoBehaviour
{
    public float rotacaoBarrel;

    public float forca = 700f;
    public Rigidbody rb;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        rotacaoBarrel = GameObject.Find("Barrel").transform.rotation.x;

        if (Input.GetButtonDown("Fire1"))
        {

            rb.AddRelativeForce(new Vector3(0, 0, forca));

        }
    }
}
