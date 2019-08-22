using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    HeroData hs; // Se creó una variable del Struct.
    GameObject pov; // Se creó un GameObject al que se le asignarán los componentes de la cámara. (pov: point of view)

    void Start()
    {
        // Vector3 que almacena la posición, las otras dos variables la asignan de manera aleatoria en los ejes X y Z.
        Vector3 posicion = new Vector3();
        posicion.x = Random.Range(-30, 30);
        posicion.z = Random.Range(-30, 30);

        // Al GameObject se le asignaron los componentes de cámara, rotación y movimiento.
        GameObject pov = new GameObject();
        pov.AddComponent<Camera>();
        pov.AddComponent<HeroAim>();
        gameObject.AddComponent<HeroMove>();
        gameObject.GetComponent<HeroMove>().speed = hs.RandomSpeed(); // Se utilizaron los miembros del Enum "Speed", y se reasigna la velocidad.

        pov.transform.SetParent(this.transform);
        pov.transform.localPosition = Vector3.zero;

    }

    //Rotación en Y.
    public void Update()
    {
        float rotat = transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0.0f, rotat, 0.0f);

    }

    // La siguiente función es la encargada de imprimir los mensajes cuando hay colisión, utilizando las etiquetas.
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Villager")
        {

            collision.transform.GetComponent<Villagers>().PrintNames();
        }

        if (collision.transform.tag == "Zombie")
        {
            collision.transform.GetComponent<Zombie>().PrintMessages();

        }
    }
}

public struct HeroData // Este Struct almacena las variables, además de una función que asigna la velocidad aleatoria del héroe.
{
    public Speed mySpeed;
    public float theSpeed;

    public float RandomSpeed() // Se asignaron 3 velocidades: lento, normal y veloz, de las cuales se escogerá una aleatoriamente.
    {

        int x = Random.Range(0, 3);

        switch (x)
        {
            case 0:
                mySpeed = Speed.Low;
                break;

            case 1:
                mySpeed = Speed.Medium;
                break;

            case 2:
                mySpeed = Speed.Fast;
                break;
        }

        if (mySpeed == Speed.Low)
        {
            theSpeed = 0.05f;
        }

        else if (mySpeed == Speed.Medium)
        {
            theSpeed = 0.1f;
        }

        else if (mySpeed == Speed.Fast)
        {
            theSpeed = 0.2f;
        }
        return theSpeed;
    }
}

public enum Speed // Este Enum almacena las 3 velocidades antes mencionadas.
{
    Low,
    Medium,
    Fast
}