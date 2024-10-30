using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private bool estaVivo = true;
    [SerializeField] private int ouro;
    [SerializeField] private int vida;
    [SerializeField] private int forcaPulo;
    [SerializeField] private float velocidade;
    [SerializeField] private InventoryManager inventario;
    private bool pegando;
    private bool podePegar;
    private bool podeAtacar;
    private Rigidbody rb;
    private bool estaPulando;
    private Vector3 angleRotation;
    private AnimaPlayer anima;
    private AvisosPlayer avisos;


    // Start is called before the first frame update
    void Start()
    {
        ouro = 0;
        pegando = false;
        podePegar = false;
        angleRotation = new Vector3(0, 90, 0);
        rb = GetComponent<Rigidbody>();
        avisos = GetComponent<AvisosPlayer>();
        inventario = GameObject.FindObjectOfType<InventoryManager>();
        anima = GetComponent<AnimaPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        avisos.InformaOuroPlayer(ouro);

        TurnAround();

        if (Input.GetKeyDown(KeyCode.E) && podePegar)
        {
            anima.PegarAnima();
            pegando = true;
        }

        //Andar
        if (Input.GetKey(KeyCode.W))
        {
            anima.AndarFrenteAnima();
            Walk();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anima.AndarTrasAnima();
            Walk();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anima.AndarAnima();
        }
        else
        {
            anima.PararAnima();
        }

        //Evitar o bug da movimentação
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            anima.PararAnima();
        }

        //Pulo
        if (Input.GetKeyDown(KeyCode.Space) && !estaPulando)
        {
            anima.PularAnima();
            Jump();
        }

        if (Input.GetMouseButtonDown(0) && podeAtacar)
        {
            anima.AtacarAnima();
            Atacar();
        }

        //Correr
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            anima.CorrerAnima();
            Walk(6.5f);
        }
        else
        {
            anima.PararCorrerAnima();
        }

        if (!estaVivo)
        {
            anima.MorrerAnima();
            estaVivo = true;
        }
    }

    private void Atacar()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2))
        {
            if (hit.transform.CompareTag("Inimigo"))
            {
                hit.transform.GetComponent<Inimigo>().TomarDano(10);
            }
        }
    }

    private void Walk(float velo = 1)
    {
        if ((velo == 1))
        {
            velo = velocidade;
        }
        float fowardInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * fowardInput;
        Vector3 moveForward = rb.position + moveDirection * velo * Time.deltaTime;
        rb.MovePosition(moveForward);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        estaPulando = true;
    }

    private void TurnAround()
    {
        float sideInput = Input.GetAxis("Horizontal");
        Quaternion deltaRotation = Quaternion.Euler(angleRotation * sideInput * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Chao"))
        {
            estaPulando = false;
            anima.NoChao();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        podePegar = true;
        podeAtacar = true;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag);
      
        if(other.gameObject.CompareTag("Chave") && pegando)
        {
            other.gameObject.GetComponent<ItemPickup>().Pickup();
            podePegar = false;
            pegando = false;
        }
        
        if(other.gameObject.CompareTag("Porta") && pegando && !other.gameObject.GetComponent<Porta>().Aberto())
        {
            Porta porta = other.gameObject.GetComponent<Porta>();
            if (VerificaChave(porta.PegarNumeroFechadura()))
            {
                other.gameObject.GetComponent<Porta>().AbrirPorta();
                DescartarChaveUtilizada(porta.PegarNumeroFechadura());
            }
        }

        if (other.gameObject.CompareTag("Bau") && pegando && !other.gameObject.GetComponent<Bau>().Aberto())
        {
            Bau bau = other.gameObject.GetComponent<Bau>();
            if (VerificaChave(bau.PegarNumeroFechadura()))
            {
                PegarConteudoBau(other.gameObject);
                podePegar = false;
                pegando = false;
                DescartarChaveUtilizada(bau.PegarNumeroFechadura());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pegando = false;
        podePegar = false;
        podeAtacar = false;
    }

    private bool VerificaChave(int chave)
    {
        foreach (Item item in inventario.Itens)
        {
            if(item is Chave chaveNumero)
            {
                int numero = chaveNumero.PegarNumeroChave();
                
                if (numero == chave)
                {
                    return true;
                }
            }
            else
            {
                avisos.ListarAvisos("Chave não encontrada!");
            }
        }

        
        return false;
    }

    private void PegarConteudoBau(GameObject bau)
    {
        Bau bauTesouro = bau.GetComponent<Bau>();

        avisos.ListarAvisos($"+{ouro += bauTesouro.PegarOuro()} de ouro");

        bauTesouro.AcessarConteudoBau();
        
        avisos.ListarAvisos("Novos itens!");
    }

    private void DescartarChaveUtilizada(int numChave)
    {
        foreach (Item item in inventario.Itens)
        {
            if (item is Chave chave) //Cast
            {
                if (chave.PegarNumeroChave() 
                    == numChave)
                {
                    inventario.RemoveItem(item);
                    inventario.Itens.Remove(item);
                    avisos.ListarAvisos("Chave Utilizada!");
                }
            }
        }
    }
    

    

}
