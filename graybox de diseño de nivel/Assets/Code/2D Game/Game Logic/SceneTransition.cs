using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public string SceneToLoad;

    public void Loadscene()
    {
        SceneManager.LoadSceneAsync(SceneToLoad);
    }
    public void Quit()
    { }
}