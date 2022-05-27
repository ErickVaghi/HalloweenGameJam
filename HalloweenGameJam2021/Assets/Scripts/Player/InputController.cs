using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private CommandContainer myControlContainer;
    
    public bool FlyInput { get; private set; }
    public bool DashInput { get; private set; }
    
    public float MoveInput { get; set; }
    
    void Update()
    {
        GetInput();
        SetCommands();
    }

    void GetInput()
    {
        MoveInput = Input.GetAxis("Horizontal");
        
        FlyInput = Input.GetKey(KeyCode.Space);
        DashInput = Input.GetKeyDown(KeyCode.LeftShift);
    }
    void SetCommands()
    {
        myControlContainer.flyCommand = FlyInput;
        myControlContainer.dashCommand = DashInput;
        myControlContainer.moveCommand = MoveInput;
    }
}
