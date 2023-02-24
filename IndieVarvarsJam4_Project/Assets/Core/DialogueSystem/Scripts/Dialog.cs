using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class Dialog : MonoBehaviour
    {
        [SerializeField] private List<Phrase> _phrases = new List<Phrase>();

        public List<Phrase> PhrasesGet => _phrases;
    }

    [System.Serializable]
    public class Phrase
    {
        [SerializeField] Character _character;
        [SerializeField] private string _text;

        public Character CharacterGet => _character;
        public string TextGet => _text;
    }
}
