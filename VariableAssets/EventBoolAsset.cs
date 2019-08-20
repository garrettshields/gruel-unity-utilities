using System;
using UnityEngine;

namespace Gruel.VariableAssets {
	[CreateAssetMenu(menuName = "Gruel/Events/EventBool")]
	public class EventBoolAsset : ScriptableObject {

#region Fields
		private Action<bool> _action;
#endregion Fields

#region Public Methods
		public void AddListener(Action<bool> action) {
			_action += action;
		}

		public void RemoveListener(Action<bool> action) {
			_action -= action;
		}

		public void Invoke(bool value) {
			_action?.Invoke(value);
		}
#endregion Public Methods
	
	}
}