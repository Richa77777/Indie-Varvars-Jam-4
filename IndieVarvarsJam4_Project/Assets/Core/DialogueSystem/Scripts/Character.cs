using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;

    public string NameGet => _name;
    public Sprite SpriteGet => _sprite;
}
