using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject target;
    
    public AudioSource audiosource;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other) {
        if(other == target){
            audiosource.Play();
            
        }
    }
}
