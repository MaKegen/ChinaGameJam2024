using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbAnimationTriggerEvent : MonoBehaviour
{
    [SerializeField]private Transform Player;
    [SerializeField]private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.transform.rotation.y);
    }
    public void ClimbAction(){
        if(Player.transform.rotation.y > 0){
            Player.transform.position += new Vector3 (1f,1.1f,0f);
            ani.SetBool("isClimbing",false);
        }
        else if (Player.transform.rotation.y < 0){
            Player.transform.position += new Vector3 (-1f,1.1f,0f);
            ani.SetBool("isClimbing",false);
        }
        
        
    }
}
