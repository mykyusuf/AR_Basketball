using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play2Button : MonoBehaviour {

    public void ChangeScene()
    {
        SceneManager.LoadScene("hardSc");
    }
}
