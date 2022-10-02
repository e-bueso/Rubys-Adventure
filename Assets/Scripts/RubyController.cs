using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
       rigidbody2d = GetComponent<Rigidbody2D>();
       
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
       position.x = position.x + 3.0f * horizontal * Time.deltaTime;
       position.y = position.y + 3.0f * vertical * Time.deltaTime;
       
       rigidbody2d.MovePosition(position);
    }
}
