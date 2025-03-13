using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 5f; //velocidade de rotação do canhao
    public float minAngle = -10f; //angulo minimo
    public float maxAngle = 45f; // angulo maximo

    private float currentAngle; // angulo atual

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Inicializa o angulo com base na rotacao inicial do canhao
        currentAngle = transform.localEulerAngles.x;
        if (currentAngle > 180) currentAngle -= 360; //ajusta caso esteja acima de 180
    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput != 0)
        {
            currentAngle -= scrollInput * rotationSpeed; //Ajusta o angulo
            currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle); //Limita o angulo

            transform.localRotation = Quaternion.Euler(currentAngle, 0, 0); //Aplica a rotacao

            Debug.Log($"Canhao inclinado para {currentAngle} graus"); //Log para depuracao



        }
    }
}
