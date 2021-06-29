using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TaskSecretInc : MonoBehaviour
{
    string firstElement = null;
    string secondElement = null;
    bool solved = false;

    [SerializeField] Sprite ItemCup;
    [SerializeField] GameObject Cup;

    //Verschiedene Fluessigkeiten im Glas
    [SerializeField] GameObject liquidHalf;
    [SerializeField] GameObject liquidRight;
    [SerializeField] GameObject liquidWrong;

    // Farben fuer Fluessigkeit in Zylinder
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

    //Button zum weiter versuchen oder aufnehmen ins Inventar
    [SerializeField] GameObject addToInventorry;
    [SerializeField] GameObject retry;

    private void Start()
    {
        addToInventorry.SetActive(false);
        retry.SetActive(false);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitObject;
        Material liquidHalfMaterial = liquidHalf.GetComponent<MeshRenderer>().material;
        if (!solved && !SaveScript.pause)
        {
            if (Physics.Raycast(ray, out hitObject))
            {
                GameObject hitGameObject = hitObject.transform.gameObject;
                if (hitGameObject.name == "Cup" && ClickInventoryItem.SelectedItemSprite.Contains("Inc"))
                {
                    // Elementbezeichnung aus Sprite extrahieren
                    string[] spriteName = ClickInventoryItem.SelectedItemSprite.Split('_');
                    Debug.Log(hitGameObject.name);

                    if (firstElement == null)
                    {
                        firstElement = spriteName[0];
                        //Glas halb fuellen mit entsprechender Farbe
                        liquidHalf.SetActive(true);
                        //Richtige Farbe fuer die erste Fl?ssigkeit setzen
                        switch (firstElement)
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
                                throw new System.Exception("Bitte Farbe fuer diese Chemicalie zuweisen");
                        }
                    }
                    else
                    {
                        secondElement = spriteName[0];
                        if (firstElement != secondElement)
                        {
                            //Richtige zusammensetzung: Erst NH3, dann H2O oder umgekehrt
                            if ((firstElement == "NH3" && secondElement == "H2O") || (secondElement == "NH3" && firstElement == "H2O"))
                            {
                                liquidHalf.SetActive(false);
                                liquidRight.SetActive(true);
                                addToInventorry.SetActive(true);
                                solved = true;
                            }
                            else
                            {
                                liquidHalf.SetActive(false);
                                liquidWrong.SetActive(true);
                                retry.SetActive(true);
                            }
                        }
                    }
                }
            }
        }

    }

    /// <summary>
    /// neuer Versuch
    /// </summary>
    public void Retry()
    {
        //Fl?ssigkeiten ausblenden
        liquidHalf.SetActive(false);
        liquidRight.SetActive(false);
        liquidWrong.SetActive(false);

        firstElement = null;
        secondElement = null;

        //Buttons ausblenden
        addToInventorry.SetActive(false);
        retry.SetActive(false);
    }

    /// <summary>
    /// Resultat zum Inventar hinzufuegen
    /// </summary>
    public void AddToInventory()
    {
        Inventory inventory = GameObject.FindObjectOfType<Inventory>();
        inventory.AddItem(ItemCup);
        Cup.SetActive(false);
        addToInventorry.SetActive(false);
    }
}
