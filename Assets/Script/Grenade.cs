using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosionEffact;
    public float delay = 3f;
    public float explosionForce = 10f;
    public float radius = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode",delay);

    }

    // Update is called once per frame
    private void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
        foreach(Collider near in colliders){
            Rigidbody rig = near.GetComponent<Rigidbody>();
            if(rig!=null){
                rig.AddExplosionForce(explosionForce,transform.position,radius,1f,ForceMode.Impulse);
                Destroy(gameObject);
                
            }
        }
    }
}
