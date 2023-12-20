using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Digitacao : MonoBehaviour
{
    public bool imprimindo;
    public float tempoEntreLetras = 0.1f;

    private TextMeshProUGUI componentText;
    private AudioSource sound;
    private string mensagemOriginal;

    private void Awake()
    {
        TryGetComponent(out componentText);
        TryGetComponent(out sound);
        mensagemOriginal = componentText.text;
        componentText.text = "";
    }
    private void OnEnable()
    {
        ImprimirMensagem(mensagemOriginal);
    }
    private void OnDisable()
    {
        componentText.text = mensagemOriginal;
        StopAllCoroutines();
    }
    public void ImprimirMensagem(string mensagem)
    {
        if (gameObject.activeInHierarchy)
        {
            if(imprimindo) return;
            imprimindo = true;
            StartCoroutine(LetraPorLetra(mensagem));
        }
    }
    IEnumerator LetraPorLetra(string mensagem)
    {
        string msg = "";
        foreach (var letra in mensagem)
        {
            msg += letra;
            componentText.text = msg;
            sound.Play();
            yield return new WaitForSeconds(tempoEntreLetras);
        }
        imprimindo = false;
        StopAllCoroutines();
    }
}
