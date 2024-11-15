using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ursa.Demo.ViewModels;

public class TagInputDemoViewModel : ViewModelBase
{
    private ObservableCollection<string> _tags = new();
    public ObservableCollection<string> Tags
    {
        get => _tags;
        set => SetProperty(ref _tags, value);
    }

    private ObservableCollection<string> _distinctTags = new();
    public ObservableCollection<string> DistinctTags
    {
        get => _distinctTags;
        set => SetProperty(ref _distinctTags, value);
    }

    public ICommand LoadTagsCommand { get; set; }
    private async Task LoadTags()
    {
        await Task.Delay(1000);

        for (int i = 0; i < 5; i++)
        {
            this.Tags.Add("Tag" + i);
        }
    }

    public TagInputDemoViewModel()
    {
        this.LoadTagsCommand = new AsyncRelayCommand(LoadTags);
    }
}