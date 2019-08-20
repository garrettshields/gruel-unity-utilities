using System;
using UnityEngine;

namespace Gruel.VariableAssets {
	[CreateAssetMenu(menuName = "Gruel/Events/Event")]
	public class EventAsset : ScriptableObject {

#region Fields
		private Action _action;
#endregion Fields

#region Public Methods
		public void AddListener(Action action) {
			_action += action;
		}

		public void RemoveListener(Action action) {
			_action -= action;
		}

		public void Invoke() {
			_action?.Invoke();
		}
#endregion Public Methods
	
	}
}