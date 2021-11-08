using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeStars : MonoBehaviour
{
    SpriteRenderer _renderer;

    bool _isDecreasing = true;

    Color _newCol;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Color oldCol = _renderer.material.color;
        if (oldCol.a <= 0)
            _isDecreasing = false;
        else if (oldCol.a >= 1)
            _isDecreasing = true;
        if (_isDecreasing)
            _newCol = new Color(oldCol.r, oldCol.g, oldCol.b, oldCol.a - 0.008f);
        else
            _newCol = new Color(oldCol.r, oldCol.g, oldCol.b, oldCol.a + 0.008f);
        _renderer.material.color = _newCol;
    }
}
