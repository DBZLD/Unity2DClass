using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GameObject.Destroy(this.gameObject);

        if(other.gameObject.tag != "Unbreaked")
        {
            GameObject.Destroy(other.gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
