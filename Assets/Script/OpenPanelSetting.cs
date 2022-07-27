using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelSetting : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {

        if (Panel != null){
            Panel.SetActive(true);
        }

        bool panelTrue = Panel.activeSelf;
        
    } 
    // Start is called before the first frame update

}
