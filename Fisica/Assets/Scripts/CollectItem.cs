using TMPro;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    
    public TextMeshProUGUI txtCondicao;

    [SerializeField] private int itemQt = 0;
    private bool vitoria = false;
    private bool derrota = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txtCondicao.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (vitoria)
        {
            txtCondicao.gameObject.SetActive(true);
            txtCondicao.text = "Vitória";
            Debug.Log("Vitoria");
        }
        else if (derrota)
        {
            txtCondicao.gameObject.SetActive(true);
            txtCondicao.text = "Derrota";
            Debug.Log("Derrota");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemQt++;
            Debug.Log("Agora tem " + itemQt + " itens");
            Destroy(other.gameObject);

            if (itemQt >= 6)
            {
                vitoria = true;
            }
        }

        else if (other.CompareTag("Limite"))
        {
            derrota = true;
        }
    }
}
