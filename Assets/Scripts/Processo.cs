using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Processo : MonoBehaviour
{
    public int prioridade;
    public int estado;
    public int tamanho;
    public int tempo_alocacao;
    public int contRR;
    public bool ativo;

    void Start()
    {
        contRR = 4;
    }

    void Update()
    {
        
    }
}
