    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    float playerSpeed;
    Rigidbody2D playerRigidBody;
    float input_x;
    float input_y;

    public GameObject gameOverUI;
    [SerializeField]

    //DetectionPoint
    public Transform detectionPoint;
    //Detection radius
    private const float detectionRadius = 0.1f;
    //Detection layer
    public LayerMask detectionLayer;
    bool gameOver = false;
    
    public Text interactPrompt;
    public Image interactBackground;

    public GameObject invUI;


    bool invOpen;
    bool menuOpen;
    bool active;
    //ADD Player Stats


    Scene current;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerSpeed = 10;
        invOpen = false;
        menuOpen = false;

        interactPrompt.gameObject.SetActive(false);
        interactBackground.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        current = SceneManager.GetActiveScene();
        if(current.name == "Overworld" && active == false)
        {
            gameObject.SetActive(true);
        }
        movement();
        interact();
    }


    void movement()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        playerRigidBody.velocity = new Vector2(input_x * playerSpeed, input_y * playerSpeed);
        if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab)) && menuOpen != true)
        {
            invUI.SetActive(true);
            invOpen = true;
        }
        else if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab)) && menuOpen == true)
        {
            invUI.SetActive(false);
            invOpen = false;
        }
    }


    void interact()
    {
        if(DetectObject())
        {
            if (InteractInput())
            {
                eventCheck();
            }

        }
        else if (interactPrompt.gameObject.activeInHierarchy && interactBackground.gameObject.activeInHierarchy)
        {
            interactPrompt.gameObject.SetActive(true);
            interactBackground.gameObject.SetActive(true);
        }
    }
    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E); // Detecting the button.
    }

    bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer); //Checks whether we're interesecting
                                                                                                  //with an object.
    }

    bool detectEvent()
    {
        //Checks whether we're interesecting
        //with an object.
        if (Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer).CompareTag("Event"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    void eventCheck()
    {
        if (detectEvent())
        {
            Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer).gameObject.GetComponentInParent<Event>().EventStart();
        }
    }



    void stopPlay()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        gameOver = true;
    }
}
