using UnityEngine;

public class CaveCheckPointTriggerBetween1and2 : MonoBehaviour
{
    [SerializeField] Death death;

        void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            death.LastCheckpoint = death.CheckPointBetween1and2;
            death.LastRotation = death.RotationBetween1and2;
            gameObject.SetActive(false);
            Debug.Log("asd");
        }
    }
}
