using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Llama esta funci�n desde un bot�n y pasa el nombre de la escena
    public void CargarEscena(string SampleScene)
    {
        SceneManager.LoadScene(SampleScene);
    }
}
