using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats instance;

    public float health;
    float maxHealth = 10;
    public Image healthUI;

    public bool newgame;

    public float dexterity;
    float dextertyBase;
    public float strength;
    float strengthbase;
    public float luck;
    float luckbase;
    public float defense;
    float defensebase;

    Scene current;

    public enum stats{hth,dex,str,lck,def};


    public float money;
    public Text moneyText;

    public List<Item> inventory = new List<Item>();

    public float storypoint;


    private void Awake()
    {
        
        // If the instance reference has not been set, yet, 
        if (instance == null)
        {
            // Set this instance as the instance reference.
            instance = this;
        }
        else if (instance != this)
        {
            // If the instance reference has already been set, and this is not the
            // the instance reference, destroy this game object.
            Destroy(gameObject);
        }

        // Do not destroy this object, when we load a new scene.
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        setBase();
        moneyText.text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.fillAmount = health / maxHealth;
      
        current = SceneManager.GetActiveScene();
        if (current.name != "Overworld")
        {
            //this.gameObject.SetActive(false);
            
        }
        else
        {
            this.gameObject.SetActive(true);
          
        }
    }



    void setBase()
    {
        health = maxHealth;
        dexterity = dextertyBase;
        strength = strengthbase;
        luck = luckbase;
        defense = defensebase;
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
            SceneManager.LoadScene("Game Lose");
        }
    }
    public void AddMoney(float amnt)
    {
        money += amnt;
    }


    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    public void UseItem(Item item)
    {
        int count = inventory.Count;
        for (int i = 0; i < count; i++)
        {
            if (inventory[i].name == item.name)
            {
                inventory.RemoveAt(i);
                return;
            }
        }
    }

    public void changeStat(stats stat, float amnt) 
    {
        switch (stat)
        {
            case stats.hth:
                health += amnt;
                break;
            case stats.str:
                strength += amnt;
                break;
            case stats.dex:
                dexterity += amnt;
                break;
            case stats.lck:
                luck += amnt;
                break;
            case stats.def:
                defense += amnt;
                break;

        }
    }


    public void activate()
    {
        this.gameObject.SetActive(true);
    }

    public void deactivate()
    {
        this.gameObject.SetActive(false);
    }

    public void gameWin()
    {
        storypoint++;
        if (storypoint >= 5)
        {
            SceneManager.LoadScene("Game Win");
            Debug.Log("You win!");
            //Gameover
        }
    }
    
}
