using UnityEngine;

public class DuckController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool isGameStarted = false;

    public LegSwing legScript; // 다리 스크립트를 여기서 컨트롤

    void Update()
    {
        // 게임 시작
        if (!isGameStarted && Input.GetKeyDown(KeyCode.Return))
        {
            isGameStarted = true;

            // 다리 움직임 시작
            if (legScript != null)
            {
                legScript.StartWalking();
            }
        }

        // 앞으로 이동
        if (isGameStarted)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
}
