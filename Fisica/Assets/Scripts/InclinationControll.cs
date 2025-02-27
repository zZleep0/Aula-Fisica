using UnityEngine;

public class InclinationControll : MonoBehaviour
{
    [SerializeField] private float _inclinationSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        float horizontal = -Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, horizontal * Time.deltaTime * _inclinationSpeed);
        float vertical = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right, vertical * Time.deltaTime * _inclinationSpeed);


    }
}
