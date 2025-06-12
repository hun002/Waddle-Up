using UnityEngine;

public class LegSwing : MonoBehaviour
{
    public Transform leftLeg;
    public Transform rightLeg;

    public float swingAmount = 15f;
    public float swingSpeed = 3f;

    private bool isWalking = false;
    private float timer = 0f;

    public void StartWalking()
    {
        isWalking = true;
    }

    void Update()
    {
        if (!isWalking) return;

        timer += Time.deltaTime * swingSpeed;
        float angle = Mathf.Sin(timer) * swingAmount;

        if (leftLeg != null)
            leftLeg.localRotation = Quaternion.Euler(0f, 0f, angle);
        if (rightLeg != null)
            rightLeg.localRotation = Quaternion.Euler(0f, 0f, -angle);
    }
}
