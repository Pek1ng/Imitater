using UnityEngine;

public class Batty : MonoBehaviour
{
    [SerializeField]
    private float _showTime;

    private float _currentTime = 0f;

    [SerializeField]
    private Sprite[] _sprites;

    private SpriteRenderer _renderer;
    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _showTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _currentTime = 0f;
                _renderer.sprite = _sprites[1];

                return;
            }

            _renderer.sprite = _sprites[0];
        }
    }
}
