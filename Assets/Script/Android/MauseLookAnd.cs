using UnityEngine;
using System.Collections;

public class MauseLookAnd : MonoBehaviour
{
   

    Vector2 startPosition;
    bool inTheZone = true;
    [SerializeField]
    private Camera _camera2;
    Quaternion rotation;


    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 0;

    private float _speedRotate = 0.16f;

    void Start()
    {

    }
    void Update()
    {
       if(!Joistick.b_GoLeft)
        {
            _rotationX -= 0 * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float delta = -1* _speedRotate * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        if (!Joistick.b_GoRigt)
        {
            _rotationX -= 0 * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float delta = _speedRotate * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        if (!Joistick.b_vverh)
        {
            _rotationX -= _speedRotate * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float delta = 0 * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        if (!Joistick.b_vniz)
        {
            _rotationX -= _speedRotate*-1 * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float delta = 0 * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
