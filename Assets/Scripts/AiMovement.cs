using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class AiMovement : MonoBehaviour
{
    public float speed = 5.0F;
    public float rotationSpeed = 150.0F;
    public GameObject lightwall;

    BoxCollider wall;
    Vector3 lastWallEnd;
   
    // Start is called before the first frame update
    void Start()
    {
        Lightwall();
    }
 
    void OncollisionEnter(UnityEngine.Collision col)
    {
        if(col.collider.tag == "Player" &&
            col.collider.tag == "collide_trail" &&
            col.collider.tag == "wall")
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                transform.eulerAngles.y,
                transform.eulerAngles.z + 5);
            gameObject.SetActive(false);
        }
    }
 
   
    // Update is called once per frame
    void Update()
    {
        float translation = speed;
        float rotation = rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        fitColliderBetween(wall, lastWallEnd, transform.position);
        
        Lightwall();
       
       
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