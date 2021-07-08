using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject followObject;

    void Update()
    {
        transform.position = followObject.transform.position + new Vector3(0, 3.68f, -5.76f);
    }
}
