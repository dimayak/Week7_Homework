using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private float _blinkFreq = 30.0f;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect(1.0f));
    }

    public IEnumerator BlinkEffect(float time)
    {
        for (float t = 0.0f; t <= time; t += Time.deltaTime)
        {
            float red = Mathf.Sin(t * _blinkFreq) * 0.5f + 0.5f;
            Color color = new Color(red, 0.0f, 0.0f);

            for (int i = 0; i < _renderers.Length; i++)
            {
                _renderers[i].material.SetColor("_EmissionColor", color);
            }
            yield return null;
        }
    }
}
