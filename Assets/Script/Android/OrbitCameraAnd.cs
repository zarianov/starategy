using UnityEngine;
using System.Collections;
public class OrbitCameraAnd : MonoBehaviour
{
    [SerializeField]
    private Transform target;  
  public float rotSpeed = 1.5f;
    private float _rotY;
    private float _rotX;
    private float _rotZ;
    private Vector3 _offset;


    void Start()
    {
        _rotZ = transform.eulerAngles.z;
        _rotX = transform.eulerAngles.x;
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position;
    }
    void LateUpdate()
    {
        // float horInput = Input.GetAxis("Horizontal");

        if (!AndroidButtons.b_GoLeft)
        {
            _rotY += -1 * rotSpeed * 3;
        }
        if (!AndroidButtons.b_GoRigt)
        {
            _rotY += 1 * rotSpeed * 3;
        }
        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, _rotZ);
        
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
       
    }
}
