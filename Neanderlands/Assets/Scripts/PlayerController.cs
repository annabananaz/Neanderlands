using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Slider healthBar;

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

    private int health;
    private bool inLava;

    public GameController gc;
    
    
    
    
    
    //public AudioSource source;
    //public AudioClip clip1;

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

        health = 100;
        healthBar.value = 100;
        inLava = false;

        //Play background music
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

        healthBar.value = health;
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
            if (pickaxe.activeSelf)
            {
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
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            inLava = true;

            while (inLava)
            {
                while (gc.gamePaused()) { }
                health -= 1;
                Debug.Log(health);
                yield return new WaitForSeconds(0.1f);

                if (health <= 0)
                {
                    yield break;
                }
            }

        }
    }

    IEnumerator OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            inLava = false;

            while (!inLava)
            {
                while (gc.gamePaused()) { }
                yield return new WaitForSeconds(0.5f);
                health += 1;
                Debug.Log(health);

                if (health >= 100)
                {
                    yield break;
                }
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.transform.tag == "Lava")
    //    {
    //        print("Lava Trigger Enter");
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.transform.tag == "Lava")
    //    {
    //        print("Lava Trigger Exit");
    //    }
    //}
    //Function to Break Rocks

    private void Breaker(GameObject gameObject)
    {
        if (gameObject.tag == "breakableRock")
        {
            Destroy(gameObject);
        }
    }

    void LookAroundRoll()
    {
        currentRollAngle = Mathf.Lerp(currentRollAngle, Input.GetAxisRaw("Mouse X")
                            * rollAngle, Time.deltaTime * rollSpeed);
    }
}

