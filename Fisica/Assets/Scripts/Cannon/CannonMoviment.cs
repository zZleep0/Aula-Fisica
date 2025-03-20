using UnityEngine;

public class CannonMoviment : MonoBehaviour
{
    public WheelCollider[] wheels; // Array com os 4 wheels colliders
    public float motorTorque = 1000f;
    public float maxSteerAngle = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float steerInput = Input.GetAxis("Horizontal");

        foreach (WheelCollider wheel in wheels)
        {
            wheel.motorTorque = moveInput * motorTorque;
        }

        wheels[0].steerAngle = steerInput * maxSteerAngle; //Rotacao das rodas da frente
        wheels[1].steerAngle = steerInput * maxSteerAngle;
    }
}
