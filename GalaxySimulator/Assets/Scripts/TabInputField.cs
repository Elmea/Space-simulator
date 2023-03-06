using UnityEngine;
using TMPro;

public class TabInputField : MonoBehaviour
{
    //Pos
    public TMP_InputField PosXInput;
    public TMP_InputField PosYInput;
    public TMP_InputField PosZInput;

    //InitialSpeed
    public TMP_InputField SpeedXInput;
    public TMP_InputField SpeedYInput;
    public TMP_InputField SpeedZInput;

    //Mass
    public TMP_InputField MassInput;

    //Name
    public TMP_InputField NameInput;

    public int InputSelected;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            InputSelected++;
            if (InputSelected < 7) 
                InputSelected = 0;
            SelectInputField();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InputSelected++;
            if (InputSelected > 7) 
                InputSelected = 0;
            SelectInputField();
        }



        void SelectInputField()
        {
            switch(InputSelected)
            {
                case 0: PosXInput.Select();break;
                case 1: PosYInput.Select(); break;
                case 2: PosZInput.Select(); break;
                case 3: SpeedXInput.Select(); break;
                case 4: SpeedYInput.Select(); break;
                case 5: SpeedZInput.Select(); break;
                case 6: MassInput.Select(); break;
                case 7: NameInput.Select(); break;
            }
        }
    }
}
