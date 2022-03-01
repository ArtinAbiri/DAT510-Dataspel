using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        
        anim.SetTrigger("hurt");
        Debug.Log(damage + " Damage taken");
        
        if (currentHealth <= 0)
        {
            anim.SetBool("die",true);
            if (gameObject.tag == "Player")
            {
                Invoke("PlayerDeath", 5f);
            }
            else
            {
                Die();    
            }
            
        }
    }

    private void Die()
    {
        currentHealth = 0;
        Collider2D[] comps = GetComponents<Collider2D>();
        MonoBehaviour[] monos = GetComponents<MonoBehaviour>();
        foreach(Collider2D c in comps)
            c.enabled = false;
        foreach (MonoBehaviour m in monos)
            m.enabled = false;
    }

    private void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
