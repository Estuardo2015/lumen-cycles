using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading;

public class drive : MonoBehaviour
{
    public float speed = 10.0F;
    public float rotationSpeed = 150.0F;
    public GameObject lightwall;
    public Camera camera;
    BoxCollider wall;
    Vector3 lastWallEnd;

    public float EPSILON { get; private set; }

    // Update is called once per frame
    void Start()
    {
        Lightwall();
    }

    void Update()
    {
        camera.enabled = false;
        float translation = speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        fitColliderBetween(wall, lastWallEnd, transform.position);
        Lightwall();
    }

    void OnCollisionEnter(UnityEngine.Collision other)
    {
            if(other.collider.tag == "collide_trail")
            {
                //Destroy (gameObject);
                explode();
                //camera.enabled = true;
            }
    }

    public void explode()
    {
        AudioSource motor_sound = GetComponent<AudioSource>();
        motor_sound.Stop();

        gameObject.SetActive(false);

        camera.enabled = true;

        SceneManager.LoadScene("death");

    }

    void Lightwall() 
    {
        GameObject g = (GameObject)Instantiate(lightwall, transform.position, Quaternion.identity);
        wall = g.GetComponent<BoxCollider>();
        lastWallEnd = g.transform.position;
    }

    void fitColliderBetween(BoxCollider co, Vector3 a, Vector3 b) 
    {
        co.transform.position = a + (b - a) * 0.10f;

        float dist = Vector3.Distance(a,b);
        if (a.x != b.x) 
        {
            co.transform.localScale = new Vector3(dist, 1, 1); 
        }
        else 
        {
            co.transform.localScale = new Vector3(1, 1, dist);
        }
    }

}