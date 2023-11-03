using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] Transform Player;
    Vector3 direction;

  void Update()
{
    direction.z = Player.eulerAngles.y;
    transform.localEulerAngles = direction;
}
}
