using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Gem;
    [SerializeField] GameObject EnemyModel;

    public int EnemyHealth;

    float GemPosition;

    public bool isDead = false;
    [SerializeField] bool isCollected;
    
    [SerializeField] PlayerMovement playerMovement;

    void Start()
    {
        
        Enemy = this.gameObject;
        GemPosition = Gem.transform.position.y + 1;
        isCollected = Player.GetComponent<PlayerMovement>().isGemCollected;

    }

    void Update()
    {
        if (EnemyHealth == 0)
        {
            if(!isDead)
            {
                transform.Rotate(270.0f, 0.0f, 0.0f);
                Enemy.transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z);
                if (!isCollected)
                {
                    Gem.SetActive(true);
                    Player.GetComponent<PlayerMovement>().Interactables.Add(Gem);
                }
                Gem.transform.position = new Vector3(Gem.transform.position.x, GemPosition, Gem.transform.position.z);
                this.GetComponent<EnemyController>().enabled = false;
                isDead = true;
                Enemy.tag = "Dead";
                EnemyModel.gameObject.GetComponent<Animator>().enabled = false;

            }
        }
        
    }
 

}


    

