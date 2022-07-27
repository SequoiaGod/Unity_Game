using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;
public class BackgroundMusic : MonoBehaviour
{

    public static BackgroundMusic PersistMusic;
    

    private void Awake() {
        if(PersistMusic !=null && PersistMusic != this)
        {
            Destroy(this.gameObject);
            return;
        }
        PersistMusic = this;
        int index = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(index);
        DontDestroyOnLoad(this);
        
    }
}
