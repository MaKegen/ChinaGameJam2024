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
        
    }
    public void ClimbAction(){
        Player.transform.position += new Vector3 (0f,1f,0.5f);
        ani.SetBool("isClimbing",false);
    }
}
