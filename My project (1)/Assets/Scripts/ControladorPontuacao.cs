using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ControladorPontuacao 
{
    private static int pontuacao;

    public static int Pontuacao()
    {
        get {return pontuacao;}
        set {pontuacao = Value;} 
        if (pontuacao < 0)
        {
            pontuacao = 0;
        }
    }
}
