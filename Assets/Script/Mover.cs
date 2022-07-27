using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float fireSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = transform.forward* fireSpeed;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
