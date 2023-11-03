using UnityEngine;

public class CaveCheckPointTrigger4 : MonoBehaviour
{
   [SerializeField] Death death;

        void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            death.LastCheckpoint = death.CheckPoint5;
            death.LastRotation = death.Rotation5;
            gameObject.SetActive(false);
        }
    }
}
