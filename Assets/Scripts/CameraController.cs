using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSensivity;

    private Transform parent;

    private Quaternion CamRotation;

    public float cameraSmoothingFactor = 1;
    public float lookUpMax = 60;
    public float lookUpMin = -60;

    private void Start()
    {
        parent = transform.parent;
        CamRotation = transform.localRotation;
    }

    private void Update()
    {
        Rotate();

        CamRotation.x += Input.GetAxis("Mouse Y") * cameraSmoothingFactor * (-1);

        CamRotation.x = Mathf.Clamp(CamRotation.x, lookUpMin, lookUpMax);
        
        transform.localRotation = Quaternion.Euler(CamRotation.x, transform.localRotation.y, transform.localRotation.z);
     //   LookBackCamera.transform.localRotation = Quaternion.Euler(CamRotation.x, 180f, LookBackCamera.transform.localRotation.z);

    
    }
    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;

        parent.Rotate(Vector3.up, mouseX);
    }
}
