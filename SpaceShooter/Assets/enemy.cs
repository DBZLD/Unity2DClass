using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "player")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(other.gameObject);

            Debug.Log("게임오버");
        }
    }
    void Start()
    {
        
    }

    public float movespeed = 1f;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.z -= movespeed * Time.deltaTime;
        transform.position = pos;

        if (this.transform.position.z <= -4f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
