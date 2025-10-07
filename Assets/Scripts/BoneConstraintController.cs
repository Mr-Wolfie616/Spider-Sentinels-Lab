using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneConstraintController : MonoBehaviour
{
    private Vector3 currentIKPos;
    private float currentStepDistance;

    public float maxStepDistance = 2f;
    public GameObject legAimPosition;
    // Start is called before the first frame update
    void Start()
    {
        currentIKPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        SetIKPosition();
    }

    private void SetIKPosition()
    {
        currentStepDistance = Vector3.Distance(currentIKPos, legAimPosition.transform.position);

        if (currentStepDistance > maxStepDistance)
        {
            currentIKPos = legAimPosition.transform.position;
        }
        else
        {
            transform.position = currentIKPos;
        }
    }
}
