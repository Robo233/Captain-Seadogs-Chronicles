using UnityEngine;

public class CaveCheckPointTrigger2 : MonoBehaviour
{
     [SerializeField] Death death;

        void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            death.LastCheckpoint = death.CheckPoint3;
            death.LastRotation = death.Rotation3;
            gameObject.SetActive(false);
        }
    }
}
