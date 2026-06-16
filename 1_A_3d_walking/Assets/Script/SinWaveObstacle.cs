using UnityEngine;

public class SinWaveObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection = Vector3.up; // 움직일 방향
    [SerializeField] private float speed = 2f;                  // 왕복 속도
    [SerializeField] private float distance = 6f;               // 중심점 기준 이동 반경

    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Mathf.Sin은 -1에서 1 사이를 부드럽게 반복합니다.
        float cycle = Mathf.Sin(Time.time * speed);

        // 시작 위치를 중심으로 좌우/상하로 움직입니다.
        transform.position = startPosition + (moveDirection.normalized * cycle * distance);
    }
}
