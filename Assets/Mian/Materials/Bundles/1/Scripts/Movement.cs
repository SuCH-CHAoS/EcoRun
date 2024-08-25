using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Transform Player;
    public SwipeControls Controls;

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

    private void Start()
    {
        Player = GetComponent<Transform>();
    }

    private void Update()
    {
        // Move the player between lanes based on their current position
        if (Lane3 && Player.position.z < 1.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if (Lane1 && Player.position.z > -1.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }
        else if (Lane2 && Player.position.z <= -0.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if (Lane2 && Player.position.z >= 0.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }

        // Change lane based on swipe input from the controls (A and D keys)
        #region ChangeLanes
        // Move from Lane1 to Lane2 (Swipe Right, D Key)
        if (Controls.SwipeRight && Lane3 == false && Lane1)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        // Move from Lane2 to Lane1 (Swipe Left, A Key)
        else if (Controls.SwipeLeft && Lane2 && Player.position.z <= 0.2f)
        {
            Lane1 = true;
            Lane2 = false;
            Lane3 = false;
        }
        // Move from Lane2 to Lane3 (Swipe Right, D Key)
        else if (Controls.SwipeRight && Lane2 && Player.position.z >= -0.2f)
        {
            Lane3 = true;
            Lane1 = false;
            Lane2 = false;
        }
        // Move from Lane3 to Lane2 (Swipe Left, A Key)
        else if (Controls.SwipeLeft && Lane1 == false && Lane3)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        #endregion
    }
}
