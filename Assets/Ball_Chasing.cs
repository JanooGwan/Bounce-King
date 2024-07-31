using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Chasing : MonoBehaviour
{
    public GameObject Target;               // 카메라가 따라다닐 타겟

    public float CameraSpeed;       // 카메라의 속도
    public float offsetY;
    float TargetPos;         // 타켓(공)의 Y좌표
    float CameraPos; // 카메라의 Y좌표

    int y;
    void Start()
    {
        TargetPos = Target.transform.position.y;
        transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        TargetPos = Target.transform.position.y;

        if(TargetPos-transform.position.y>1 && TargetPos>0)
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, TargetPos, -10), Time.deltaTime * CameraSpeed);
        
    }
}