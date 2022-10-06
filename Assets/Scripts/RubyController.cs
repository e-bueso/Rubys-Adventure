using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;

    public float speed = 3.0f;

    public int maxHealth = 5;
    int currentHealth;
    public int health { get { return currentHealth; }}

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    public GameObject projectilePrefab;


    
    // Start is called before the first frame update
    void Start()
    {
       rigidbody2d = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();

       currentHealth = maxHealth;
       
       Debug.Log("FrameRate: " + (1.0f / Time.deltaTime));
       // QualitySettings.vSyncCount = 0;
       // Application.targetFrameRate = 24;        
    }

    // Update is called once per frame
    void Update()
    {

       horizontal = Input.GetAxis("Horizontal");
       vertical = Input.GetAxis("Vertical");
       // Debug.Log(horizontal);


        // Instead of doing x and y independently for the movement, you store the input amount in a Vector2
        Vector2 move = new Vector2(horizontal, vertical);
                
        // Use Mathf.Approximately instead of == because the way computers store float numbers means there is a tiny loss in precision
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            // If either x or y isn’t equal to 0, then Ruby is moving, set your look direction to your Move Vector 
            // and Ruby should look in the direction that she is moving
            lookDirection.Set(move.x, move.y);
            // Note you could have done lookDirection = move but that shows another way of assigning x and y of a vector
            lookDirection.Normalize();
        }
                
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

    }
    void FixedUpdate() {
       Vector2 position = rigidbody2d.position;
 
        // deltaTime, contained inside Time, is a variable that Unity fills with the time it takes for a frame to be rendered
       position.x = position.x + speed * horizontal * Time.deltaTime;
       position.y = position.y + speed * vertical * Time.deltaTime;
       
       rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
            animator.SetTrigger("Hit");
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    void Launch()
    {
        // Instantiate takes an object as the first parameter and creates a copy at the position in the second parameter, 
        // with the rotation in the third parameter. Quaternion.identity means "no rotation".
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }


}
