using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag=="Enemy")
        {
            collision.GetComponent<SimpleEnemyBehaviour>().TakeDamage(damage);
        }
    }

}
