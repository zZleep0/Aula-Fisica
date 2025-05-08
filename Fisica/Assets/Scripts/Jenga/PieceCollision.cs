using System.Collections;
using TMPro;
using UnityEngine;

public class PieceCollision : MonoBehaviour
{
    public bool canStart = false;
    public JengaPiece piece;

    public bool isFlying = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        piece = GetComponent<JengaPiece>();

        StartCoroutine(Comecar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Comecar()
    {
        yield return new WaitForSeconds(1f);
        canStart = true;
        Debug.Log("pode começar");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canStart)
        {
            if (collision.collider.CompareTag("Chao"))
            {
                PlayerTurn turno = GameObject.Find("PlayerTurn").GetComponent<PlayerTurn>();
                turno.fim = true;
                
            }
            
            
            if (!piece.isDragging && isFlying)
            {
                if (collision.collider.CompareTag("10") || collision.collider.CompareTag("20") || collision.collider.CompareTag("30") || collision.collider.CompareTag("40") || collision.collider.CompareTag("50"))
                {
                    Debug.Log("colidiu" + collision.gameObject.name);
                    PlayerTurn turno = GameObject.Find("PlayerTurn").GetComponent<PlayerTurn>();
                    if (turno.player == "Player 1")
                    {
                        turno.pontosP1 += piece.valor;
                    }
                    else if (turno.player == "Player 2")
                    {
                        turno.pontosP2 += piece.valor;
                    }

                    StartCoroutine(TempoColisao());

                    if (turno.fim) return;

                    turno.turn =! turno.turn;
                    
                    isFlying = false;
                }
            }
        }
    }

    IEnumerator TempoColisao()
    {
        yield return new WaitForSeconds(2f);
    }

    private void OnMouseUp()
    {
        isFlying = true;
    }
}
