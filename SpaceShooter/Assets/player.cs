using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float AttackDelaySec = 1f;
    public float AttackRemainSec = 0;
    public GameObject copyobj;
    public List<GameObject> cloneobjlist = new List<GameObject>();
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.x -= MoveSpeed * Time.deltaTime;
            if (pos.x < -5) pos.x = -5;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Vector3 pos = transform.position;
            pos.x += MoveSpeed * Time.deltaTime;
            if (pos.x > 5) pos.x = 5;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector3 pos = transform.position;
            pos.z += MoveSpeed * Time.deltaTime;
            if (pos.z > 15) pos.z = 15;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Vector3 pos = transform.position;
            pos.z -= MoveSpeed * Time.deltaTime;
            if (pos.z < -3) pos.z = -3;
            this.transform.position = pos;
        }
        AttackRemainSec -= Time.deltaTime;
        if (AttackRemainSec <= 0 && Input.GetKey(KeyCode.Space))
        {
            AttackRemainSec = AttackDelaySec;

            GameObject cloneobj = GameObject.Instantiate(copyobj);
            cloneobj.transform.position = transform.position;
            cloneobj.SetActive(true);

            bullet clonebullet = cloneobj.GetComponent<bullet>();
            clonebullet.shootspeed = 10f;

            cloneobjlist.Add(cloneobj);
        }
    }
}
