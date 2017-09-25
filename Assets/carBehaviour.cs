using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carBehaviour : MonoBehaviour {

    private Rigidbody rb;
    private float time;
    private float totalTime;
    private bool running;

    public float acc;
    public GameObject wall;
    public Material secondMat;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        running = false;
        totalTime = 2.5f;
        Debug.Log("Acceleration: " + calcAcceleration(27.4f, 2.5f) + "Km/h");
        Debug.Log("Displacement: " + calcDisplacement(27.4f, 2.5f) + "m");

        Instantiate(wall, new Vector3(-calcDisplacement(27.4f, 2.5f), 0, 0) + this.transform.position, wall.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            running = true;
        }
	}

    void FixedUpdate()
    {
        float vel = rb.velocity.sqrMagnitude;
        float initVel;
        float finalVel;
        float runningTime = time;
        

        if (running)
        {
            Vector3 acceleration = acc * -this.transform.right;
            rb.AddForce(acceleration, ForceMode.Acceleration);

            time += Time.fixedDeltaTime;
            //Debug.Log("Velocity: " + rb.velocity);
            //Debug.Log("Time Elapsed: " + time);

            running = time < totalTime;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "wall")
        {
            Debug.Log("Hello");
            this.GetComponent<MeshRenderer>().material = secondMat;
        }
    }

    float calcAcceleration(float velocity, float time)
     { 
        acc = (velocity - 0) / (time - 0); 
         
         return  acc; 
     } 
 
 
     float calcDisplacement(float vel,  float time)
     { 
         float disp; 
         float t = time; 
         float a = acc; 
         float vi = vel;

        disp = 0.5f * (0 + vi) * t;

         return disp; 
     } 

}
