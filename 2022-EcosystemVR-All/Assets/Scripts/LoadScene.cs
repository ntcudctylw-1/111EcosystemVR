using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void GoToScene(int i) => SceneManager.LoadScene(i);
    
    public void GoToScene(string i) => SceneManager.LoadScene(i);
}
