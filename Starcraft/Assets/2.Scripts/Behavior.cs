using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    private Rigidbody rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public bool Run(Vector3 MoveTargetPos, float Speed)
    {
        float Dis = Vector3.Distance(transform.position, MoveTargetPos);
        if (Dis >= 0.26f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.position, MoveTargetPos, Speed * Time.deltaTime);

            return true;
        }
        return false;
    }

    public void Turn(Vector3 MoveTargetPos)
    {
        Vector3 Dir = MoveTargetPos - transform.position;
        Vector3 DirXZ = new Vector3(Dir.x, 0f, Dir.z);
        Quaternion TargetRot = Quaternion.LookRotation(DirXZ);
        rigid.rotation = Quaternion.RotateTowards(transform.rotation, TargetRot, 3000.0f * Time.deltaTime);
    }
}
