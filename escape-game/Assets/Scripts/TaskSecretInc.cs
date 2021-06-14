using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSecretInc : MonoBehaviour
{
    [SerializeField] GameObject liquidHalf;
    string element;
    // Farben für Flüssigkeit in Zylinder
    [SerializeField] private Color H2O = new Color(6, 219, 255, 150);
    [SerializeField] private Color NH3 = new Color(6, 255, 9, 150);
    [SerializeField] private Color HCl = new Color(96, 0, 241, 150);
    [SerializeField] private Color H2CO3 = new Color(233, 117, 0, 150);
    [SerializeField] private Color HF = new Color(255, 19, 0, 150);
    [SerializeField] private Color NaHCO3 = new Color(13, 89, 0, 150);
    [SerializeField] private Color H2SO4 = new Color(255, 241, 0, 150);
    [SerializeField] private Color KOH = new Color(99, 69, 10, 150);
    [SerializeField] private Color H3PO4 = new Color(0, 0, 0, 150);
    [SerializeField] private Color NaOH = new Color(8, 23, 255, 150);

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitObject;
        Material liquidHalfMaterial = liquidHalf.GetComponent<MeshRenderer>().material;
        if (Physics.Raycast(ray, out hitObject))
        {
            GameObject hitGameObject = hitObject.transform.gameObject;

            if (hitGameObject.name == "SpotCupTrigger" && ClickInventoryItem.SelectedItemSprite.Contains("Inc"))
            {
                string[] spriteName = ClickInventoryItem.SelectedItemSprite.Split('_');
                element = spriteName[0];
                Debug.Log(element);
                liquidHalf.SetActive(true);

                //Richtige Farbe für die erste Flüssigkeit setzen
                switch (element) 
                {
                    case "H2O":
                        liquidHalfMaterial.SetColor("_Color", H2O);
                        break;
                    case "NH3":
                        liquidHalfMaterial.SetColor("_Color", NH3);
                        break;
                    case "HCl":
                        liquidHalfMaterial.SetColor("_Color", HCl);
                        break;
                    case "H2CO3":
                        liquidHalfMaterial.SetColor("_Color", H2CO3);
                        break;
                    case "HF":
                        liquidHalfMaterial.SetColor("_Color", HF);
                        break;
                    case "NaHCO3":
                        liquidHalfMaterial.SetColor("_Color", NaHCO3);
                        break;
                    case "H2SO4":
                        liquidHalfMaterial.SetColor("_Color", H2SO4);
                        break;
                    case "KOH":
                        liquidHalfMaterial.SetColor("_Color", KOH);
                        break;
                    case "H3PO4":
                        liquidHalfMaterial.SetColor("_Color", H3PO4);
                        break;
                    case "NaOH":
                        liquidHalfMaterial.SetColor("_Color", NaOH);
                        break;
                    default:
                        throw new System.Exception("Bitte Farbe für diese Chemicalie zuweisen");
                        
                }

                // erstes Element speichern

                //zweites Element erkennen

                //auswerten ob sinvoll oder nicht

                //Möglichkeit zu wiederholen


            }
        }
    }
}
