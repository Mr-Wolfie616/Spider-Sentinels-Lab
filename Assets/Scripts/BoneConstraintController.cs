using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneConstraintController : MonoBehaviour
{
    private Vector3 currentIKPos;
    private float currentStepDistance;
    public float maxStepDistance = 3f;
    public GameObject legAimPosition;
    public BoneConstraintController OppositeLeg;
    public bool LegIsMoving;

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

    public bool CheckIsLegMoving()
    {
        return LegIsMoving;
    }

    private void SetIKPosition()
    {
        currentStepDistance = Vector3.Distance(currentIKPos, legAimPosition.transform.position);

        bool canStep = currentStepDistance > maxStepDistance && (OppositeLeg == null || !OppositeLeg.CheckIsLegMoving());

        if (canStep)
        {
            LegIsMoving = true;

            transform.position = legAimPosition.transform.position;
            currentIKPos = transform.position;

            LegIsMoving = false;
        }
        else
        {
            LegIsMoving = false;
            transform.position = currentIKPos;
        }
    }
}
