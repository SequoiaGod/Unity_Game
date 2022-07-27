using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRacast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private MyDoorController raycastedObj;
    [SerializeField] private KeyCode openDoorKey = KeyCode.E;
    private bool isCrosshairActive;
    private bool doOnce =false;
    private const string interactableTag = "InteractiveObject";
    private void update(){

        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask= 1<< LayerMask.NameToLayer(excludeLayerName)| layerMaskInteract.value;
        if(Physics.Raycast(transform.position,fwd,out hit,rayLength,mask))
        {
            Debug.Log("111");
            if(hit.collider.CompareTag(interactableTag))
            {
                if(!doOnce){
                    raycastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();
                    Debug.Log("111111");
                }

                doOnce = true;
                if(Input.GetKeyDown(openDoorKey))
                {
                    raycastedObj.PlayAnimation();
                }


            }            
        }

        else
        {
            // doOnce = false;
        }

    }
}
