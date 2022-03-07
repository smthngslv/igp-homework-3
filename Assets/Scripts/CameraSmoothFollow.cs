using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    public Transform target;
    public float smoothness = 0.95f;

    private Vector3 _offset;

    private void Awake()
    {
        _offset = target.position - transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position - _offset, 1.0f - smoothness);
    }
}
