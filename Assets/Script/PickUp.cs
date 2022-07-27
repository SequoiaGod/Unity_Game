using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdPisiton;
    private GameObject holdItem;
    private Rigidbody rjb;
    private float range = 3.0f;
    private float force = 150.0f;
    public static bool holding = false;

    public static bool fall = false;
    public AudioSource pickBox;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.E))//(Input.GetMouseButtonDown(0)) //
        {
            if(holdItem == null){
                RaycastHit hit;
                if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit,range)){
                    pickBox.Play();
                    PickedItem(hit.transform.gameObject);
                    holding = true;
                }
            }
            else{
                holding = false;
                pickBox.Play();
                dropItem();

            //throw


            }
        }

        if(holdItem!=null)
        {
            moveItem();
        }

        if(newEnemy.robBox == true){
            pickBox.Play();
            dropItem();
            newEnemy.robBox = false;
            holding = false;
            // newEnemy.boxGrounded = false; 
        }

        if(fall==true)
        {
            pickBox.Play();
            dropItem();
            fall=false;
            holding = false;
        }
        
    }

    public void PickedItem(GameObject pick)
    {
        
        if(pick.GetComponent<Rigidbody>())
        {
            rjb = pick.GetComponent<Rigidbody>();
            rjb.useGravity = false;
            rjb.drag = 10;
            rjb.constraints = RigidbodyConstraints.FreezeRotation;
            rjb.transform.parent = holdPisiton;
            holdItem = pick; 

        }
    }

    public void dropItem()
    {
        
        rjb.useGravity = true;
        rjb.drag = 1;
        rjb.constraints = RigidbodyConstraints.None;
        holdItem.transform.parent= null;

        holdItem = null; 
    }

    void moveItem()
    {
        if(Vector3.Distance(holdItem.transform.position,holdPisiton.position)>0.1f)

        {
            Vector3 movePosition = (holdPisiton.position - holdItem.transform.position);
            rjb.AddForce(movePosition*force);
        }
    }

    private void Awake() {
        // pickBox.playOnAwake = false;
    }
}
