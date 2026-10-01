using UnityEngine;
using UnityEngine.InputSystem; //para hacer uso del input system de Unity, para los controles de movimiento del jugador

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 5f; //variable para almacenar la cantidad de inclinación que se aplicará al jugador
    InputAction moveAction; //variable para almacenar la acción de movimiento del jugador
    Vector2 moveInput; //variable para almacenar la entrada de movimiento del jugador
    Rigidbody2D rb; //variable para almacenar el componente Rigidbody del jugador
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move"); //busca la acción de movimiento en el Input System       
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerTorque(); //llama a la función PlayerTorque para aplicar la inclinación al jugador

    }
    void PlayerTorque()
    /// <summary>
    /// Aplica una fuerza de torque al jugador en función de la entrada de movimiento del jugador
    /// </summary>
    {
        moveInput = moveAction.ReadValue<Vector2>(); //lee la entrada de movimiento del jugador y la almacena en la variable moveInput
        // Debug.Log("Move Input: " + moveInput); //es lo mismo que la linea de abajo, pero la de abajo es más profesional.
        Debug.Log($"Move Input: {moveInput} " ); //muestra en la consola la entrada de movimiento del jugador
        if (moveInput.x < 0) //si la entrada de movimiento del jugador es menor que 0, significa que el jugador está moviéndose hacia la izquierda
        {
            rb.AddTorque(torqueAmount); //aplica una fuerza de torque al jugador en función de la entrada de movimiento del jugador
        }
        else if (moveInput.x > 0) //si la entrada de movimiento del jugador es mayor que 0, significa que el jugador está moviéndose hacia la derecha
        {
            rb.AddTorque(-torqueAmount);
        }
    }
}
