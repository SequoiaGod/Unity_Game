using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
        public float verticalVelocity = 0;
        public float walkSpeed = 5f;
        public float rotationSpeed = 2f;
        public float fireRate = 0.5f;
        float y = 0f;
        public int hurt = 5;

        public Transform playerRefersh;
        private float nextFire = 0.0f;
        public GameObject shot;
        public Transform shotTransform;

        public HealthBar healthbar;
        public int health = 10;
        public static int currHealth; 



        public TextMeshProUGUI bloodText;

        public AudioSource music;
        public AudioClip shooting;

        public AudioSource Hurt;
        public AudioSource jump;
        public GameObject failGame;
        public static bool isDead = false;

    // Start is called before the first frame update

        public int getCurrHealth(){
                return currHealth;
        }
     void Start()
    {
        bool isDead = false;

        Cursor.lockState = CursorLockMode.Locked;
        currHealth = health;
        healthbar.healthSet(health);
        bloodText = GameObject.Find("BloodText").GetComponent<TextMeshProUGUI>();
        
        // this.transform.position = playerRefersh.position;
        
    }
   void Update() {
           if(isDead){

           }
           else{
                this.transform.position = playerRefersh.position;
        //    GameObject[] player =GameObject.FindGameObjectsWithTag("Player");
        //    Debug.Log(player[0].transform.position);

// rotate the player object about the Y axis 
// based on the mouse moving left and right 
        float rotation = Input.GetAxis("Mouse X"); 
        transform.Rotate(0, rotation*rotationSpeed, 0);
// rotate the camera (the player's "head") about its X axis 
// based on the mouse moving up and down 
        float updown = -Input.GetAxis("Mouse Y"); 
        // Debug.Log("Input: " + updown );

        if(y+updown>30f || y + updown<-20f){
                updown = 0;
        }

        Camera.main.transform.Rotate(updown*rotationSpeed, 0, 0);
        y+=updown;
// moving the player object forwards and backwards 
        float forwardSpeed = Input.GetAxis("Vertical");
// moving left to right 
        float lateralSpeed = Input.GetAxis("Horizontal");
// apply gravity – or rather figure out the resultant velocity 
        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        CharacterController characterController = GetComponent<CharacterController>();
        if (Input.GetButton("Jump") && characterController.isGrounded) 
        {
            verticalVelocity = 5;
            jump.Play();

    
            
        } 
        Vector3 speed = new Vector3(lateralSpeed*walkSpeed, verticalVelocity, forwardSpeed*walkSpeed);
// transform this absolute speed relative to the player's current rotation 
// i.e. we don't want them to move "north", but forwards depending on where 
// they are facing 
        speed = transform.rotation * speed;
// what is deltaTime? 
// move at a different speed to make up for variable framerates 
        characterController.Move(speed * Time.deltaTime);

        if(Input.GetButton("Fire1") && Time.time > nextFire){
                // music.clip = shooting;
                music.Play();
                
                
                nextFire = Time.time + fireRate;
                Instantiate(shot,shotTransform.position, Camera.main.transform.rotation);
        }

        bloodText.text = currHealth.ToString("0");


           }
           
}

        private void FixedUpdate() {
                if(this.transform.position.y<-1)
                {
                        if(PickUp.holding == true)
                        {
                                PickUp.fall = true;
                        }
                }
                if(this.transform.position.y<-30)
                {
                        
                        
                        currHealth -= hurt;
                        healthbar.changeHealth(currHealth);

                        
                        this.transform.position = playerRefersh.position;
                        Hurt.Play();

                        

                        Debug.Log("true");
                        if(currHealth <5 ){
                                currHealth=0;
                                isDead = true;

                        }
                }
        }


        private void Awake()
	{


        music =  GetComponent<AudioSource>();
        Hurt.playOnAwake = false;
        jump.playOnAwake = false;
        music.playOnAwake = false;

    }



}