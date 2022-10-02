using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log("FrameRate: " + (1.0f / Time.deltaTime));
       // QualitySettings.vSyncCount = 0;
       // Application.targetFrameRate = 24;        
    }

    // Update is called once per frame
    void Update()
    {

       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");
       // Debug.Log(horizontal);

       // deltaTime, contained inside Time, is a variable that Unity fills with the time it takes for a frame to be rendered
       Vector2 position = transform.position;
       position.x = position.x + 3.0f * horizontal * Time.deltaTime;
       position.y = position.y + 3.0f * vertical * Time.deltaTime;
       transform.position = position;

    }
}
