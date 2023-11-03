using UnityEngine;

public class CaveCheckPointTrigger1 : MonoBehaviour
{
      [SerializeField] Death death;

        void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            death.LastCheckpoint = death.CheckPoint2;
            death.LastRotation = death.Rotation2;
            gameObject.SetActive(false);
        }
    }
}
