using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Specific.Gameplay
{
    public class Tile : MonoBehaviour
    {
        private int _value; // the number of the tile

        private TextMeshPro _text; // the text of the tile
        private Material _material; // the material of the tile
        
        public bool WasMerged; // whether the tile was merged this move or not
        
        public int Value
        {
            get => _value;
            set
            {
                Debug.Log($"Setting Value: {value.ToString()}");
                _value = value;
                _text.text = _value.ToString();
                _material.color = TileColors.GetColor(_value);
            }
        }
        
        public bool IsEmpty => _value == 0;
        
        public void Awake()
        {
            _text = transform.Find("VisibleText").GetComponent<TextMeshPro>(); // Find("VisibleText
            _material = GetComponent<Renderer>().material; // get the material of the tile
        }
    }
}