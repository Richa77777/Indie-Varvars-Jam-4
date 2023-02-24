using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogSystem
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField] private GameObject _dialogTab;

        [Header("Dialog Tab Objects")]
        [SerializeField] private TextMeshProUGUI _textObject;
        [SerializeField] private Image _characterImage;
        [SerializeField] private TextMeshProUGUI _characterNameText;

        [SerializeField] private float _delayBtwnChars = 0.1f;

        [SerializeField] private AudioClip _charSound;

        private AudioSource _audioSource;

        private string _currentText = " ";
        private IEnumerator _playPhraseCor = null;
        private Dialog _currentDialog;

        private bool _mightPlayPhrase;
        private int _step = 0;

        private int _charCount = 0;
        
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _charSound;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))
            {
                if (_mightPlayPhrase == true)
                {
                    PlayNextPhrase();
                }

                else if (_charCount > 3)
                {
                    Skip();
                }
            }
        }

        public void PlayNewDialog(Dialog dialog)
        {
            if (_playPhraseCor != null)
            {
                StopCoroutine(_playPhraseCor);
            }

            _step = 0;
            _currentDialog = dialog;

            _dialogTab.SetActive(true);

            PlayNextPhrase();
        }

        public void PlayNextPhrase()
        {
            _playPhraseCor = PlayPhraseCor(_currentDialog.PhrasesGet[_step].CharacterGet, _currentDialog.PhrasesGet[_step].TextGet);

            StartCoroutine(_playPhraseCor);
        }

        private IEnumerator PlayPhraseCor(Character character, string text)
        {
            _charCount = 0;
            _mightPlayPhrase = false;

            _characterNameText.text = character.NameGet;
            _characterImage.sprite = character.SpriteGet;

            for (int i = 0; i <= text.Length; i++)
            {
                _currentText = text.Substring(0, i);
                _textObject.text = _currentText;
                _charCount++;

                _audioSource.pitch = Random.Range(0.95f, 1.05f);
                _audioSource.Play();

                yield return new WaitForSeconds(_delayBtwnChars);
            }

            _step++;
            _mightPlayPhrase = true;
        }

        private void Skip()
        {
            _currentText = _currentDialog.PhrasesGet[_step].TextGet;
            _textObject.text = _currentText;

            if (_playPhraseCor != null)
            {
                StopCoroutine(_playPhraseCor);
            }

            _step++;
            _mightPlayPhrase = true;
            _playPhraseCor = null;
        }
    }
}
