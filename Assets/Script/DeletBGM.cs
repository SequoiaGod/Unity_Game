using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("BackgroundMusic"));
        // GameObject[] bgm = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        // if(bgm!=null)
        // {
        //     DestroyObject(bgm[0]);

        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
