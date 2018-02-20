using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager control;

    //EVENTS AND DELEGATES
    public delegate void OpnAxis(float level);
    public static event OpnAxis Hori = delegate { };
    public static event OpnAxis Vert = delegate { };

    public delegate void OpenBtns(int level);
    public static event OpenBtns SubB = delegate { };
    public static event OpenBtns CanB = delegate { };
    public static event OpenBtns Slct = delegate { };
    public static event OpenBtns Back = delegate { };

    public delegate void GetAxis(int controller, float level);
    public static event GetAxis Main_X = delegate { };
    public static event GetAxis Main_Y = delegate { };
    public static event GetAxis Scnd_X = delegate { };
    public static event GetAxis Scnd_Y = delegate { };
    public static event GetAxis Auxl_X = delegate { };
    public static event GetAxis Auxl_Y = delegate { };

    public delegate void Trigger(int controller, int level);
    public static event Trigger LfTrig = delegate { };
    public static event Trigger RtTrig = delegate { };

    public delegate void Buttons(int controller, int level);
    public static event Buttons StrtBn = delegate { };
    public static event Buttons BackBn = delegate { };
    public static event Buttons LfBump = delegate { };
    public static event Buttons RtBump = delegate { };
    public static event Buttons LfClik = delegate { };
    public static event Buttons RtClik = delegate { };
    public static event Buttons UpperB = delegate { };
    public static event Buttons OuterB = delegate { };
    public static event Buttons LowerB = delegate { };
    public static event Buttons InnerB = delegate { };

    //Controller One Variables
    private float js1_leftThumbX;
    private float js1_leftThumbY;
    private float js1_riteThumbX;
    private float js1_riteThumbY;
    private float js1_directionX;
    private float js1_directionY;

    private bool js1_leftTrgUse;
    private bool js1_riteTrgUse;

    private bool js1_strtButton;
    private bool js1_backButton;
    private bool js1_leftBumper;
    private bool js1_riteBumper;
    private bool js1_leftClickB;
    private bool js1_riteClickB;
    private bool js1_upperButtn;
    private bool js1_otterButtn;
    private bool js1_lowerButtn;
    private bool js1_innerButtn;
    //Controller Two Variables
    private float js2_leftThumbX;
    private float js2_leftThumbY;
    private float js2_riteThumbX;
    private float js2_riteThumbY;
    private float js2_directionX;
    private float js2_directionY;

    private bool js2_leftTrgUse;
    private bool js2_riteTrgUse;

    private bool js2_strtButton;
    private bool js2_backButton;
    private bool js2_leftBumper;
    private bool js2_riteBumper;
    private bool js2_leftClickB;
    private bool js2_riteClickB;
    private bool js2_upperButtn;
    private bool js2_otterButtn;
    private bool js2_lowerButtn;
    private bool js2_innerButtn;

    //Manager Variables
    private int joystickCount;
    private int joystickOne;
    private int joystickTwo;
    private bool multiplayer;

    private void Awake()
    {
        if (control == null) { control = this; }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        CountJoysticks();
        InitializeJoystickOne();
        InitializeJoystickTwo();
    }

    private void Update()
    {
        GetInputs();
        SendInputs();
    }

    private void CountJoysticks() { joystickCount = Input.GetJoystickNames().Length; }
    private void InitializeJoystickOne()
    {
        if (joystickCount == 0)
        {
            joystickOne = 1;
        }
        else if (joystickCount > 0)
        {
            if (Input.GetJoystickNames()[0] == "Controller (Xbox One For Windows)")
            {
                joystickOne = 2;
            }
            else if (Input.GetJoystickNames()[0] == "Logitech Dual Action")
            {
                joystickOne = 3;
            }
            else
            {
                joystickOne = 1;
            }
        }
    }
    private void InitializeJoystickTwo()
    {
        if (joystickCount < 2)
        {
            joystickTwo = 1; 
        }
        else if (joystickCount >= 2)
        {
            if (Input.GetJoystickNames()[1] == "Controller (Xbox One For Windows)")
            {
                joystickTwo = 2;
            }
            else if (Input.GetJoystickNames()[1] == "Logitech Dual Action")
            {
                joystickTwo = 3;
            }
            else
            {
                joystickTwo = 1;
            }
        }
    }

    private void GetInputs()
    {
        /*
        JOYSTICK CODE KEY:
            0 = off or unrecognized
            1 = keyboard
            2 = Xbox One for Windows
            3 = Logitech Dual Action
        
        NOTE: joystickOne is not necessarily player one
         */

        //Joystick 1
        if (joystickOne == 0)
        {
            GameManager.ErrorDetected(0001);
        }
        else if (joystickOne == 1)
        {
            js1_leftThumbX = Input.GetAxis("KBAxis1x");
            js1_leftThumbY = Input.GetAxis("KBAxis1y");
            js1_riteThumbX = Input.GetAxis("KBAxis2x");
            js1_riteThumbY = Input.GetAxis("KBAxis2y");
            js1_directionX = Input.GetAxis("KBAxis3x");
            js1_directionY = Input.GetAxis("KBAxis3y");
            js1_leftTrgUse = Input.GetButton("KB_LTrig");
            js1_riteTrgUse = Input.GetButton("KB_RTrig");
            js1_strtButton = Input.GetButtonDown("KB_Start");
            js1_backButton = Input.GetButtonDown("KB_BackB");
            js1_leftBumper = Input.GetButton("KB_LBump");
            js1_riteBumper = Input.GetButton("KB_RBump");
            js1_leftClickB = Input.GetButton("KB_LClik");
            js1_riteClickB = Input.GetButton("KB_RClik");
            js1_upperButtn = Input.GetButton("KB_Bttn1");
            js1_otterButtn = Input.GetButton("KB_Bttn2");
            js1_lowerButtn = Input.GetButton("KB_Bttn3");
            js1_innerButtn = Input.GetButton("KB_Bttn4");
        }
        else if (joystickOne == 2)
        {
            js1_leftThumbX = Input.GetAxis("Axis01_1");
            js1_leftThumbY = Input.GetAxis("Axis02_1");
            js1_riteThumbX = Input.GetAxis("Axis04_1");
            js1_riteThumbY = Input.GetAxis("Axis05_1");
            js1_directionX = Input.GetAxis("Axis06_1");
            js1_directionY = Input.GetAxis("Axis07_1");

            if (Input.GetAxisRaw("Axis09_1") != 0) { js1_leftTrgUse = true; }
            else { js1_leftTrgUse = false; }

            if (Input.GetAxisRaw("Axis10_1") != 0) { js1_riteTrgUse = true; }
            else { js1_riteTrgUse = false; }

            js1_strtButton = Input.GetButtonDown("Bttn07_1");
            js1_backButton = Input.GetButtonDown("Bttn06_1");
            js1_leftBumper = Input.GetButton("Bttn04_1");
            js1_riteBumper = Input.GetButton("Bttn05_1");
            js1_leftClickB = Input.GetButton("Bttn08_1");
            js1_riteClickB = Input.GetButton("Bttn09_1");
            js1_upperButtn = Input.GetButton("Bttn03_1");
            js1_otterButtn = Input.GetButton("Bttn01_1");
            js1_lowerButtn = Input.GetButton("Bttn00_1");
            js1_innerButtn = Input.GetButton("Bttn02_1");
        }
        else if (joystickOne == 3)
        {
            js1_leftThumbX = Input.GetAxis("Axis01_1");
            js1_leftThumbY = Input.GetAxis("Axis02_1");
            js1_riteThumbX = Input.GetAxis("Axis03_1");
            js1_riteThumbY = Input.GetAxis("Axis04_1");
            js1_directionX = Input.GetAxis("Axis05_1");
            js1_directionY = Input.GetAxis("Axis06_1");
            js1_leftTrgUse = Input.GetButton("Bttn06_1");
            js1_riteTrgUse = Input.GetButton("Bttno7_1");
            js1_strtButton = Input.GetButtonDown("Bttn09_1");
            js1_backButton = Input.GetButtonDown("Bttn08_1");
            js1_leftBumper = Input.GetButton("Bttn04_1");
            js1_riteBumper = Input.GetButton("Bttn05_1");
            js1_leftClickB = Input.GetButton("Bttn10_1");
            js1_riteClickB = Input.GetButton("Bttn11_1");
            js1_upperButtn = Input.GetButton("Bttn03_1");
            js1_otterButtn = Input.GetButton("Bttn02_1");
            js1_lowerButtn = Input.GetButton("Bttn01_1");
            js1_innerButtn = Input.GetButton("Bttn00_1");
        }
        
        //Joystick 2
        if (joystickTwo == 0)
        {
            js2_leftThumbX = 0;
            js2_leftThumbY = 0;
            js2_riteThumbX = 0;
            js2_riteThumbY = 0;
            js2_directionX = 0;
            js2_directionY = 0;
            js2_leftTrgUse = false;
            js2_riteTrgUse = false;
            js2_strtButton = false;
            js2_backButton = false;
            js2_leftBumper = false;
            js2_riteBumper = false;
            js2_leftClickB = false;
            js2_riteClickB = false;
            js2_upperButtn = false;
            js2_otterButtn = false;
            js2_lowerButtn = false;
            js2_innerButtn = false;
        }
        else if (joystickTwo == 1)
        {
            js2_leftThumbX = Input.GetAxis("KBAxis1x");
            js2_leftThumbY = Input.GetAxis("KBAxis1y");
            js2_riteThumbX = Input.GetAxis("KBAxis2x");
            js2_riteThumbY = Input.GetAxis("KBAxis2y");
            js2_directionX = Input.GetAxis("KBAxis3x");
            js2_directionY = Input.GetAxis("KBAxis3y");
            js2_leftTrgUse = Input.GetButton("KB_LTrig");
            js2_riteTrgUse = Input.GetButton("KB_RTrig");
            js2_strtButton = Input.GetButtonDown("KB_Start");
            js2_backButton = Input.GetButtonDown("KB_BackB");
            js2_leftBumper = Input.GetButton("KB_LBump");
            js2_riteBumper = Input.GetButton("KB_RBump");
            js2_leftClickB = Input.GetButton("KB_LClik");
            js2_riteClickB = Input.GetButton("KB_RClik");
            js2_upperButtn = Input.GetButton("KB_Bttn1");
            js2_otterButtn = Input.GetButton("KB_Bttn2");
            js2_lowerButtn = Input.GetButton("KB_Bttn3");
            js2_innerButtn = Input.GetButton("KB_Bttn4");
        }
        else if (joystickTwo == 2)
        {
            js2_leftThumbX = Input.GetAxis("Axis01_2");
            js2_leftThumbY = Input.GetAxis("Axis02_2");
            js2_riteThumbX = Input.GetAxis("Axis04_2");
            js2_riteThumbY = Input.GetAxis("Axis05_2");
            js2_directionX = Input.GetAxis("Axis06_2");
            js2_directionY = Input.GetAxis("Axis07_2");

            if (Input.GetAxisRaw("Axis09_2") != 0) { js2_leftTrgUse = true; }
            else { js2_leftTrgUse = false; }

            if (Input.GetAxisRaw("Axis10_2") != 0) { js2_riteTrgUse = true; }
            else { js2_riteTrgUse = false; }

            js2_strtButton = Input.GetButtonDown("Bttn07_2");
            js2_backButton = Input.GetButtonDown("Bttn06_2");
            js2_leftBumper = Input.GetButton("Bttn04_2");
            js2_riteBumper = Input.GetButton("Bttn05_2");
            js2_leftClickB = Input.GetButton("Bttn08_2");
            js2_riteClickB = Input.GetButton("Bttn09_2");
            js2_upperButtn = Input.GetButton("Bttn03_2");
            js2_otterButtn = Input.GetButton("Bttn01_2");
            js2_lowerButtn = Input.GetButton("Bttn00_2");
            js2_innerButtn = Input.GetButton("Bttn02_2");
        }
        else if (joystickTwo == 3)
        {
            js2_leftThumbX = Input.GetAxis("Axis01_2");
            js2_leftThumbY = Input.GetAxis("Axis02_2");
            js2_riteThumbX = Input.GetAxis("Axis03_2");
            js2_riteThumbY = Input.GetAxis("Axis04_2");
            js2_directionX = Input.GetAxis("Axis05_2");
            js2_directionY = Input.GetAxis("Axis06_2");
            js2_leftTrgUse = Input.GetButton("Bttn06_2");
            js2_riteTrgUse = Input.GetButton("Bttno7_2");
            js2_strtButton = Input.GetButtonDown("Bttn09_2");
            js2_backButton = Input.GetButtonDown("Bttn08_2");
            js2_leftBumper = Input.GetButton("Bttn04_2");
            js2_riteBumper = Input.GetButton("Bttn05_2");
            js2_leftClickB = Input.GetButton("Bttn10_2");
            js2_riteClickB = Input.GetButton("Bttn11_2");
            js2_upperButtn = Input.GetButton("Bttn03_2");
            js2_otterButtn = Input.GetButton("Bttn02_2");
            js2_lowerButtn = Input.GetButton("Bttn01_2");
            js2_innerButtn = Input.GetButton("Bttn00_2");
        }
    }
    private void SendInputs()
    {
        //Open axis
        if (Input.GetAxisRaw("Horizontal") != 0)    { Hori(Input.GetAxisRaw("Horizontal")); }
        if (js1_directionX != 0)                    { Hori(js1_directionX); }
        if (js2_directionX != 0)                    { Hori(js2_directionX); }
        if (Input.GetAxisRaw("Vertical") != 0)      { Vert(Input.GetAxisRaw("Vertical")); }
        if (js1_directionY != 0)                    { Vert(js1_directionY); }
        if (js2_directionY != 0)                    { Vert(js2_directionY); }
        //Open buttons
        if (Input.GetButtonDown("Submit")) { SubB(1); } else if (!Input.GetButtonDown("Submit")) { SubB(0); }
        if (Input.GetButtonDown("Cancel")) { CanB(1); } else if (!Input.GetButtonDown("Cancel")) { CanB(0); }
        if (Input.GetKeyDown("1")) { Slct(1); } else if (!Input.GetKeyDown("1")) { Slct(0); }
        if (js1_lowerButtn) { Slct(1); } else if (!js1_lowerButtn) { Slct(0); }
        if (js2_lowerButtn) { Slct(1); } else if (!js2_lowerButtn) { Slct(0); }
        if (Input.GetKeyDown("0")) { Back(1); } else if (Input.GetKeyDown("0")) { Back(0); }
        if (js1_innerButtn) { Back(1); } else if (!js1_innerButtn) { Back(0); }
        if (js2_innerButtn) { Back(1); } else if (!js2_innerButtn) { Back(0); }

        //Joystick 1 axis
        Main_X(1, js1_leftThumbX);
        Main_Y(1, js1_leftThumbY);
        Scnd_X(1, js1_riteThumbX);
        Scnd_Y(1, js1_riteThumbY);
        Auxl_X(1, js1_directionX);
        Auxl_Y(1, js1_directionY);
        //Joystick 1 triggers
        if (js1_leftTrgUse) { LfTrig(1, 1); }   else if (!js1_leftTrgUse) { LfTrig(1, 0); }
        if (js1_riteTrgUse) { RtTrig(1, 1); }   else if (!js1_riteTrgUse) { RtTrig(1, 0); }
        //Joystick 1 Buttons
        if (js1_strtButton) { StrtBn(1, 1); }   else if (!js1_strtButton) { StrtBn(1, 0); }
        if (js1_backButton) { BackBn(1, 1); }   else if (!js1_backButton) { BackBn(1, 0); }
        if (js1_leftBumper) { LfBump(1, 1); }   else if (!js1_leftBumper) { LfBump(1, 0); }
        if (js1_riteBumper) { RtBump(1, 1); }   else if (!js1_riteBumper) { RtBump(1, 0); }
        if (js1_leftClickB) { LfClik(1, 1); }   else if (!js1_leftClickB) { LfClik(1, 0); }
        if (js1_riteClickB) { RtClik(1, 1); }   else if (!js1_riteClickB) { RtClik(1, 0); }
        if (js1_upperButtn) { UpperB(1, 1); }   else if (!js1_upperButtn) { UpperB(1, 0); }
        if (js1_otterButtn) { OuterB(1, 1); }   else if (!js1_otterButtn) { OuterB(1, 0); }
        if (js1_lowerButtn) { LowerB(1, 1); }   else if (!js1_lowerButtn) { LowerB(1, 0); }
        if (js1_innerButtn) { InnerB(1, 1); }   else if (!js1_innerButtn) { InnerB(1, 0); }

        //Joystick 2 axis
        Main_X(2, js2_leftThumbX);
        Main_Y(2, js2_leftThumbY);
        Scnd_X(2, js2_riteThumbX);
        Scnd_Y(2, js2_riteThumbY);
        Auxl_X(2, js2_directionX);
        Auxl_Y(2, js2_directionY);
        //Joystick 2 triggers
        if (js2_leftTrgUse) { LfTrig(2, 1); }   else if (!js2_leftTrgUse) { LfTrig(2, 0); }
        if (js2_riteTrgUse) { RtTrig(2, 1); }   else if (!js2_riteTrgUse) { RtTrig(2, 0); }
        //Joystick 2 Buttons
        if (js2_strtButton) { StrtBn(2, 1); }   else if (!js2_strtButton) { StrtBn(2, 0); }
        if (js2_backButton) { BackBn(2, 1); }   else if (!js2_backButton) { BackBn(2, 0); }
        if (js2_leftBumper) { LfBump(2, 1); }   else if (!js2_leftBumper) { LfBump(2, 0); }
        if (js2_riteBumper) { RtBump(2, 1); }   else if (!js2_riteBumper) { RtBump(2, 0); }
        if (js2_leftClickB) { LfClik(2, 1); }   else if (!js2_leftClickB) { LfClik(2, 0); }
        if (js2_riteClickB) { RtClik(2, 1); }   else if (!js2_riteClickB) { RtClik(2, 0); }
        if (js2_upperButtn) { UpperB(2, 1); }   else if (!js2_upperButtn) { UpperB(2, 0); }
        if (js2_otterButtn) { OuterB(2, 1); }   else if (!js2_otterButtn) { OuterB(2, 0); }
        if (js2_lowerButtn) { LowerB(2, 1); }   else if (!js2_lowerButtn) { LowerB(2, 0); }
        if (js2_innerButtn) { InnerB(2, 1); }   else if (!js2_innerButtn) { InnerB(2, 0); }
    }
}

