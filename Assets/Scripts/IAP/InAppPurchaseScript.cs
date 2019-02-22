using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InAppPurchaseScript : MonoBehaviour {

    public GameObject[] Characters;
    public int CharactersUnlocked;
    public GameObject LockedCharacter;

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    public void ActivateCharacters()
    {


        for (int i = 0 ; i <= Characters.Length-1; i++)
        {

            if(i<CharactersUnlocked)
            {
                //Characters[i].SetActive(true);
                Characters[i].GetComponent<Image>().enabled = false;
                Characters[i].GetComponent<Button>().enabled = false;
            }
                else
                {
                Characters[i].GetComponent<Image>().enabled = true;
                Characters[i].GetComponent<Button>().enabled = true;
                }

            //Debug.Log(Characters[i].GetComponent<Image>().enabled);
        }
        if(CharactersUnlocked == 2)
        {
            LockedCharacter.SetActive(true);

        }
    }
}
