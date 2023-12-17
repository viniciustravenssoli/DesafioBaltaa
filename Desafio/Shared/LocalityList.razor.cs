using AntDesign.TableModels;
using BaltaDesafioBlazor.Domain.Handlers.Queries;
using BaltaDesafioBlazor.Shared.Models.Locality;
using Microsoft.AspNetCore.Components;

namespace BaltaDesafioBlazor.Shared;

public partial class LocalityList
{
    private int _pageIndex = 1;
    private int _pageSize = 50;
    private int _totalRows;
    private string _state = string.Empty;
    private string _city = string.Empty;
    private bool _loading = true;

    private IEnumerable<LocalityModel> _localities = [];

    private async Task LoadByIdAsync(string id)
    {
        _loading = true;

        await Task.Delay(500, Token);

        var result = await QueryHandler.GetLocalityAsync(id, Token);
        if (result.Success)
        {
            _localities = [result.Result];
        }

        _loading = false;

        StateHasChanged();
    }

    private async Task LoadAsync()
    {
        _loading = true;

        await Task.Delay(500, Token);

        var result = await QueryHandler.GetLocalitiesAsync(
            _pageIndex - 1,
            _pageSize,
            _state,
            _city,
            Token);

        if (result.Success)
        {
            _localities = result.Result;
            _totalRows = result.Total;
        }

        _loading = false;

        StateHasChanged();
    }

    public Task OnChange(QueryModel<LocalityModel> queryModel)
    {
        return LoadAsync();
    }

    public Task OnSearchState(string state)
    {
        _state = state;
        _pageIndex = 1;
        return LoadAsync();
    }

    public Task OnSearchCity(string city)
    {
        _city = city;
        _pageIndex = 1;
        return LoadAsync();
    }

    public Task OnSearchCode(string id)
    {
        _state = string.Empty;
        _city = string.Empty;
        _pageIndex = 1;

        return LoadByIdAsync(id);
    }

    [Inject] ILocalityQueryHandler QueryHandler { get; set; } = null!;

    [CascadingParameter] CancellationToken Token { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await LoadAsync()
                .ConfigureAwait(false);
        }
    }
}
