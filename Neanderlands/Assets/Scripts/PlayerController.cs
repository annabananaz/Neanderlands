using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject pickaxe, torch;

    public float moveSpeed;
    public float jumpForce;
    public float cameraSpeed;
    public float jumpRate;
    public float maxPitch;
    public float minPitch;


    private Vector3 jump;
    private float nextJump = 0.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Rigidbody rb;
    //roll
    [SerializeField]
    private float rollAngle = 10f;

    [SerializeField]
    private float rollSpeed = 3f;

    private float currentRollAngle = 0f;

    //public AudioSource source;
    //public AudioClip clip1;

    // Pause menu
    //public GameObject crossHair;

    public GameController gc;

    //Creating the Toolbox System
    // 1 = Hands
    // 2 = PickAxe
    // 3 = Torch


    // Use this for initialization
    void Start()
    {
        gc = GameObject.FindObjectOfType<GameController>();

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        //AudioSource[] audioSources = GetComponents<AudioSource>();
        //source = audioSources[0];
        //clip1 = audioSources[0].clip;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * v * moveSpeed * Time.deltaTime;
        Vector3 sidestep = transform.right * h * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement + sidestep);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextJump)
        {
            nextJump = Time.time + jumpRate;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        yaw += cameraSpeed * Input.GetAxis("Mouse X");
        pitch -= cameraSpeed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        LookAroundRoll();

        transform.eulerAngles = new Vector3(pitch, yaw, currentRollAngle);
        
        //pause game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gc.PauseGame();
            
        }

        //Checks multiple conditions, if true, the rocks break with a left click
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (pickaxe.activeSelf) { 
                //print("PickAxe is true");
                RaycastHit hit;
                Ray thing = new Ray(transform.position, Vector3.forward);
                Debug.DrawRay(transform.position, Vector3.forward * 8.0f, Color.red);
                if (Physics.Raycast(thing, out hit, 8.0f))
                {
                        print("This is tag " + hit.transform.gameObject.tag);
                        Breaker(hit.transform.gameObject);
                }
                        
            }
        }


        //if(Input.GetButton("Fire1") && Time.time > nextFire)
        //{
        //    nextFire = Time.time + fireRate;
        //    Instantiate(shot, shotSpawnPos.position, shotSpawnPos.rotation);
        //    //play audio
        //    source.PlayOneShot(clip1);
        //}

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    gc.PauseMusic();
        //    GetComponent<PlayerController>().enabled = false;
        //    crossHair.SetActive(false);
        //    pauseMenuCanvas.SetActive(true);
        //    Cursor.visible = true;
        //    Time.timeScale = 0;
        //}
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Lava")
        {
            print("Lava Trigger Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Lava")
        {
            print("Lava Trigger Exit");
        }
    }
    //Function to Break Rocks

    private void Breaker(GameObject gameObject)
      {   
        if (gameObject.tag == "breakableRock")
        {
                Destroy(gameObject);
        }
      }

    void LookAroundRoll() {
        currentRollAngle = Mathf.Lerp(currentRollAngle, Input.GetAxisRaw("Mouse X")
                            * rollAngle, Time.deltaTime * rollSpeed); 
    } 
}
