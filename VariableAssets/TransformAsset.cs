using System;
using UnityEngine;

namespace Gruel.VariableAssets {
	[CreateAssetMenu(menuName = "Gruel/Variables/Transform")]
	public class TransformAsset : ScriptableObject {
		
#region Properties
		public Action<Transform> OnValueChanged;
		
		public Transform Value {
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
		[SerializeField] private Transform _value;
#endregion Fields

#region Public Methods
		public static implicit operator Transform(TransformAsset transformAsset) {
			return transformAsset.Value;
		}
#endregion Public Methods

	}
}