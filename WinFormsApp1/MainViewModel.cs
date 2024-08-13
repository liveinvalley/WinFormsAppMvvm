using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyCanExecuteChangedFor(nameof(ResetNameCommand))]
    private string _firstName = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [NotifyCanExecuteChangedFor(nameof(ResetNameCommand))]
    private string _lastName = string.Empty;

    public string FullName => $"{LastName} {FirstName}";

    private bool CanResetName => !String.IsNullOrEmpty
        (FirstName) || !String.IsNullOrEmpty(LastName);

    [RelayCommand(CanExecute = nameof(CanResetName))]
    private void ResetName()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    public class State
    {
        private readonly string displayName;

        private State(string displayName)
        {
            this.displayName = displayName;
        }

        public string DisplayName
        {
            get => displayName;
        }

        public static readonly State Unspecified = new State("未定義");
        public static readonly State StateA = new State("状態A");
        public static readonly State StateB = new State("状態B");

        public static readonly ReadOnlyCollection<State> ALL_STATES = new ReadOnlyCollection<MainViewModel.State>([Unspecified, StateA, StateB]);
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(RadioA))]
    [NotifyPropertyChangedFor(nameof(RadioB))]
    private State _currentState = State.StateA;

    public bool RadioA
    {
        get => CurrentState == State.StateA;
        set { if (value) { CurrentState = State.StateA; } }
    }
    public bool RadioB
    {
        get => CurrentState == State.StateB;
        set { if (value) { CurrentState = State.StateB; } }
    }
}
