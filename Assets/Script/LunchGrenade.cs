using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchGrenade : MonoBehaviour
{
    public Transform spwanPoint;
    public GameObject grenade;
    float range = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            Launch();
        }
    }
    private void Launch(){
        GameObject gremadeinstance = Instantiate(grenade,spwanPoint.position,spwanPoint.rotation);
        gremadeinstance.GetComponent<Rigidbody>().AddForce(spwanPoint.forward*range,ForceMode.Impulse);
    }
}
