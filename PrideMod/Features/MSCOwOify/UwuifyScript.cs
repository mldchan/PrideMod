using UnityEngine;
using UnityEngine.UI;

namespace PrideMod.Features.MSCOwOify
{
    public class UwUifierScript : MonoBehaviour
    {
        internal static UwuifyFlag Flags => GetFlags();

        private static UwuifyFlag GetFlags()
        {
            UwuifyFlag flags = UwuifyFlag.None;

            if (MscOwOify.smileys.GetValue()) flags |= UwuifyFlag.Smiley;
            if (MscOwOify.stutter.GetValue()) flags |= UwuifyFlag.Stutter;
            if (MscOwOify.yu.GetValue()) flags |= UwuifyFlag.Yu;

            return flags;
        }

        private TextMesh _textMesh;
        private GUIText _text;
        private Text _text2;
        private string _lastText;
        private int _mode;
        private string _originalText;

        internal void Reapply()
        {
            switch (_mode)
            {
                case 1:
                    _text.text = _originalText;
                    break;
                case 2:
                    _textMesh.text = _originalText;
                    break;
                case 3:
                    _text2.text = _originalText;
                    break;
            }
        }

        public void Start()
        {
            _textMesh = gameObject.GetComponent<TextMesh>();
            _text = gameObject.GetComponent<GUIText>();
            _text2 = gameObject.GetComponent<Text>();
            if (_text != null) _mode = 1;
            else if (_textMesh != null) _mode = 2;
            else if (_text2 != null) _mode = 3;
            else Destroy(this);

            switch (_mode)
            {
                case 1:
                    _originalText = _text.text;
                    break;
                case 2:
                    _originalText = _textMesh.text;
                    break;
                case 3:
                    _originalText = _text2.text;
                    break;
            }

            switch (_mode)
            {
                case 1:
                    if (_text.text != _lastText)
                    {
                        _text.text = Identity.ConvertIdentityInSentence(_text.text);
                        _text.text = Uwuifier.Uwuify(_text.text, Flags);
                        _lastText = _text.text;
                    }

                    break;
                case 2:
                    if (_textMesh.text != _lastText)
                    {
                        _textMesh.text = Identity.ConvertIdentityInSentence(_textMesh.text);
                        _textMesh.text = Uwuifier.Uwuify(_textMesh.text, Flags);
                        _lastText = _textMesh.text;
                    }

                    break;
                case 3:
                    if (_text2.text != _lastText)
                    {
                        _text2.text = Identity.ConvertIdentityInSentence(_text2.text);
                        _text2.text = Uwuifier.Uwuify(_text2.text, Flags);
                        _lastText = _text2.text;
                    }

                    break;
            }
        }

        public void Update()
        {
            switch (_mode)
            {
                case 1:
                    if (_text.text != _lastText)
                    {
                        _text.text = Identity.ConvertIdentityInSentence(_text.text);
                        _text.text = Uwuifier.Uwuify(_text.text, Flags);
                        _lastText = _text.text;
                    }

                    break;
                case 2:
                    if (_textMesh.text != _lastText)
                    {
                        _textMesh.text = Identity.ConvertIdentityInSentence(_textMesh.text);
                        _textMesh.text = Uwuifier.Uwuify(_textMesh.text, Flags);
                        _lastText = _textMesh.text;
                    }

                    break;
                case 3:
                    if (_text2.text != _lastText)
                    {
                        _text2.text = Identity.ConvertIdentityInSentence(_text2.text);
                        _text2.text = Uwuifier.Uwuify(_text2.text, Flags);
                        _lastText = _text2.text;
                    }

                    break;
            }
        }
    }
}