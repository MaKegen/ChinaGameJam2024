using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbAnimationTriggerEvent : MonoBehaviour
{
    [SerializeField]private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Player.transform.rotation.y);
    }
    public void ClimbAction(){
        if(transform.rotation.y > 0){
            transform.position += new Vector3 (1f,1.1f,0f);
            //transform.position+= new Vector3 (1f,1.1f,0f);
            ani.SetBool("isClimbing",false);
        }
        else if (transform.rotation.y < 0){
            transform.position += new Vector3 (-1f,1.1f,0f);
            //transform.position = new Vector3 (-1f,1.1f,0f);
            ani.SetBool("isClimbing",false);
        }
        
        
    }

}
