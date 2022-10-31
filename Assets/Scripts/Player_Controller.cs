using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    [SerializeField]
    float playerSpeed;
    Rigidbody2D playerRigidBody;
    float input_x;
    float input_y;
    public float health;
    float maxHealth = 10;
    public GameObject gameOverUI;
    [SerializeField]
    public Image healthUI;
    //DetectionPoint
    public Transform detectionPoint;
    //Detection radius
    private const float detectionRadius = 0.1f;
    //Detection layer
    public LayerMask detectionLayer;
    bool gameOver = false;
    public float money;
    public Text moneyText;
    public Text interactPrompt;
    public Image interactBackground;


    //ADD Player Stats




    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerSpeed = 10;
        health = maxHealth;
        money = 0;
        interactPrompt.gameObject.SetActive(false);
        interactBackground.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        interact();
        healthUI.fillAmount = health / maxHealth;
        moneyText.text = money.ToString();
    }


    void movement()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        playerRigidBody.velocity = new Vector2(input_x * playerSpeed, input_y * playerSpeed);
    }


    void interact()
    {
        if(DetectObject())
        {
            if (InteractInput())
            {
                eventCheck();
            }
            interactPrompt.gameObject.SetActive(true);
            interactBackground.gameObject.SetActive(true);
        }
        else if (interactPrompt.gameObject.activeInHierarchy && interactBackground.gameObject.activeInHierarchy)
        {
            interactPrompt.gameObject.SetActive(false);
            interactBackground.gameObject.SetActive(false);
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
    public void Heal(float amt)
    {
        health += amt;
        if (health > maxHealth) health = maxHealth;
    }

    public void Damage(float amt)
    {
        health -= amt;
        if (health <= 0)
        {
            //Die();
        }
    }
    void Die()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        gameOver = true;
    }

    void eventCheck()
    {
        if (detectEvent())
        {
            Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer).gameObject.GetComponentInParent<Event>().EventStart();
        }
    }

    public void AddMoney(float amnt)
    {
        money += amnt;
    }
}
