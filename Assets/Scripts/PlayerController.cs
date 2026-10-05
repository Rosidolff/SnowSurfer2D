using UnityEngine;
using UnityEngine.InputSystem; //para hacer uso del input system de Unity, para los controles de movimiento del jugador

public class PlayerController : MonoBehaviour
{

    SurfaceEffector2D surfaceEffector2D;
    float baseSpeed; //variable para almacenar la velocidad base del jugador
    [SerializeField] private float boostSpeed = 30f; //variable para almacenar la velocidad del jugador cuando se activa el impulso
    [SerializeField] private float torqueAmount = 5f; //variable para almacenar la cantidad de inclinación que se aplicará al jugador

    InputAction moveAction; //variable para almacenar la acción de movimiento del jugador
    Vector2 moveInput; //variable para almacenar la entrada de movimiento del jugador
    Rigidbody2D rb; //variable para almacenar el componente Rigidbody del jugador

    [SerializeField] private ParticleSystem snowEffect;
    [SerializeField] private ParticleSystem boostEffect;

    private bool canControlPlayer = true; // Bandera ara ver si podemos controlar el pj o no. Control + . crea un getter y setter para la variable canControlPlayer
    public bool CanControlPlayer { get => canControlPlayer; set => canControlPlayer = value; }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move"); //busca la acción de movimiento en el Input System       
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = Object.FindAnyObjectByType<SurfaceEffector2D>(); 
        baseSpeed = surfaceEffector2D.speed; //guarda la velocidad incial en el baseSpeed
    }

    void Update()
    {
        if (!canControlPlayer) return; //si no podemos controlar el jugador, salimos de la función Update
        PlayerTorque(); //llama a la función PlayerTorque para aplicar la inclinación al jugador
        BoostPlayer(); // para el impulso
    }

    /// <summary>
    /// Aplica una fuerza de torque al jugador en función de la entrada de movimiento del jugador
    /// </summary>
    void PlayerTorque()
    
    {
        moveInput = moveAction.ReadValue<Vector2>(); //lee la entrada de movimiento del jugador y la almacena en la variable moveInput
        // Debug.Log("Move Input: " + moveInput); //es lo mismo que la linea de abajo, pero la de abajo es más profesional.
        // Debug.Log($"Move Input: {moveInput} " ); //muestra en la consola la entrada de movimiento del jugador
        if (moveInput.x < 0) //si la entrada de movimiento del jugador es menor que 0, significa que el jugador está moviéndose hacia la izquierda
        {
            rb.AddTorque(torqueAmount); //aplica una fuerza de torque al jugador en función de la entrada de movimiento del jugador
        }
        else if (moveInput.x > 0) //si la entrada de movimiento del jugador es mayor que 0, significa que el jugador está moviéndose hacia la derecha
        {
            rb.AddTorque(-torqueAmount);
        }
    }
    void BoostPlayer()
    {
        if (moveInput.y > 0) //si la entrada de movimiento del jugador es mayor que 0, significa que el jugador está moviéndose hacia arriba
        {
            surfaceEffector2D.speed = boostSpeed; //aumenta la velocidad del jugador
            boostEffect.Play();
        } 
        else
        {
            surfaceEffector2D.speed = baseSpeed; //restaura la velocidad del jugador   
            boostEffect.Stop(); 
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            snowEffect.Play();
         }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            snowEffect.Stop();
         }
    }
}
