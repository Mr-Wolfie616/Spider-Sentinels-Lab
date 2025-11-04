using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SmoothStepRND : MonoBehaviour
{
    public Transform StartPos;
    public Transform EndPos;
    public float Speed =  3f;
    private float stepDuration;
    public AnimationCurve stepCurve;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        stepDuration = Vector3.Distance(StartPos.position, EndPos.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * Speed;

        float fractionOfJourney = distCovered / stepDuration;

        Vector3 flat = Vector3.Lerp(StartPos.position, EndPos.position, fractionOfJourney);

        float Yoffset = stepCurve.Evaluate(fractionOfJourney);
        transform.position = flat + Vector3.up * Yoffset;

    }
}
