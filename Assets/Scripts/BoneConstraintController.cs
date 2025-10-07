using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneConstraintController : MonoBehaviour
{
    private Vector3 currentIKPos;
    // Start is called before the first frame update
    void Start()
    {
        currentIKPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = currentIKPos;
    }
}
