using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    [Header("Bools")]
    public bool rotateX;
    public bool rotateY;
    public bool rotateZ;

    [Header("Floats")]
    public float rotX = 1f;
    public float rotY = 1f;
    public float rotZ = 1f;

    private Vector3 v3 = new Vector3(0, 0, 0);

    private void Awake()
    {
        this.transform.eulerAngles = v3;
    }

    // Update is called once per frame
    void Update () {
        if (rotateX)
            v3.x += rotX;

        if (rotateY)
            v3.y += rotY;

        if (rotateZ)
            v3.z += rotZ;

        this.transform.eulerAngles = v3;
    }
}
