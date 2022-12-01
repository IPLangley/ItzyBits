using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Button startButton;
    public Button quitButton;
    [SerializeField]
    public static bool newGame;
    public GameObject menu;
    // Start is called before the first frame update
    float msgCool = 10;
    float msgTimer;
    public static GameController instance;
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        Screen.SetResolution(1920, 1080,true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
        }


    }


    public void startGame()
    {
 
        newGame = false;
        SceneManager.LoadScene("Overworld");
        player.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void deactivate()
    {
        menu.SetActive(false);
    }

    public void gameOver()
    {
        SceneManager.LoadScene("Game Lose");
    }

    public void gameWin()
    {
        SceneManager.LoadScene("Game Win");
    }
}
