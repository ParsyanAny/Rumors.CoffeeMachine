using System;
using System.Collections.Generic;
using Rumors.CoffeeMachine.States;

namespace Rumors.CoffeeMachine
{
    class CoffeeMachine
    {
        private State _state = null;
        public List<Coffee> Coffees { get ; set; }
        public Storage Storage { get; set; }
        public CoffeeMachine(State state, List<Coffee> coffees, Storage storage)
        {
            Coffees = coffees;
            Storage = storage;
            TransitionTo(state);
        }

        public void TransitionTo(State state)
        {
            _state = state;
            _state.SetContext(this);
        }
        public void MakeCoffee() => _state.MakeCoffee();
    }
}
