using TMPro;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public bool turn = false;
    public string player;

    public TextMeshProUGUI txtTurno;
    public TextMeshProUGUI txtPontosP1;
    public TextMeshProUGUI txtPontosP2;
    public TextMeshProUGUI txtFinal;

    public int pontosP1 = 0;
    public int pontosP2 = 0;

    public bool fim = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (turn)
        {
            case false:
                player = "Player 1";
                break;
            case true:
                player = "Player 2";
                break;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    turn =! turn;
        //    //Debug.Log(turn);
        //}

        txtTurno.text = "É a vez do " + player;

        txtPontosP1.text = pontosP1.ToString();
        txtPontosP2.text = pontosP2.ToString();

        if (fim)
        {
            txtFinal.text = player + " perdeu";
        }

    }
}
