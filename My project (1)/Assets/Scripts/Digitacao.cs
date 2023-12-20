using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Digitacao : MonoBehaviour
{
    public bool imprimindo;

    private TextMeshProUGUI componentText;
    private AudioSource sound;
    private string mensagemOriginal;

    private void Awake()
    {
        TryGetComponent(out componentText);
        TryGetComponent(out sound);
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
    public void ImprimirMensagem(string msg)
    {

    }
    IEnumerator LetraPorLetra(string msg)
    {
        yield return null;
    }
}
