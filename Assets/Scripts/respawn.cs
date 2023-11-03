using UnityEngine;

public class respawn : MonoBehaviour
{
  
    [SerializeField] GameObject SceneLoader;

    [SerializeField] string causeOfDeath;

    Collider m_ObjectCollider;

    void Start()
    {
        SceneLoader = GameObject.Find("SceneLoader");
        if (this.gameObject.name == "Lava")
        {
            causeOfDeath = "The lava's hot!";
        }
        else{
            causeOfDeath = "The sharks are dangerous!";
        }
   
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player"){
        SceneLoader.GetComponent<Death>().DeathFunction(causeOfDeath);
        }
    }

    
}


