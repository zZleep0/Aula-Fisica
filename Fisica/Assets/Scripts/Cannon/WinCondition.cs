using TMPro;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public int pontuacao = 0;
    public TextMeshProUGUI txtpontuacao;

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
            Vitoria();
        }
    }

    void Vitoria()
    {
        telaVitoria.SetActive (true);
    }
}
