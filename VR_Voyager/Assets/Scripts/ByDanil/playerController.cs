using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    public SlowMotion SlowMotion;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("bullet"))
        {
            SlowMotion.Normalise();
            SceneManager.LoadScene(1);
        }
    }
}
