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

    // Start is called before the first frame update
    void Start()
    {
       rigidbody2d = GetComponent<Rigidbody2D>();

       currentHealth = maxHealth;
       currentHealth = 1;
       
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
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

}
