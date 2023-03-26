using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public static int Score = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "player")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(other.gameObject);

            bullet.Score++;
            Debug.Log($"score : {bullet.Score}");
        }
    }
    void Start()
    {
        
    }

    public float shootspeed = 1f;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.z += shootspeed * Time.deltaTime;
        transform.position = pos;

        if (this.transform.position.z >= 15f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
