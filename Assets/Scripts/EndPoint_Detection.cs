using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint_Detection : MonoBehaviour
{
    private InputActions Tempdisable;
    [SerializeField]private Transform Player;
        public GameObject CanvasOn ;
        //private bool isTransporting = false;
        private void Awake() {
            Tempdisable = new InputActions();
        }
        void Start()
    {
        CanvasOn.SetActive(false);
    }
    private void Update() {
    /*    if(isTransporting){
            Player.transform.position = new Vector3(-1f,9f,0f);
            //isTransporting = false;
        }
        */
    }
        private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Tempdisable.Disable();
            Player.transform.position = new Vector3(-1f,9f,0f);
            CanvasOn.SetActive(true);
            Tempdisable.Enable();
            CanvasOn.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player")){
            Tempdisable.Disable();
            Player.transform.position = new Vector3(-1f,9f,0f);
            CanvasOn.SetActive(true);
        }
    }
}
