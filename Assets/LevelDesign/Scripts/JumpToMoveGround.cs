using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToMoveGround : MonoBehaviour
{
    private bool bRotate = false;
    private int TarValue = -90;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.localEulerAngles.x);

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            bRotate = true;
        }
        if (bRotate == true)
        {
            this.transform.Rotate(0, TarValue / -20.5f, 0);
            if(TarValue == -90 && (this.transform.localEulerAngles.x <= 271 && this.transform.localEulerAngles.x >= 269))
            {
                bRotate = false;
                TarValue = 90;
            }
            else if (TarValue == 90 && (this.transform.localEulerAngles.x <= 91 && this.transform.localEulerAngles.x >= 90))
            {
                bRotate = false;
                TarValue = -90;
            }
        }
    }
}
