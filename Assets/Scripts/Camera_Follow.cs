using UnityEditor;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - player.position;
    }

    
    void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
