using UnityEngine;

public class RigidBodyBooster : MonoBehaviour
{
    [SerializeField] private float _forceAmount = 100f;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * _forceAmount);
        }
    }
}
