using UnityEngine;


public class SortingOrder : MonoBehaviour
{
    public int sortingOrder = 100;
    public Renderer vfxRenderer;

    void OnValidate()
    {
        vfxRenderer = GetComponent<Renderer>();
        if (vfxRenderer)
        {
            vfxRenderer.sortingOrder = sortingOrder;
        }
    }
}
