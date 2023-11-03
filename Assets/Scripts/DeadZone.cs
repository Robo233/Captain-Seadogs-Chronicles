using UnityEngine;

public class DeadZone : MonoBehaviour
{

    [SerializeField] GameObject WarningX1;
    [SerializeField] GameObject WarningX2;
    [SerializeField] GameObject WarningZ1;
    [SerializeField] GameObject WarningZ2;
    [SerializeField] GameObject DeadX1;
    [SerializeField] GameObject DeadX2;
    [SerializeField] GameObject DeadZ1;
    [SerializeField] GameObject DeadZ2;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Warning;

    [SerializeField] Death death;
    
    void Update()
    {
        WarningCheck();
    }

    void WarningCheck(){
        if( Player.transform.position.x<=WarningX1.transform.position.x  || Player.transform.position.x>=WarningX2.transform.position.x || Player.transform.position.z<=WarningZ1.transform.position.z  || Player.transform.position.z>=WarningZ2.transform.position.z ){
            if(Player.transform.position.x<=DeadX1.transform.position.x  || Player.transform.position.x>=DeadX2.transform.position.x || Player.transform.position.z<=DeadZ1.transform.position.z  || Player.transform.position.z>=DeadZ2.transform.position.z){ 
                 death.DeathFunction("I told'ya");
            }
            else{
                Warning.SetActive(true);
            }
            
        }
        else{
            Warning.SetActive(false);
        }
    }

}
