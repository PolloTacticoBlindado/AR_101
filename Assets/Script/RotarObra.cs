
using UnityEngine;

public class RotarObra : MonoBehaviour
{
    public Camera arCamera;
    public float velocidadRotacion = 0.4f;

    private bool arrastrando = false;

    void Start()
    {
        if (arCamera == null)
            arCamera = Camera.main;
    }

    void Update()
    {
        if (arCamera == null)
            return;

        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            if (toque.phase == TouchPhase.Began)
                arrastrando = EsMiObjeto(toque.position);

            if (toque.phase == TouchPhase.Moved && arrastrando)
            {
                transform.Rotate(
                    0f,
                    -toque.deltaPosition.x * velocidadRotacion,
                    0f,
                    Space.Self
                );
            }

            if (toque.phase == TouchPhase.Ended ||
                toque.phase == TouchPhase.Canceled)
                arrastrando = false;
        }

#if UNITY_EDITOR
        else
        {
            if (Input.GetMouseButtonDown(0))
                arrastrando = EsMiObjeto(Input.mousePosition);

            if (Input.GetMouseButton(0) && arrastrando)
            {
                transform.Rotate(
                    0f,
                    -Input.GetAxis("Mouse X") * 5f,
                    0f,
                    Space.Self
                );
            }

            if (Input.GetMouseButtonUp(0))
                arrastrando = false;
        }
#endif
    }

    bool EsMiObjeto(Vector2 posicion)
    {
        Ray rayo = arCamera.ScreenPointToRay(posicion);

        if (Physics.Raycast(rayo, out RaycastHit impacto))
        {
            return impacto.collider.transform == transform ||
                   impacto.collider.transform.IsChildOf(transform);
        }

        return false;
    }
}
