using System.Collections.Generic;
using UnityEngine;

public class PageNavigator : MonoBehaviour
{
    [Header("Arrastra aquí tus páginas en orden (0 = Inicio)")]
    public List<GameObject> pages = new List<GameObject>();

    [Header("Opciones")]
    public int startIndex = 0;     // cuál página mostrar al iniciar
    public bool loop = false;      // si true, al llegar al final vuelve a la primera

    int current;

    void Awake()
    {
        // Seguridad: si no hay páginas, no hacemos nada
        if (pages == null || pages.Count == 0) return;

        // Asegura que solo la página inicial esté activa
        current = Mathf.Clamp(startIndex, 0, pages.Count - 1);
        ShowOnly(current);
    }

    // Llamar desde botón "Siguiente"
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

    // Llamar desde botón "Anterior"
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

    // Llamar desde botón "Inicio"
    public void GoHome()
    {
        if (pages.Count == 0) return;
        ShowOnly(0);
    }

    // Si quieres ir a un índice específico desde algún botón/menú
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
