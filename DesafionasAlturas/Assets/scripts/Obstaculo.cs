﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.5f;
    [SerializeField]
    private float variacaoDaPosicaoY;
    private Vector3 posicaoDoAviao;
    private bool pontuei;
    private Pontuacao pontuacao;
    private void Start()
    {
        this.posicaoDoAviao = GameObject.FindObjectOfType<Aviao>().transform.position;
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }
    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(-variacaoDaPosicaoY, variacaoDaPosicaoY));
    }
    private void Update()
    {
        this.transform.Translate(Vector3.left*this.velocidade * Time.deltaTime);

        if (this.pontuei && this.transform.position.x < this.posicaoDoAviao.x)
        {
            Debug.Log("pontuou");
            this.pontuei = true;
            this.pontuacao.AdicionarPontos();
            

        }
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        this.Destruir() ;
    }
    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
