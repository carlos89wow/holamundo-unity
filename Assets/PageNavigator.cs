using System.Collections.Generic;
using UnityEngine;

public class PageNavigator : MonoBehaviour
{
    [Header("Arrastra aqu� tus p�ginas en orden (0 = Inicio)")]
    public List<GameObject> pages = new List<GameObject>();

    [Header("Opciones")]
    public int startIndex = 0;     // cu�l p�gina mostrar al iniciar
    public bool loop = false;      // si true, al llegar al final vuelve a la primera

    int current;

    void Awake()
    {
        // Seguridad: si no hay p�ginas, no hacemos nada
        if (pages == null || pages.Count == 0) return;

        // Asegura que solo la p�gina inicial est� activa
        current = Mathf.Clamp(startIndex, 0, pages.Count - 1);
        ShowOnly(current);
    }

    // Llamar desde bot�n "Siguiente"
    public void NextPage()
    {
        if (pages.Count == 0) return;
        int next = current + 1;
        if (next >= pages.Count)
        {
            if (!loop) return;     // no avanzamos si no hay loop
            next = 0;
        }
        ShowOnly(next);
    }

    // Llamar desde bot�n "Anterior"
    public void PreviousPage()
    {
        if (pages.Count == 0) return;
        int prev = current - 1;
        if (prev < 0)
        {
            if (!loop) return;
            prev = pages.Count - 1;
        }
        ShowOnly(prev);
    }

    // Llamar desde bot�n "Inicio"
    public void GoHome()
    {
        if (pages.Count == 0) return;
        ShowOnly(0);
    }

    // Si quieres ir a un �ndice espec�fico desde alg�n bot�n/men�
    public void GoTo(int index)
    {
        if (pages.Count == 0) return;
        index = Mathf.Clamp(index, 0, pages.Count - 1);
        ShowOnly(index);
    }

    void ShowOnly(int index)
    {
        for (int i = 0; i < pages.Count; i++)
            if (pages[i]) pages[i].SetActive(i == index);

        current = index;
    }
}
