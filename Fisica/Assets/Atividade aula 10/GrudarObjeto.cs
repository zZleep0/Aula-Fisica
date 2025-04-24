using UnityEngine;

public class GrudarObjeto : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject charaCollision = GameObject.Find("head");
            gameObject.transform.SetParent(charaCollision.transform);

            ConstantForce forca = GetComponent<ConstantForce>();
            forca.enabled = false;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }
}
