using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveCollapse : MonoBehaviour
{
    public Animator anim;
    public GameObject caveLight;
    public GameObject caveWall;
    public GameObject sceneTransition;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    static bool hasActivated = false;

    private void Start()
    {
        if (hasActivated)
        {
            caveLight.SetActive(false);
            caveWall.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player" && !other.isTrigger)
        {
            hasActivated = true;
            anim.SetTrigger("shake");
            Invoke("BlockOfCave", 2);
            Destroy(gameObject, 7.5f);
        }
    }

    public void BlockOfCave()
    {
        caveLight.SetActive(false);
        caveWall.SetActive(true);
        sceneTransition.SetActive(false);
        Invoke("DialogBoxOn", 2f);
    }

    public void TurnOffDialogBox()
    {
        if (dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
        }
    }

    public void DialogBoxOn()
    {
        dialogBox.SetActive(true);
        dialogText.text = dialog;
        Invoke("TurnOffDialogBox", 2);
    }
}
