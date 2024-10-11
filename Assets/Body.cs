using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class Body : MonoBehaviour
{
    public Vector3 initialVelocity;
    public string bodyName = "Unnamed";
    Transform meshHolder;
    public float mass;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
        rb.linearVelocity = initialVelocity;
        Debug.Log("Awake");
    }

    public void UpdateVelocity(Vector3 acceleration, float timeStep)
    {
        rb.AddForce(acceleration, ForceMode.Acceleration);
    }

    void OnValidate () {
        gameObject.name = bodyName;
    }

}