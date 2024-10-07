using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ondaCoisa : MonoBehaviour
{
    public GameObject onda;

    public Vector3 scaleOndaI = new Vector3(2f, 2f, 2f);
    public Vector3 scaleOndaF = new Vector3(20f, 20f, 20f);

    public float scaleVelo = 2f;

    void Update()
    {
        Vector3 pposition = transform.position;

        if (Input.GetKeyDown(KeyCode.M))
        {
            Andando();
        }
    }

    public void Andando()
    {
        Vector3 pposition = transform.position;

        GameObject newOnda = Instantiate(onda, pposition, Quaternion.identity);

        newOnda.transform.localScale = scaleOndaI;

        StartCoroutine(CrescerAteMorrer(newOnda));
    }

    IEnumerator CrescerAteMorrer(GameObject objeto)
    {
        float tempo = 0f;

        while (tempo<scaleVelo)
        {
            tempo += Time.deltaTime;

            objeto.transform.localScale = Vector3.Lerp(scaleOndaI, scaleOndaF, tempo / scaleVelo);

            yield return null;
        }
        Destroy (objeto);
    }
}