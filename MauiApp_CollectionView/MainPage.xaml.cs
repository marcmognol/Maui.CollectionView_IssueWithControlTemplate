using System.Collections.ObjectModel;

namespace MauiApp_CollectionView;

public partial class MainPage : ContentPage
{
    private int _count = 4;
    private int _refreshedCount = 0;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;

        Data = new ObservableCollection<string>();

        for (int i = 0; i < 40; i++)
        {
            _count++;
            Data.Add(_count.ToString());
        }

        OnPropertyChanged(nameof(Data));
    }

    public string RefreshCountString { get; set; }
    public ObservableCollection<string> Data { get; set; }

    private void CollectionView_RemainingItemsThresholdReached(object sender, EventArgs e)
    {
        _refreshedCount++;

        for (int i = 0; i < 4; i++)
        {
            _count++;
            Data.Add(_count.ToString());
        }

        RefreshCountString = $"Remaining Items Threshold triggered {_refreshedCount} times";

        OnPropertyChanged(nameof(RefreshCountString));
        OnPropertyChanged(nameof(Data));
    }
}