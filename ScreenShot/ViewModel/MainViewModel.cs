

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ScreenShot.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    ImageSource _screenGrab;

    [RelayCommand]
    async Task TakeScreenShot()
    {
        ScreenGrab = await TakeScreenshotAsync();
    }

    private async Task<ImageSource> TakeScreenshotAsync()
    {
        if (Screenshot.Default.IsCaptureSupported)
        {
            IScreenshotResult screen = await Screenshot.Default.CaptureAsync();

            Stream stream = await screen.OpenReadAsync();

            return ImageSource.FromStream(() => stream);
        }

        return null;
    }
}
