using TMPro;
using UnityEngine;

public class CondVitoria : MonoBehaviour
{
    public int pontos = 0;
    public ParticleSystem explosao;

    public TextMeshProUGUI txtFinal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txtFinal.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pontos >= 6)
        {
            Vitoria();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("objetivo"))
        {
            pontos++;
            Destroy(other.gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("obstaculo"))
        {
            Instantiate(explosao, transform.position, transform.rotation);
            Derrota();
        }
    }

    void Vitoria()
    {
        txtFinal.gameObject.SetActive(true);
        txtFinal.SetText("Vitoria");
    }

    void Derrota()
    {
        txtFinal.gameObject.SetActive(true);
        txtFinal.SetText("Derrota");

        //Destroy(gameObject);
    }
}
