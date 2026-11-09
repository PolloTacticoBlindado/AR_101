
using UnityEngine;

public class HuevoInteractivo : MonoBehaviour
{
    public GameObject obra;
    public Camera arCamera;

    public int golpesNecesarios = 3;

    private int golpes = 0;
    private bool abierto = false;
    private Vector3 escalaOriginal;
    private string mensaje = "Esperando toque...";

    void Start()
    {
        escalaOriginal = transform.localScale;

        if (arCamera == null)
            arCamera = Camera.main;
    }

    void Update()
    {
        if (abierto || arCamera == null)
            return;

        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            if (toque.phase == TouchPhase.Began)
                DetectarToque(toque.position);
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            DetectarToque(Input.mousePosition);
#endif
    }

    void DetectarToque(Vector2 posicion)
    {
        mensaje = "Pantalla tocada";

        Ray rayo = arCamera.ScreenPointToRay(posicion);

        RaycastHit[] impactos = Physics.RaycastAll(rayo);

        foreach (RaycastHit impacto in impactos)
        {
            Transform objeto = impacto.collider.transform;

            if (objeto == transform ||
                objeto.IsChildOf(transform))
            {
                golpes++;
                mensaje = "Golpes: " + golpes;

                Debug.Log(mensaje);

                CancelInvoke(nameof(RestaurarEscala));

                transform.localScale = escalaOriginal * 0.9f;

                Invoke(nameof(RestaurarEscala), 0.15f);

                if (golpes >= golpesNecesarios)
                {
                    abierto = true;
                    mensaje = "Huevo abierto";

                    if (obra != null)
                        obra.SetActive(true);

                    gameObject.SetActive(false);
                }

                return;
            }
        }

        mensaje = "Toque fuera del huevo";
    }

    void RestaurarEscala()
    {
        transform.localScale = escalaOriginal;
    }

    void OnGUI()
    {
        GUIStyle estilo = new GUIStyle(GUI.skin.box);
        estilo.fontSize = 28;
        estilo.alignment = TextAnchor.MiddleCenter;

        GUI.Box(
            new Rect(10, 10, Screen.width - 20, 90),
            mensaje,
            estilo
        );
    }
}
