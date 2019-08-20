using System;
using UnityEngine;

namespace Gruel.VariableAssets {
	[Serializable]
	public class IntReference {

#region Properties
		public int Value {
			get => _intAsset == null ? _value : _intAsset.Value;
			set {
				if (_intAsset == null) {
					_value = value;
				} else {
					_intAsset.Value = value;
				}
			}
		}
#endregion Properties

#region Fields
		[SerializeField] private int _value = 0;
		[SerializeField] private IntAsset _intAsset;
#endregion Fields

#region Public Methods
		public void AddListener(Action<int, int> onValueChanged) {
			_intAsset.OnValueChanged += onValueChanged;
		}

		public void RemoveListener(Action<int, int> onValueChanged) {
			_intAsset.OnValueChanged -= onValueChanged;
		}
		
		public static implicit operator int(IntReference reference) {
			return reference.Value;
		}
#endregion Public Methods

	}

	[CreateAssetMenu(menuName = "Gruel/Variables/Int")]
	public class IntAsset : ScriptableObject {

#region Properties
		public Action<int, int> OnValueChanged;
		
		public int Value {
			get => _value;
			set {
				if (_value != value) {
					var delta = -(_value - value);
					_value = value;
					OnValueChanged?.Invoke(_value, delta);
				}
			}
		}
#endregion Properties

#region Fields
		[SerializeField] private int _value;
#endregion Fields

#region Public Methods
		public static implicit operator int(IntAsset intAsset) {
			return intAsset.Value;
		}
#endregion Public Methods

	}
}