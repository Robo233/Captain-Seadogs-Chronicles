using UnityEngine;

public class CaveCheckPointTrigger3 : MonoBehaviour
{
   [SerializeField] Death death;

        void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            death.LastCheckpoint = death.CheckPoint4;
            death.LastRotation = death.Rotation4;
            gameObject.SetActive(false);
        }
    }
}
