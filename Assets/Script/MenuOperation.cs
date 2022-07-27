using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOperation : MonoBehaviour
{

    Button quit;

    void Update() {
        Cursor.visible = true;
        Cursor.lockState = 0;
    }

    private void Awake() {
        quit = transform.GetChild(3).GetComponent<Button>();
        quit.onClick.AddListener(quitGame);
    }

    void quitGame(){
        Application.Quit();
        Debug.Log("Quit game");
    }
}
