using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BossNpc : MonoBehaviour
{

    public GameObject pRessFObject;
    public GameObject bossDialogue;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pRessFObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {           
            bossDialogue.SetActive(true);          
        }
    }
  
    private void OnTriggerExit(Collider other)
    {
        pRessFObject.SetActive(false);
    }
}
