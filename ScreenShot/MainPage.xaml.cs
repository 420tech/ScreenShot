using ScreenShot.ViewModel;

namespace ScreenShot;

public partial class MainPage : ContentPage
{
	private readonly MainViewModel viewModel;
	int count = 0;

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = this.viewModel = viewModel;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

