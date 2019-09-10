using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DeleteWorld : MonoBehaviour
{
    public void DeleteWorld1()
    {
        if (File.Exists(Application.persistentDataPath + ConstVariables.world1Path))
        {
            File.Delete(Application.persistentDataPath + ConstVariables.world1Path);
        }
    }

    public void DeleteWorld2()
    {
        if (File.Exists(Application.persistentDataPath + ConstVariables.world2Path))
        {
            File.Delete(Application.persistentDataPath + ConstVariables.world2Path);
        }
    }

    public void DeleteWorld3()
    {
        if (File.Exists(Application.persistentDataPath + ConstVariables.world3Path))
        {
            File.Delete(Application.persistentDataPath + ConstVariables.world3Path);
        }
    }
}
