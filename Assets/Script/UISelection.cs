using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;


public class UISelection : MonoBehaviour
{
    public static bool gazedAt;
    public float fillTime = 5f;
    public Image radialImage;
    public UnityEvent onFillComplete;

    private Coroutine fillCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gazedAt = false;
        radialImage.fillAmount = 0;

    }

    public void OnPointerEnter()
    {
        gazedAt = true;

        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine);

        }
        fillCoroutine = StartCoroutine(FillRadial());

    }
    public void OnPointerExit()
    {
        gazedAt = false;

        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine); //Detine el llenado
            fillCoroutine = null;

        }
        radialImage.fillAmount = 0f; // Reinciae lllenado a 0
    }
    private IEnumerator FillRadial()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fillTime)
        {
            if(!gazedAt) //Deja de ver el boton
            {
                yield break;
            }

            // elpsedTime = elapsedTime + TIme.deltaTime
            elapsedTime += Time.deltaTime;
            radialImage.fillAmount = Mathf.Clamp01(elapsedTime/fillTime);

            yield return null;
        }

        onFillComplete?.Invoke();

        //Console.WriteLine(gazedAt?"Verdadero":"Falso")
    }
    // Update is called once per frame
    void Update()
    {

    }
}


