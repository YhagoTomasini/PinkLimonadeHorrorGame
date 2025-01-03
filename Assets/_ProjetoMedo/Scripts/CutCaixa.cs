using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutCaixa : MonoBehaviour
{
    public TextMeshProUGUI textoCut;
    private bool objTriggado;
    public bool podeQuebrar;

    void Start()
    {

        podeQuebrar = false;
        
        if (textoCut == null)
        {
            GameObject cutTextObj = GameObject.Find("CutText");

            if (cutTextObj != null)
            {
                textoCut = cutTextObj.GetComponent<TextMeshProUGUI>();
            }
        }

        if (textoCut != null)
        {
            textoCut.enabled = false;
        }
        objTriggado = false;
    }

    void Update()
    {
        if (objTriggado && Input.GetKeyDown(KeyCode.Space) || objTriggado && Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (podeQuebrar==true)
            {
                cortaCaixa();
                GameObject.Find("Agatha").GetComponent<CharacterActs>().FuncFaca();
                GameObject.Find("NavMesh").GetComponent<NavMeshTest>().DestinoInimigo();
            }
        }
    }

    public void cortaCaixa()
    {
        textoCut.enabled = false;
        GameObject.Find("AudioEffectsManager").GetComponent<AudioSourceGeral>().SomCut();
        GameObject.Find("NavMesh").GetComponent<NavMeshTest>().DestinoInimigo();

        Destroy(gameObject);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (podeQuebrar==true && other.gameObject.CompareTag("Player"))
        {
            textoCut.enabled = true;
            objTriggado = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (podeQuebrar==true && other.gameObject.CompareTag("Player"))
        {
            textoCut.enabled = false;
            objTriggado = false;
        }
    }
}