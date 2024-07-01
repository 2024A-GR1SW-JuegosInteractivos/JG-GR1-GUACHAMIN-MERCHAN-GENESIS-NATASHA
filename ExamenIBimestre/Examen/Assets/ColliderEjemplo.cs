using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEjemplo : MonoBehaviour
{
    [SerializeField] float delayDestroy = 0.5f;
    private bool tienePaquete; // false
    [SerializeField] Color32 tienePaqueteColor = new Color32(255,0,0,255);
    [SerializeField] Color32 noTienePaqueteColor = new Color32(0,255,0,255);
    private SpriteRenderer spriteRenderer;
    [SerializeField] private CarritoScript carritoScript; // Referencia al script del carrito

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Cuidado princesita!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando en trigger!");
        if (other.tag == "Paquete")
        {
            
            Debug.Log("Ganaste una gema");
            tienePaquete = true;
            spriteRenderer.color = tienePaqueteColor;
            Destroy(other.gameObject, delayDestroy);
            carritoScript.RecogerPaquete(); // Actualiza el contador y el tamaño del carrito
        }
        // if (other.tag == "Cliente" && tienePaquete)
        // {
        //     tienePaquete = false;
        //     spriteRenderer.color = noTienePaqueteColor;
        //     Debug.Log("Dejo paquete!");
        // }
    }
}
