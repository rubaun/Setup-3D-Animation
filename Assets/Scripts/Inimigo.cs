using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private int vida;
    [SerializeField] private int danoArma;
    [SerializeField] private NavMeshAgent agente;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask isGround, isPlayer;
    private Animator animaInimigo;

    [Header("Patrulha")]
    [SerializeField] private Vector3 walkPoint;
    [SerializeField] private float walkPointRange;
    private bool walkPointSet;

    [Header("Ataque")]
    [SerializeField] private float tempoEntreAtaques;
    private bool jaAtacou;


    // Start is called before the first frame update
    void Start()
    {
        animaInimigo = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TomarDano(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        Destroy(gameObject);
    }

    public int Atacar()
    {
        return Random.Range(0, danoArma);
    }

    public void Andar()
    {

    }

    public void AtaqueEspecial()
    {

    }

    public void Spawn()
    {

    }
}
