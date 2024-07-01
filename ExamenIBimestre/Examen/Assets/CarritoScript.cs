using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoScript : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float velocidadRapido = 20f;
    [SerializeField] float velocidadLento = 5f;
    [SerializeField] float incrementoTamano = 0.1f; // Incremento de tamaño por cada paquete
    private int contadorPaquetes = 0; // Contador de paquetes recogidos

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
     float steerAmount = steerSpeed * Time.deltaTime;
        float moveAmount = moveSpeed * Time.deltaTime;

        // Mover a la derecha e izquierda
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveAmount, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveAmount, 0, 0);
        }

        // Mover hacia arriba y hacia abajo
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, moveAmount, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -moveAmount, 0);
        }

        // Cambiar rotación
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(0, 0, steerAmount);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rapido")
        {
            Debug.Log("Ir Rapido");
            moveSpeed = velocidadRapido;
        }
        if (other.tag == "Lento")
        {
            Debug.Log("Ir Lento");
            moveSpeed = velocidadLento;
        }
    }

    public void RecogerPaquete()
    {
        contadorPaquetes++;
        transform.localScale += new Vector3(incrementoTamano, incrementoTamano, 0);
        Debug.Log("Paquetes recogidos: " + contadorPaquetes);
    }
}
