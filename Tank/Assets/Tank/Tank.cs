using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public Rigidbody Bullet = null;
    public Transform BulletPos = null;
    public float BulletPow = 500f;

    void MoveTank()
    {
        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");

        transform.Translate(xx * MoveSpeed * Time.deltaTime
                , 0f, zz * MoveSpeed * Time.deltaTime);

        float rot = Input.GetAxis("ROTADD");
        transform.Rotate(0f, rot, 0f);
    }

    void ShootBullet()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody copyoobj = GameObject.Instantiate(Bullet, BulletPos.position, BulletPos.rotation);
            copyoobj.gameObject.SetActive(true);
            copyoobj.AddForce(BulletPos.forward * BulletPow);
        }
    }

    private void Awake()
    {
        Bullet.gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        MoveTank();

        ShootBullet();
    }
}
