using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField]GameEvent Back;
    public void butotnPress()
    {
        Back.Raise();
    }
}
