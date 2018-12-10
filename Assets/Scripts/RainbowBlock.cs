using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is to change the colours of a shader.
/// I made it so that it goes through a rainbow cycle.
/// I wanted to do it to learn a bit more about accessing shaders through other scripts, and because it looks awesome.
/// </summary>
public class RainbowBlock : MonoBehaviour {

    private Color _colour;
    private Renderer _rend;

    private enum ColourStates { rg, gb, br, r, g, b };
    private ColourStates _colourStates;

    private void Start()
    {
        _colour.r = 1f;
        _colour.g = 0f;
        _colour.b = 0f;
        _colour.a = 1f;

        _rend = GetComponent<Renderer>();

        _rend.material.shader = Shader.Find("MK/Glow/Selective/Self-Illumin/Diffuse");
        _rend.material.SetColor("_Color", _colour);
        _rend.material.SetColor("_MKGlowTexColor", _colour);
        _rend.material.SetColor("_MKGlowColor", _colour);

        _colourStates = ColourStates.r;
    }

    private void Update()
    {
        RainbowCycle();
    }

    void RainbowCycle()
    {
        switch (_colourStates) {
            case ColourStates.r:
                _colour.b -= 0.01f;
                SetColour();
                if (_colour.r >= 1 && _colour.b <= 0)
                {
                    _colourStates = ColourStates.rg;
                }
                return;
            case ColourStates.rg:
                _colour.g += 0.01f;
                SetColour();
                if (_colour.r >= 1 && _colour.g >= 1)
                {
                    _colourStates = ColourStates.g;
                }
                return;
            case ColourStates.g:
                _colour.r -= 0.01f;
                SetColour();
                if (_colour.r <= 0 && _colour.g >= 1)
                {
                    _colourStates = ColourStates.gb;
                }
                return;
            case ColourStates.gb:
                _colour.b += 0.01f;
                SetColour();
                if (_colour.g >= 1 && _colour.b >= 1)
                {
                    _colourStates = ColourStates.b;
                }
                return;
            case ColourStates.b:
                _colour.g -= 0.01f;
                SetColour();
                if (_colour.g <= 0 && _colour.b >= 1)
                {
                    _colourStates = ColourStates.br;
                }
                return;
            case ColourStates.br:
                _colour.r += 0.01f;
                SetColour();
                if (_colour.b >= 1 && _colour.r >= 1)
                {
                    _colourStates = ColourStates.r;
                }
                return;
        }
    }

    void SetColour()
    {
        _rend.material.SetColor("_Color", _colour);
        _rend.material.SetColor("_MKGlowTexColor", _colour);
        _rend.material.SetColor("_MKGlowColor", _colour);
    }
}
