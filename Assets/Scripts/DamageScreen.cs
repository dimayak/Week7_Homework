using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image _damageScreenImage;

    public void StartEffect()
    {
        StartCoroutine(ShowEffect(1.0f));
    }

    public IEnumerator ShowEffect(float time)
    {
        _damageScreenImage.enabled = true;

        for (float t = 0.0f; t <= time; t += Time.deltaTime)
        {
            _damageScreenImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f - (t / time));
            yield return null;
        }

        _damageScreenImage.enabled = false;
    }
}
