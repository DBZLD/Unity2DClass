using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Control : MonoBehaviour
{
    private Behavior behavior;
    private Camera MainCamera;
    private Vector3 MoveTargetPos;
    private GameObject UnitMarker;
    private float Speed = 2.0f;
    private NavMeshAgent navmeshagent;

    void Start()
    {
        behavior = GetComponent<Behavior>();
        MainCamera = Camera.main;
        UnitMarker = GameObject.Find("Marker").GetComponent<GameObject>();
        
    }

    public void SelectUnit()
    {
        UnitMarker.SetActive(true);
    }

    public void DeselectUnit()
    {
        UnitMarker.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                MoveTargetPos = hit.point;
            }
        }

        if(behavior.Run(MoveTargetPos, Speed))
        {
            behavior.Turn(MoveTargetPos);
        }
    }
}
