using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Animator doorAnim;
    // Start is called before the first frame update

    void Start()
    {
        doorAnim = this.transform.parent.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        //  if(Input.GetKeyDown(KeyCode.E)){

             
        //  }
        doorAnim.SetBool("isOpen", true);
    }

    private void OnTriggerExit(Collider other) {
         doorAnim.SetBool("isOpen", false);
    }
}
