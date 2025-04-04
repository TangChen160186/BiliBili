using System.Collections.ObjectModel;
using BiliBili_Model.Api;
using BiliBili_Model.Api.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BiliBili_wpf.ViewModels;

partial class RecommendViewModel: ObservableObject
{
    private readonly IBiliBiliApiClient _biliApiClient;
    public ObservableCollection<RecommendVideo> Videos { get; set; }

    public RecommendViewModel(IBiliBiliApiClient biliApiClient)
    {
        _biliApiClient = biliApiClient;
        LoadAsync();

    }


    async void LoadAsync()
    {
        var m =await _biliApiClient.GetRecommendVideos();
        Videos = new(m.Data.Item);
    }

}