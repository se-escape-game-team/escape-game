using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowSecretLetters : MonoBehaviour
{
    [SerializeField] GameObject spotPapersTrigger;
    [SerializeField] TextMeshPro[] letters;

    bool triggerActive = true;

    private void Start()
    {
        for(int i = 0; i < SaveScript.letterVisible.Length; i++)
        {
            if (SaveScript.letterVisible[i])
            {
                letters[i].enabled = true;
            }
        }
    }

    void Update()
    {
        if (ClickInventoryItem.SelectedItemSprite == "SecretLetterLiquid" && !SaveScript.pause)
        {
            // Deaktivieren des Triggers, damit die Objekte darunter getrackt werden
            spotPapersTrigger.SetActive(false);
            triggerActive = false;

            // Tracken der anvisierten Objekte
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitObject;
            if (Physics.Raycast(ray, out hitObject))
            {
                GameObject hitGameObject = hitObject.transform.gameObject;
                if (hitGameObject.tag == "HiddenLetter")
                {
                    hitGameObject.GetComponent<TextMeshPro>().enabled = true;
                    // Speichern des sichbar gemachten Buchstaben
                    for(int i = 0; i < letters.Length; i++)
                    {
                        if(hitGameObject.GetComponent<TextMeshPro>() == letters[i])
                        {
                            SaveScript.letterVisible[i] = true;
                        }
                    }
                }
            }
        }
        // Wieder Aktivieren des Triggers falls die Tinte nicht ausgerüstet ist
        else if(!triggerActive)
        {
            spotPapersTrigger.SetActive(true);
            triggerActive = true;
        }

    }
}
