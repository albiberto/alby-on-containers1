namespace AlbyOnContainers.ProductDataManager.Pages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Models;
using Radzen;
using Radzen.Blazor;
using Services;

public partial class Categories
{
    [Inject] private ProductContext Context { get; set; }
    [Inject] private DialogService DialogService { get; set; }
    [Inject] private NotificationService NotificationService { get; set; }
    [Inject] private CategoryService CategoryService { get; set; }

    private IEnumerable<Category> _categories;
    private RadzenDataGrid<Category> _grid;
    
    protected override async Task OnInitializedAsync() => _categories = Context.Categories.Where(e => e.ParentId == null);

    private void LoadChildData(DataGridLoadChildDataEventArgs<Category> args) => args.Data = Context.Categories.Where(e => e.ParentId == args.Item.Id).ToList();

    // Disable inspection because it causes multiple database calls.
    // ReSharper disable once ReplaceWithSingleCallToAny
    private void RowRender(RowRenderEventArgs<Category> args) => args.Expandable = Context.Categories.Where(e => e.ParentId == args.Data.Id).Any();
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) await _grid.ExpandRow(_categories.FirstOrDefault());
    }

    private async Task AddButtonClick(MouseEventArgs args)
    {
        await DialogService.OpenAsync<AddCategory>("Add Category", null);
        await _grid.Reload();
    }

    private async Task EditRow(Entity args) => await DialogService.OpenAsync<EditCategory>("Edit Category", new() { {"Id", args.Id} });

    private async Task GridDeleteButtonClick(MouseEventArgs args, Category category)
    {
        try
        {
            if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            {
                var deleteResult = await CategoryService.DeleteCategory(category.Id);

                if (deleteResult != null)
                {
                    await _grid.Reload();
                }
            }
        }
        catch (Exception ex)
        {
            NotificationService.Notify(new()
            { 
                Severity = NotificationSeverity.Error,
                Summary = $"Error", 
                Detail = $"Unable to delete Category" 
            });
        }
    }

    private async Task ExportClick(RadzenSplitButtonItem args)
    {
        if (args?.Value == "csv")
        {
            await CategoryService.ExportCategoriesToCsv(new()
            { 
                Filter = $@"{(string.IsNullOrEmpty(_grid.Query.Filter)? "true" : _grid.Query.Filter)}", 
                OrderBy = $"{_grid.Query.OrderBy}", 
                Expand = "Parent", 
                Select = string.Join(",", _grid.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
            }, "Categories");
        }

        if (args == null || args.Value == "xlsx")
        {
            await CategoryService.ExportCategoriesToExcel(new()
            { 
                Filter = $@"{(string.IsNullOrEmpty(_grid.Query.Filter)? "true" : _grid.Query.Filter)}", 
                OrderBy = $"{_grid.Query.OrderBy}", 
                Expand = "Parent", 
                Select = string.Join(",", _grid.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
            }, "Categories");
        }
    }
}