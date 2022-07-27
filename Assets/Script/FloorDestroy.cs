using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public int timeBonus = 10;
    private int enemyHealth = 4;
    TargetGameController gameController;
    private Animator dogBehavior;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null){
            gameController = gameControllerObject.GetComponent<TargetGameController>();

        }
        if(gameControllerObject == null){
            Debug.Log("could not find object");

        }

        // dogBehavior = transform.GetComponent<Animator>();
        // Debug.Log(dogBehavior);
        // dogBehavior.SetBool("isAttack", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {

    // destroy this object 
        // dogBehavior.SetBool("isAttack", true);
        // enemyHealth --;
        // if(enemyHealth <=0){
            
        // }
        DestroyObject(gameObject);
    }


    private void OnTriggerExit(Collider collision) {
        //  dogBehavior.SetBool("isAttack", false);
    }

    private void OnDestroy() {

        // tell the game controller 
        if (gameController != null) {


            gameController.TargetDestroyed();
    }

}
}
