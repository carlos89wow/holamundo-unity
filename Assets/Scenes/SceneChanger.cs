using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Llama esta función desde un botón y pasa el nombre de la escena
    public void CargarEscena(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }
}
