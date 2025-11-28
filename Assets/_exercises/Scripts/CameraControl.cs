using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        if (target)
        {
            Vector3 newCamPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            gameObject.transform.position = newCamPosition;
        }

    }
}
