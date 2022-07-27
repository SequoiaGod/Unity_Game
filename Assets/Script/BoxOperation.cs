using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOperation : MonoBehaviour
{
    public Transform holdDes;

    // Start is called before the first frame update

    private void OnMouseDown() {
        
        if(GetComponent<SphereCollider>()==true)
        {
            Debug.Log("true");
            GetComponent<Rigidbody>().useGravity = false;
             this.transform.position = holdDes.position;
        this.transform.parent = GameObject.Find("fireGrenade").transform;
        }
       

    }

    private void OnMouseUp() {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;

    }
    
}
