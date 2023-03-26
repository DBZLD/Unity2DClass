using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycreate : MonoBehaviour
{

    public GameObject copyobj = null;
    public List<GameObject> cloneobjlist = new List<GameObject>();
    public float CreateDelaySec = 2;
    public float CreateRemainSec = 0;

    void Start()
    {
        
    }

    void Update()
    {
        CreateRemainSec -= Time.deltaTime;

        if (CreateRemainSec <= 0)
        {
            CreateRemainSec = CreateDelaySec;

            GameObject cloneobj = GameObject.Instantiate(copyobj);
            
            float randposx = UnityEngine.Random.Range(-5f, 5f);
            cloneobj.transform.position = new Vector3(randposx, 0, 15f);
            cloneobj.SetActive(true);  
            
            enemy cloneenemy = cloneobj.GetComponent<enemy>();
            cloneenemy.movespeed = 2f;

            cloneobjlist.Add(cloneobj);
        }
    }
}
