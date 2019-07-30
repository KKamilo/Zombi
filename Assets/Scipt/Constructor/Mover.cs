using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{ 
    //declaracion de variables
    float ejeX;
    float speed = 5;
    public float fuersa = 250f;
    public bool canJump = false;
    //Enemigo
    

    void Start()
    {
        int num = Random.Range(4, 10);// da un numero ramdon para la creacion de Aldeanos y enemigos
        for (int i = 0; i < num; i++)
        {
            int bi = Random.Range(0, 2); // selecciona aleatoria mente que se crea
            if (bi==0)
            {
                Aldeanos persona = new Aldeanos();

            }
            else
            {
                Enemigos mostro = new Enemigos(0,10);

            }
        }
    }

    void Update()
    { // Comandos para el movimieno en el eje X,Z
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
            canJump = false;
        }
        ejeX += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0, ejeX, 0);
    }
    public class Enemigos
    {
        //Costructor de enemigos y colocacion en el mapa

        string nom;
        int hambre;
        int attack;
        int colores = Random.Range(1, 4);
        public Enemigos(int hambre, int attack)
        {
            GameObject enemi = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Vector3 v = new Vector3();
            v.x = Random.Range(5, 50);
            v.z = Random.Range(5, 50);
            enemi.transform.position = v;

            this.attack = attack;
            this.hambre = hambre;
            string color = "";
            switch (colores)
            {
                case 1:
                    enemi.GetComponent<Renderer>().material.color = Color.cyan;
                    color = "Cyan";
                    break;
                case 2:
                    enemi.GetComponent<Renderer>().material.color = Color.green;
                    color = "Green";
                    break;
                case 3:
                    enemi.GetComponent<Renderer>().material.color = Color.magenta;
                    color = "Magenta";
                    break;
            }
            Debug.Log(Zomvi(color));
        }
        string Zomvi(string color)
        {
            return "Soy un zombi de color " + color;
        }
    }
    public class Aldeanos
    {
        //Costructor de aldeanos y colocacion en el mapa
        public Aldeanos()
        {
            GameObject npc = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Vector3 v = new Vector3();
            v.x = Random.Range(5, 50);
            v.z = Random.Range(5, 50);
            npc.transform.position = v;
            Debug.Log(Nombres());
        }
        string Nombres()
        {
            string[] name = new string[20];
            int id= Random.Range(0,20);
            int años = Random.Range(15, 101);
            name[0] = ("Krooth");
            name[1] = ("Zacot");
            name[2] = ("Skooth ");
            name[3] = ("Griath");
            name[4] = ("Arait ");
            name[5] = ("Catinius");
            name[6] = ("Conbertus");
            name[7] = ("Ambilos");
            name[8] = ("Divicatus");
            name[9] = ("Centus");
            name[10] = ("Donnius");
            name[11] = ("Cenno");
            name[12] = ("Cotto");
            name[13] = ("Ambisavus");
            name[14] = ("Tritó");
            name[15] = ("Vírico");
            name[16] = ("Litugena");
            name[17] = ("Epasius");
            name[18] = ("Epia");
            name[19] = ("Regula");
            return "Hola me llamo " + name[id] + " y tengo " + años + " años";
        }
    }
    void Jump()
    {
        if (canJump)
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * fuersa);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name== "Terreno")
        {
            canJump = true;
        }
    }
}