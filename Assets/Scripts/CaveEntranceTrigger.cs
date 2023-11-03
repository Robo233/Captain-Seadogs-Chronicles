using UnityEngine;

public class CaveEntranceTrigger : MonoBehaviour
{
    [SerializeField] Objectives objectives;

        void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            objectives.CaveEntrance();
            
        }
    }
}
