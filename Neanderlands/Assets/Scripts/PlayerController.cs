using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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

    //public AudioSource source;
    //public AudioClip clip1;

    // Pause menu
    //public GameObject pauseMenuCanvas;
    //public GameObject crossHair;

    public GameController gc;

    // Use this for initialization
    void Start()
    {
        gc = GameObject.FindObjectOfType<GameController>();

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        //AudioSource[] audioSources = GetComponents<AudioSource>();
        //source = audioSources[0];
        //clip1 = audioSources[0].clip;

        Time.timeScale = 1f;            // Starts game at timescale 1 for active
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

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        //if(Input.GetButton("Fire1") && Time.time > nextFire)
        //{
        //    nextFire = Time.time + fireRate;
        //    Instantiate(shot, shotSpawnPos.position, shotSpawnPos.rotation);
        //    //play audio
        //    source.PlayOneShot(clip1);
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gc.PauseGame();
            GetComponent<PlayerController>().enabled = false;
            //gc.PauseMusic();
            //crossHair.SetActive(false);
            //pauseMenuCanvas.SetActive(true);
            //Cursor.visible = true;
            //Time.timeScale = 0;
        }
    }
}
