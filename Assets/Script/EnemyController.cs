using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    public Waypoint waypoint;
    public GameObject target;
    public bool seenTarget = false;
    public Vector3 lastSeenPosition;

    float sightFov = 110.0f;

    

    // public Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = agent.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // agent.destination = destination.position;

        if(!agent.pathPending && agent.remainingDistance <0.5f){
            Waypoint nextWaypoint = waypoint.nextWaypoint;
            waypoint = nextWaypoint;
            agent.destination = waypoint.transform.position;

        }
    }


     private void OnTriggerStay(Collider other)
    {
        

        // is it the player?
        if(other.gameObject == target)
        {
            
            // angle between us and the player
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            // reset whether we’ve seen the player
            seenTarget = false;
            RaycastHit hit;
            // is it less than our field of view
            if (angle < sightFov * 0.5)
            {
                
                // if the raycast hits the player we know
                // there is nothing in the way
                // adding transform.up raises up from the floor by 1 unit
                if (Physics.Raycast(transform.position + transform.up,
                direction.normalized,
                out hit,
                GetComponent<SphereCollider>().radius))
                    {
                        
                    if (hit.collider.gameObject == target)
                    {
                        Debug.Log(hit.collider.gameObject);
                        // flag that we've seen the player
                        // remember their position
                        seenTarget = true;
                        lastSeenPosition = target.transform.position;
                        
                        
                        
                        
                    
                    }
                }
            }
    }
    }


}
