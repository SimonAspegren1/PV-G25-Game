using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public void Endgame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Restart();
        }
    }

    void Restart ()
    {
        SceneManager.Loadscene(SceneManager.GetActiveScene().name);
    }
}
