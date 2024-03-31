using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject _healthIconPrefab;
    List<GameObject> _healthIcons = new();

    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; ++i)
        {
            GameObject icon = Instantiate(_healthIconPrefab, transform);
            _healthIcons.Add(icon);
        }
    }

    public void DisplayHeatlh(int health)
    {
        for (int i = 0; i < _healthIcons.Count; i++)
        {
            _healthIcons[i].SetActive(i < health);
        }
    }
}
