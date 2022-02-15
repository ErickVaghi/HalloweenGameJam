using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private ControlContainer myControlContainer;
    
    public bool FlyInput { get; private set; }
    public bool DashInput { get; private set; }
    
    void Update()
    {
        GetInput();
        SetCommands();
    }

    void GetInput()
    {
        FlyInput = Input.GetKey(KeyCode.Space);
        DashInput = Input.GetKeyDown(KeyCode.LeftShift);
    }
    void SetCommands()
    {
        myControlContainer.flyController = FlyInput;
        myControlContainer.dashController = DashInput;
    }
}
