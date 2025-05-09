using TMPro;
using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(Collider))]

public class JengaPiece : MonoBehaviour
{
    [Header("Drag Settings")]
    public float maxDragDistance = 2f; //Distancia maxima que a peca pode ser arrastada

    [Header("Push Settings")]
    public float pushForce = 5f; //Forca aplicada em clique simples
    public float doubleClickForceMultiplier = 2f; //Multiplicador de forca para duplo clique
    public float doubleClickThreshhold = 0.3f; //Tempo maximo entre cliques para ser considerado doplo clique

    private Rigidbody rb;
    private Camera mainCamera;
    public bool isDragging = false;
    private Vector3 offset;
    private Vector3 startDragPosition;
    private float lastClickTime = -1f;

    public int valor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        //Detecta clique duplo
        float timeSinceLastClick = Time.time - lastClickTime;
        lastClickTime = Time.time;

        //Se for duplo clique, aplica forca maior e nao inicia arrasto
        if (timeSinceLastClick <= doubleClickThreshhold)
        {
            ApplyPush(pushForce * doubleClickForceMultiplier);
            return;
        }

        //Se for clique simples, aplica forca normal
        ApplyPush(pushForce);

        //Inicia o arrasto
        isDragging = true;
        rb.isKinematic = true;

        //Calcula offset entre o mouse e a posicao atual da peca
        Vector3 mousePos = GetMouseWorldPosition();
        offset = transform.position - mousePos;
        startDragPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        //Obtem posicao do mouse no mundo
        Vector3 mousePos = GetMouseWorldPosition();
        Vector3 targetPos = mousePos + offset;

        //Limita a distancia de arrasto
        Vector3 dragVector = targetPos - startDragPosition;
        if (dragVector.magnitude > maxDragDistance)
        {
            dragVector = dragVector.normalized * maxDragDistance;
        }

        //Mover
        transform.position = startDragPosition + dragVector;

        //LEVANTAR E ABAIXAR PEÇA
        float velo = 3f;
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * velo);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * velo);
        }

        float veloRotation = 30f;
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * veloRotation);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * veloRotation);
        }
    }

    private void OnMouseUp()
    {
        //Libera arrato e ativa fisica novamente
        isDragging = false;
        rb.isKinematic = false;
    }


    //Aplica forca na direcao da camera como um empurrao
    private void ApplyPush(float force)
    {
        Vector3 direction = (transform.position - mainCamera.transform.position).normalized;
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    //Retorna a posicao do mouse no plano horizontal a altura da peca
    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position); //Plano horizontal baseado na altura atual da peca
        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }
        return transform.position;
    }

    
}
