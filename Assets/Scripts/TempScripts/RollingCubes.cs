using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingCubes : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newConstantVel = Vector3.right * speed;
        newConstantVel.y = rb.velocity.y;
        rb.velocity = newConstantVel;
        if (GetComponent<Renderer>().isVisible == false)
            Destroy(gameObject);
    }
}
