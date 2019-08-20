using System;
using UnityEngine;

namespace Gruel.VariableAssets {
	[CreateAssetMenu(menuName = "Gruel/Events/EventTransform")]
	public class EventTransformAsset : ScriptableObject {
		
#region Fields
		private Action<Transform> _action;
#endregion Fields

#region Public Methods
		public void AddListener(Action<Transform> action) {
			_action += action;
		}

		public void RemoveListener(Action<Transform> action) {
			_action -= action;
		}

		public void Invoke(Transform value) {
			_action?.Invoke(value);
		}
#endregion Public Methods
	
	}
}