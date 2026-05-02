using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public enum MoveDirection { LeftRight, UpDown, ForwardBack }

    [Header("Movement Settings")]
    public MoveDirection direction = MoveDirection.LeftRight;
    public float distance = 5f;
    public float speed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float moveOffset = Mathf.Sin(Time.time * speed) * distance;

        switch (direction)
        {
            case MoveDirection.ForwardBack:
                transform.position = startPos + new Vector3(moveOffset, 0, 0);
                break;
            case MoveDirection.UpDown:
                transform.position = startPos + new Vector3(0, moveOffset, 0);
                break;
            case MoveDirection.LeftRight:
                transform.position = startPos + new Vector3(0, 0, moveOffset);
                break;
        }
    }
}