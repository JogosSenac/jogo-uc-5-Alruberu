using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPontuacao
{
    private static int pontuacao;

    public static int Pontuacao
    {
        //Pegar pontuação
        get {return pontuacao;}

        //Setar pontuação
set{ pontuacao = value;
        
     if (pontuacao < 0) 
        {
        pontuacao = 0;
        }
         Debug.Log("Pontuação atualizada para: " + Pontuacao);
    }// Set

    }//StaInt
}
