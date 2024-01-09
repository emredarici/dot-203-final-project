using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    public Vector3 offset;
    void Start()
    {
        offset = transform.position - player.position;
    }
    void Update()
    {
        transform.position = player.position + offset;
    }
}
