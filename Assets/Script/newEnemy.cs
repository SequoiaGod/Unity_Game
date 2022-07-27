using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.AI;
public class newEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshAgent agent;
    public GameObject target;
    public static bool robBox = false;
    public static bool boxGrounded = false;
    public Transform holdPisiton;
    private GameObject holdItem;
    private Rigidbody rjb;
    private float range = 5.0f;
    private float force = 150.0f;
    public float damageRate = 1.0f;
    private float nextDamage = 0.0f;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        //  agent.destination = target.transform.position;
        //  agent.destination = ply[0].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(boxGrounded);
        GameObject[] boxObj = GameObject.FindGameObjectsWithTag("box");
        if(boxObj!=null){
            if(boxObj[0].transform.position.y<=0.55f)
        {
            boxGrounded = false;

        }
        }

        GameObject[] ply = GameObject.FindGameObjectsWithTag("Player");
        agent.destination = ply[0].transform.position;
        // Debug.Log(Mathf.Abs(agent.transform.position.x -target.transform.position.x));
        if( Mathf.Abs(agent.transform.position.x -target.transform.position.x)<0.8f && Mathf.Abs(agent.transform.position.z -target.transform.position.z) <0.8f)
        {
            
            // if(Time.time>nextDamage)
            // {
            //     PlayerController.currHealth -=5;
            //     nextDamage = Time.time + damageRate;

            // }
            
            
            if(boxObj != null && boxObj[0].transform.position.y>1.0f)
            {
                
                if(PickUp.holding){
                    if(!boxGrounded){
                        Debug.Log("yyy");
                        robBox = true;
                        
                        boxGrounded = true;
                }
                }

                
                

                // Debug.Log(boxObj[0].transform.position);
            }
        }


        // if(robBox){
        //     robIng();
        // }
        // if( !robBox)
        // {
        //     dropBox();

        // }
    }



    // void robIng()
    // {
    //         rjb = pick.GetComponent<Rigidbody>();
    //         rjb.useGravity = false;
    //         rjb.drag = 10;
    //         rjb.constraints = RigidbodyConstraints.FreezeRotation;
    //         rjb.transform.parent = holdPisiton;
    //         holdItem = pick; 
    // }


    // private void OnCollisionEnter(Collision other) {
    //      GameObject[] boxObj = GameObject.FindGameObjectsWithTag("box");
    //     if(boxObj != null && boxObj[0].transform.position.y>1.0f)
    //     {
    //         if(!boxGrounded){
    //                 robBox = true;
                    
    //                 boxGrounded = true;
    //             }

    //     }
        
    // }



    
}
