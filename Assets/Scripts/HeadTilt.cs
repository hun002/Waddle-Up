using UnityEngine;

public class HeadTilt : MonoBehaviour
{
    public Transform bodyTransform;

    void Update()
    {
        if (bodyTransform != null)
        {
            float bodyZ = bodyTransform.localEulerAngles.z;
            if (bodyZ > 180f) bodyZ -= 360f;

            transform.localRotation = Quaternion.Euler(0f, 0f, bodyZ);
        }
    }
}
