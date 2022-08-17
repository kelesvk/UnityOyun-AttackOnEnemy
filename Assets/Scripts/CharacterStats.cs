
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    //UI kısmı
    public Image[] hearts;
    Rigidbody2D rb;

//Stats
    public int health = 5 ;
    int maxHealth = 5;
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int amount)
    {
        hearts[health-1].enabled=false;
        health -= amount;

        rb.AddForce(Vector2.left*1500);
    }

    public void Regen(int amount)
    {
        health +=amount;
    
        for(int i=0; i < health; i++)
        {
            hearts[i].enabled=true;

        }

    }

    private void Update()
    {
        if(health>maxHealth){
            health=maxHealth;
        }
        }
        
    }

