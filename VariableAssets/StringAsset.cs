using System;
using UnityEngine;

namespace Gruel.VariableAssets {
	[Serializable]
	public class StringReference {

#region Properties
		public string Value {
			get => _stringAsset == null ? _value : _stringAsset.Value;
			set {
				if (_stringAsset == null) {
					_value = value;
				} else {
					_stringAsset.Value = value;
				}
			}
		}
#endregion Properties

#region Fields
		[SerializeField] private string _value = string.Empty;
		[SerializeField] private StringAsset _stringAsset;
#endregion Fields

#region Public Methods
		public void AddListener(Action<string> onValueChanged) {
			_stringAsset.OnValueChanged += onValueChanged;
		}

		public void RemoveListener(Action<string> onValueChanged) {
			_stringAsset.OnValueChanged -= onValueChanged;
		}
		
		public static implicit operator string(StringReference reference) {
			return reference.Value;
		}
#endregion Public Methods

#region Private Methods
#endregion Private Methods
		
	}

	[CreateAssetMenu(menuName = "Gruel/Variables/String")]
	public class StringAsset : ScriptableObject {
		
#region Properties
		public Action<string> OnValueChanged;
		
		public string Value {
			get => _value;
			set {
				if (_value != value) {
					_value = value;
					OnValueChanged?.Invoke(_value);
				}
			}
		}
#endregion Properties

#region Fields
		[SerializeField] private string _value = string.Empty;
#endregion Fields

#region Public Methods
		public static implicit operator string(StringAsset stringAsset) {
			return stringAsset.Value;
		}
#endregion Public Methods

	}
}