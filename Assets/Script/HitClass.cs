using UnityEngine;
using System.Collections;

public class HitClass : MonoBehaviour
{
    [SerializeField]
    private GameObject hitImage;

    public IEnumerator HitImageActive()
    {
        hitImage.active = true;
        yield return new WaitForSeconds(0.3f);
        hitImage.active = false;

    }
}
