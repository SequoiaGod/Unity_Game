using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelSetting : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Panel;

    public void ClosePanel()
    {

        if (Panel != null){
            Panel.SetActive(false);
        }

        bool panelTrue = Panel.activeSelf;
        
    } 
}
