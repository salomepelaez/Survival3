using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NPC
{
    public class Manager : MonoBehaviour
    {
        public const int maxGen = 25;
        public readonly int minGen;

        public static float sHero;

        public void Awake()
        {
            sHero = Random.Range(0.1f, 0.2f);
        }

        void Start()
        {            
            int rnd = Random.Range(minGen, maxGen);
            for (int j = 0; j < rnd; j++)
            {
                new minGenerator(minGen);
                GameObject thePeople = GameObject.CreatePrimitive(PrimitiveType.Cube); // El GameObject "thePeople" genera los cubos para zombies, aldeanos y héroes.

                // El Vector3 de posición es el que servirá para generar los cubos en una posición aleatoria.
                Vector3 posicion = new Vector3();
                posicion.x = Random.Range(-30, 30);
                posicion.z = Random.Range(-30, 30);
                thePeople.transform.position = posicion; // A los cubos se les asigna la posición aleatoria antes mencionada.
                thePeople.AddComponent<Rigidbody>(); // Se les agrega Rigidbody.
                thePeople.GetComponent<Rigidbody>().freezeRotation = true;
                int change = Random.Range(0, 2); // Se creó un Random con dos únicas opciones.

                // El siguiente bloque de código se encarga de generar el héroe, está separado pues a diferencia de los miembros de la aldea, solo debe ser creado una vez.
                if (j == 0)
                {
                    thePeople.AddComponent<Hero>(); // Se le agregan los componentes de la clase Hero.
                    thePeople.AddComponent<HeroAim>(); // Igualmente se le agregan los componentes de HeroAim.
                    thePeople.GetComponent<Renderer>().material.color = Color.black; // Se le asignó color negro para diferenciarlos de otros objetos.
                }

                else
                {
                    switch (change) // La primera posibilidad del Random genera los zombies, la segunda los aldeanos.
                    {
                        case 0:
                            thePeople.AddComponent<NPC.Enemy.Zombie>(); // Se agregan los componentes de su respectiva clase.
                            break;
                        case 1:
                            thePeople.AddComponent<NPC.Ally.Villagers>(); // Se agregan los componentes de su respectiva clase. 
                            break;
                    }
                }
            }
        }

        
    }   

    public class minGenerator
    {
        int minGen = Random.Range(5, 15);
        public minGenerator(int g)
        {
            this.minGen = g;
            minGen = Random.Range(5, 15);
        }
    }
}

