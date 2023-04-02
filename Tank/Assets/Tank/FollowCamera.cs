using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Target = null;
    public Vector3 Offeset = Vector3.zero;
    public float m_Lerp = 0.2f;

    void Start()
    {
        Offeset = Target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temppos = Vector3.Lerp(transform.position, Target.position + Offeset, m_Lerp);
        transform.position = temppos;
    }
}
