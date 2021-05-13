using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SJF : MonoBehaviour
{
    public Processo[] processos;
    public Text[] prioridades;
    public Text[] tempoExec;
    public Text[] inicios;
    public int[] filaExec;

    public GameObject valoresMenu;
    public GameObject GUI;
    public GameObject vazio;
    public GameObject pronto;
    public GameObject executando;
    public GameObject removido;
    public int total_processos;
    public int proximo;
    public int inimax;
    public int menor;
    public Text totalProc;

    public bool ready;
    public bool processadorOcupado;
    public bool cameraLock;

    public float X, Y, Z;
    float Y2;

    int i, j, cont, posFila, contFila, contmax;


    void Start()
    {
        cameraLock = true;
        ready = false;
        contmax = 0;
        posFila = 0;
        contFila = 0;
        menor = 0;
        cont = 0;
        Y2 = Y;
        processadorOcupado = false;
    }

    void FixedUpdate()
    {
        if (ready)
        {
            for (i = 0; i < total_processos; i++)
            {
                contmax += processos[i].tamanho;
                //if (processos[i].tempo_alocacao < inimax)
                //{
                //    proximo = i;
                //    inimax = processos[i].tempo_alocacao;
                //}
            }
            if (contmax > 80)
            {
                contmax = 80;
            }
            ready = false;
        }

        if (cont < contmax)
        {
            for (i = 0; i < total_processos; i++)
            {
                if (processos[i].tempo_alocacao == cont && processos[i].ativo == true)
                {
                    processos[i].estado = 1;
                    filaExec[posFila] = i;
                    posFila++;
                    if (i > 0)
                    {
                        if(processos[filaExec[posFila]].tamanho < processos[filaExec[posFila-1]].tamanho)
                        {
                            menor = filaExec[posFila - 1];
                            filaExec[posFila - 1] = filaExec[posFila];
                            filaExec[posFila] = menor;
                        }
                    }
                }
                if (processadorOcupado == false && processos[i].estado == 1)
                {
                    processos[filaExec[contFila]].estado = 2;
                    processadorOcupado = true;
                }
                if (processos[i].tamanho == 0 && processos[i].estado == 2 && processos[i].ativo == true && processadorOcupado == true)
                {
                    processos[i].estado = 3;
                    processadorOcupado = false;
                    contFila++;
                }
                if (processos[i].tamanho > 0 && processos[i].estado == 2)
                {
                    processos[i].tamanho--;
                }
                if (filaExec[contFila] < i && processadorOcupado == false && processos[filaExec[contFila]].estado == 1)
                {
                    processos[filaExec[contFila]].estado = 2;
                    processadorOcupado = true;
                }
            }
            SpawnBlocos();
            cont++;
        }
    }

    void SpawnBlocos()
    {
        for (j = 0; j < 10; j++)
        {
            //Debug.Log(j);
            if (processos[j].estado == 0) { Instantiate(vazio, new Vector3(X, Y2, Z), Quaternion.identity); }
            if (processos[j].estado == 1) { Instantiate(pronto, new Vector3(X, Y2, Z), Quaternion.identity); }
            if (processos[j].estado == 2) { Instantiate(executando, new Vector3(X, Y2, Z), Quaternion.identity); }
            if (processos[j].estado == 3) { Instantiate(removido, new Vector3(X, Y2, Z), Quaternion.identity); }
            Y2 -= 0.75f;
        }
        X += 0.75f;
        Y2 = Y;
    }

    public void Play()
    {
        total_processos = int.Parse(totalProc.text);
        for (j = 0; j < total_processos; j++)
        {
            processos[j].tamanho = int.Parse(tempoExec[j].text);
            processos[j].tempo_alocacao = int.Parse(inicios[j].text);
            processos[j].prioridade = int.Parse(prioridades[j].text);
            if (processos[j].tamanho > 0)
            {
                processos[j].ativo = true;
            }
        }
        ready = true;
    }

    public void OcultaMenu()
    {
        valoresMenu.SetActive(false);
        GUI.SetActive(true);
        cameraLock = false;
    }

    public void Reload()
    {
        SceneManager.LoadScene(3);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
