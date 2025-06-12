using UnityEngine;

public class BodyTilt : MonoBehaviour
{
    public float maxTiltAngle = 170f;
    public float tiltSpeed = 2f;
    public float inputTiltSpeed = 50f;
    public float tiltIntervalMin = 1f;
    public float tiltIntervalMax = 3f;

    private float targetZRotation;
    private float currentZRotation;
    private float nextTiltTime;

    void Start()
    {
        currentZRotation = transform.localEulerAngles.z;
        if (currentZRotation > 180f) currentZRotation -= 360f;
        SetNewTargetRotation();
    }

    void Update()
    {
        // 방향키 입력 처리
        float input = Input.GetAxis("Horizontal"); // 왼쪽: -1, 오른쪽: +1

        // 입력이 있을 경우 수동 조정
        if (Mathf.Abs(input) > 0.1f)
        {
            currentZRotation += input * inputTiltSpeed * Time.deltaTime;
            currentZRotation = Mathf.Clamp(currentZRotation, -maxTiltAngle, maxTiltAngle);
        }
        else
        {
            // 입력 없으면 자동 기울기 자연스럽게 적용
            currentZRotation = Mathf.Lerp(currentZRotation, targetZRotation, Time.deltaTime * tiltSpeed);
        }

        transform.localRotation = Quaternion.Euler(0f, 0f, currentZRotation);

        // 다음 기울기 타이밍 설정
        if (Time.time >= nextTiltTime && Mathf.Abs(input) < 0.1f)
        {
            SetNewTargetRotation();
        }
    }

    void SetNewTargetRotation()
    {
        targetZRotation = Random.Range(-maxTiltAngle, maxTiltAngle);
        nextTiltTime = Time.time + Random.Range(tiltIntervalMin, tiltIntervalMax);
    }
}
