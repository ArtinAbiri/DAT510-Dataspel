using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool isInvincible;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);


            anim.SetTrigger("hurt");
            Debug.Log(damage + " Damage taken");

            if (currentHealth <= 0)
            {
                anim.SetBool("die", true);
                if (gameObject.tag == "Player")
                {
                    Destroy(gameObject.GetComponent<Rigidbody2D>());
                    Invoke("PlayerDeath", 5f);
                }
                Die();
                

            }
        }
    }

    public void Invincible()
    {
        isInvincible = true;
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

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
