using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading;

public class explosion : MonoBehaviour
{
	public Camera death_cam;
	public float cubeSize = 0.2f;
	public int cubesInRow = 5;
	public int explosionForce;
	public int explosionRadius;
	public float explosionUpward;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
    	if(other.gameObject.tag == "wall")
    	{
    		explode();
    	}
    }

    public void explode()
    {
    	AudioSource motor_sound = GetComponent<AudioSource>();
    	motor_sound.Stop();

    	gameObject.SetActive(false);

        death_cam.enabled = true;

        SceneManager.LoadScene("death");

    }

    void createPiece(int x, int y, int z)
    {
    	GameObject piece;
    	piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

    	piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z);
    	piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

    	piece.AddComponent<Rigidbody>();
    	piece.GetComponent<Rigidbody>().mass = 0.1f;
    	piece.GetComponent<Rigidbody>().useGravity = false;


    }
}
