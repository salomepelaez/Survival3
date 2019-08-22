using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    void Start()
    {
        int x = Random.Range(10, 21); //Este Rango aleatorio es el que brinda la posibilidad de creación de aldeanos y zombies.

        for (int j = 0; j < x; j++)
        {
            GameObject thePeople = GameObject.CreatePrimitive(PrimitiveType.Cube); // El GameObject "thePeople" genera los cubos para zombies, aldeanos y héroes.

            // El Vector3 de posición es el que servirá para generar los cubos en una posición aleatoria.
            Vector3 posicion = new Vector3();
            posicion.x = Random.Range(-30, 30);
            posicion.z = Random.Range(-30, 30);
            thePeople.transform.position = posicion; // A los cubos se les asigna la posición aleatoria antes mencionada.
            thePeople.AddComponent<Rigidbody>(); // Se les agrega Rigidbody.
            thePeople.GetComponent<Rigidbody>().freezeRotation = true; // Se congeló también la rotación, evitando así que giren sobre sí mismos.

            int change = Random.Range(0, 2); // Se creó un Random con dos únicas opciones.

            // El siguiente bloque de código se encarga de generar el héroe, está separado pues a diferencia de los miembros de la aldea, solo debe ser creado una vez.
            if (j == 0)
            {
                thePeople.AddComponent<Hero>(); // Se le agregan los componentes de la clase Hero.
                thePeople.AddComponent<HeroAim>(); // Igualmente se le agregan los componentes de HeroAim.
                thePeople.GetComponent<Renderer>().material.color = Color.black; // Se le asignó color negro para diferenciarlos de otros objetos.
            }

            else // A continuación se utiliza el Random mencionado anteriormente.
            {
                switch (change) // La primera posibilidad del Random genera los zombies, la segunda los aldeanos.
                {
                    case 0:
                        thePeople.AddComponent<Zombie>(); // Se agregan los componentes de su respectiva clase.
                        break;
                    case 1:
                        thePeople.AddComponent<Villagers>(); // Se agregan los componentes de su respectiva clase. 
                        break;
                }
            }
        }
    }
}
