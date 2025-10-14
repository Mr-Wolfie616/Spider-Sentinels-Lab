using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LegGrounding : MonoBehaviour
{
    private int layerMask;
    public Vector3 GroundOffset = new Vector3(0f, 0.75f, 0f);

    public GameObject RaycastOrigin;

    // Start is called before the first frame update
    void Start()
    {
        // Only hit Ground Layer
        layerMask = LayerMask.GetMask("Ground");

        if (RaycastOrigin == null && transform.parent != null)
        {
            RaycastOrigin = transform.parent.gameObject;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 origin = (RaycastOrigin != null ? RaycastOrigin.transform.position : transform.position);
        if (Physics.Raycast(origin + GroundOffset, -transform.up, out hit, Mathf.Infinity, layerMask))
        {
            transform.position = hit.point + GroundOffset;
        }
    }
}