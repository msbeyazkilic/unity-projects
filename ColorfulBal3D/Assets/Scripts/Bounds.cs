using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{

    public Transform vectorBack;
    public Transform vectorForward;
    public Transform vectorLeft;
    public Transform vectorRight;

    public void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.z = Mathf.Clamp(viewPosition.z, vectorBack.transform.position.z, vectorForward.transform.position.z);
        viewPosition.x = Mathf.Clamp(viewPosition.x, vectorLeft.transform.position.x, vectorRight.transform.position.x);
        transform.position = viewPosition;
    }
}
