using UnityEngine;

namespace Gruel.VariableAssets {
	[CreateAssetMenu(menuName = "Gruel/Variables/AnimationCurve")]
	public class AnimationCurveAsset : ScriptableObject {

#region Properties
		public AnimationCurve Value {
			get => _value;
			set => _value = value;
		}
#endregion Properties

#region Fields
		[SerializeField] private AnimationCurve _value;
#endregion Fields

#region Public Methods
		public static implicit operator AnimationCurve(AnimationCurveAsset animationCurveAsset) {
			return animationCurveAsset.Value;
		}
#endregion Public Methods

	}
}