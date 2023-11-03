using UnityEngine;

public class VolcanoTrigger : MonoBehaviour
{
    [SerializeField] Objectives objectives;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
            objectives.Vulcano();

        }
    }
}
