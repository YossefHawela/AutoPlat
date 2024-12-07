using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoPlat.Tools.ReadabilityMethods;

namespace AutoPlat.Models.BaseModels
{
    /// <summary>
    /// A Trigger Which calls set of actions when set of conditions are met.
    /// </summary>
    internal class Trigger
    {
        protected Condition[] _conditions;
        protected TriggerAction[] _actions;

        private TriggerChest? _chest;

        private TriggerState _state = TriggerState.Idle;
        private TriggerType _type = TriggerType.SingleFire;


        public ReadOnlyCollection<Condition> Conditions =>
            _conditions.Length != 0 ? _conditions.AsReadOnly() : throw new Exception($"{nameof(Conditions)} are not set!");
        public ReadOnlyCollection<TriggerAction> Actions =>
            _actions.Length != 0 ? _actions.AsReadOnly() : throw new Exception($"{nameof(Actions)} are not set!");
        public TriggerState State => _state;
        public TriggerType TriggerType
        {
            get => _type;
            set => _type = value;
        }
        public TriggerChest? Chest => _chest;

        public Trigger(TriggerChest chest, Condition[] conditions, TriggerAction[] actions)
        {
            _conditions = conditions;
            _actions = actions;
            SetChest(chest);
        }
        public Trigger(TriggerChest chest) : this(chest, Array.Empty<Condition>(), Array.Empty<TriggerAction>()) { }

        public Trigger(TriggerChest chest, Condition[] conditions) : this(chest, conditions, Array.Empty<TriggerAction>()) { }


        public Trigger(TriggerChest chest, TriggerAction[] actions) : this(chest, Array.Empty<Condition>(), actions) { }

        /// <summary>
        /// Change conditions of the trigger
        /// </summary>
        /// <param name="conditions">The conditions to but the trigger on fire state</param>
        public void SetConditions(Condition[] conditions)
        {
            _conditions = conditions;
        }


        /// <summary>
        /// Change actions of the trigger
        /// </summary>
        /// <param name="actions">The actions to be called after trigger fires</param>
        public void SetActions(TriggerAction[] actions)
        {
            _actions = actions;
        }


        public void SetChest(TriggerChest chest)
        {
            if (_chest is not null)
                _chest.Triggers.Remove(this);

            _chest = chest;

            _chest.Triggers.Add(this);

        }
        public void Update()
        {
            if (State is TriggerState.Idle && Every(Conditions) is true)
            {
                _state = TriggerState.InFireState;

            }
            else if (State is not TriggerState.Idle && ThireIsAnyFalseCondition(Conditions))
            {
                _state = TriggerState.Idle;
            }

            if (State is TriggerState.InFireState)
            {
                foreach (TriggerAction action in _actions)
                {
                    action.Fire();
                }

                if (TriggerType == TriggerType.SingleFire)
                    _state = TriggerState.Fired;
            }
        }


    }
}
