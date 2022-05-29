using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLvl(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }
}
