using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aicollide : MonoBehaviour
{
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
}
