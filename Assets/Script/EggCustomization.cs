using UnityEngine;

public class EggCustomization : MonoBehaviour
{
    [Header("Obras de cada huevo")]
    public SpriteRenderer obraFuego;
    public SpriteRenderer obraRoca;
    public SpriteRenderer obraPlanta;
    public SpriteRenderer obraAgua;
    public SpriteRenderer obraAire;

    [Header("Imagenes de los dragones")]
    public Sprite[] dragones;

    public void CambiarFuego(int opcion)
    {
        obraFuego.sprite = dragones[opcion];
    }

    public void CambiarRoca(int opcion)
    {
        obraRoca.sprite = dragones[opcion];
    }

    public void CambiarPlanta(int opcion)
    {
        obraPlanta.sprite = dragones[opcion];
    }

    public void CambiarAgua(int opcion)
    {
        obraAgua.sprite = dragones[opcion];
    }

    public void CambiarAire(int opcion)
    {
        obraAire.sprite = dragones[opcion];
    }
}