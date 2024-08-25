using System.ComponentModel;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private MainViewModel _viewModel;

        public Form1()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();

            textBoxFirstName.DataBindings.Add(nameof(textBoxFirstName.Text), _viewModel, nameof(_viewModel.FirstName));
            textBoxFirstName.AccessibleName = nameof(textBoxFirstName);
            textBoxLastName.DataBindings.Add(nameof(textBoxLastName.Text), _viewModel, nameof(_viewModel.LastName));
            textBoxLastName.AccessibleName = nameof(textBoxLastName);
            labelFullName.DataBindings.Add(nameof(labelFullName.Text), _viewModel, nameof(_viewModel.FullName));
            labelFullName.AccessibleName = nameof(labelFullName);
            buttonResetName.Command = _viewModel.ResetNameCommand;

            var lb = label1.DataBindings.Add(nameof(label1.Text), _viewModel, nameof(_viewModel.CurrentState));
            lb.Format += (sender, e) =>
            {
                var val = e.Value as MainViewModel.State;
                e.Value = val?.DisplayName;
            };
            comboBox1.DataSource = MainViewModel.State.ALL_STATES;
            comboBox1.DisplayMember = nameof(MainViewModel.State.DisplayName);

//            comboBox1.DataBindings.Add(nameof(comboBox1.SelectedItem), _viewModel, nameof(_viewModel.CurrentState), true, DataSourceUpdateMode.Never);
//            radioButton1.DataBindings.Add(nameof(radioButton1.Checked), _viewModel, nameof(_viewModel.RadioA));
//            radioButton2.DataBindings.Add(nameof(radioButton2.Checked), _viewModel, nameof(_viewModel.RadioB));

//            var binding = comboBox1.DataBindings.Add(nameof(comboBox1.SelectedItem), _viewModel, nameof(_viewModel.CurrentState), true, DataSourceUpdateMode.Never);
            var cb = comboBox1.DataBindings.Add(nameof(comboBox1.SelectedItem), _viewModel, nameof(_viewModel.CurrentState));
            comboBox1.SelectedIndexChanged += (sender, e) => cb.WriteValue();
            var rb1 = radioButton1.DataBindings.Add(nameof(radioButton1.Checked), _viewModel, nameof(_viewModel.RadioA));
            radioButton1.Click += (sender, e) => rb1.WriteValue();
            var rb2 = radioButton2.DataBindings.Add(nameof(radioButton2.Checked), _viewModel, nameof(_viewModel.RadioB));
            radioButton2.Click += (sender, e) => rb2.WriteValue();
        }

    }
}
