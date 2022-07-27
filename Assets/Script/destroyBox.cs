using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBox : MonoBehaviour
{
    public static int boxNum = 1;
    public AudioSource win;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(gameObject.transform.position.x);
        if(gameObject.transform.position.x >12 && gameObject.transform.position.y<0.6 && gameObject.transform.position.y>0f)
        {
            transform.localPosition = new Vector3(-74,1,-10);
            win.Play();
            TargetGameController.boxres +=1;
            // boxNum +=1;
            // newEnemy.boxGrounded = false;
            // DestroyObject(gameObject);
        }

        if(gameObject.transform.position.y <-2)
        {
             transform.localPosition = new Vector3(-74,1,-10);
        }
    }
}
