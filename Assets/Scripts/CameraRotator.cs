using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] float speed;

   void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
        
    }
}
