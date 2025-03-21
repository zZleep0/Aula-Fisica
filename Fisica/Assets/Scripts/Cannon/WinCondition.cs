using TMPro;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public int pontuacao = 0;
    public TextMeshProUGUI txtpontuacao;
    public bool canEnd = false;

    public GameObject telaVitoria;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        telaVitoria.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        txtpontuacao.text = "Pontuação: " + pontuacao;

        if (pontuacao >= 3)
        {
            canEnd = true;
            
        }
    }

    void Vitoria()
    {
        telaVitoria.SetActive (true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Final") && canEnd == true)
        {
            Vitoria();
        }
    }
}
