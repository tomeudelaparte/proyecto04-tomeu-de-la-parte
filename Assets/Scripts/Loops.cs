using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    public int initialNum = 40;

    public GameObject[] enemyPrefab;
    public Vector3[] positions;

    private void Start()
    {
        /*
        for (int i = 0; i < positions.Length; i++)
        {
            Instantiate(enemyPrefab[i], positions[i], enemyPrefab[i].transform.rotation);
        }
        */
        
        foreach(Vector3 pos in positions)
        {
            Instantiate(enemyPrefab[0], pos, enemyPrefab[0].transform.rotation);
        }

        /*
        for (int i = initialNum; i >= 0; i--)
        {
            Debug.Log(i);
        }
        */

        StartCoroutine(FadeCoroutine());
    }

    public IEnumerator FadeCoroutine()
    {
        float alphaValue = 0;
        MeshRenderer cubeMeshRenderer = GetComponent<MeshRenderer>();
        Color color = cubeMeshRenderer.material.color;

        while (alphaValue <= 1)
        {
            color.a = alphaValue;

            cubeMeshRenderer.material.color = color;

            alphaValue += 0.1f;

            yield return new WaitForSeconds(1);
        }
    }
}
