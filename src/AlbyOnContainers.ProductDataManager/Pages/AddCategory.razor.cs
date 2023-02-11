namespace AlbyOnContainers.ProductDataManager.Pages;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Models;
using Radzen;
using Services;

public partial class AddCategory
{
    [Inject]
    protected IJSRuntime JSRuntime { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    protected TooltipService TooltipService { get; set; }

    [Inject]
    protected ContextMenuService ContextMenuService { get; set; }

    [Inject]
    protected NotificationService NotificationService { get; set; }
    [Inject]
    public CategoryService CategoryService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        category = new();

        categoriesForParentId = await CategoryService.GetCategories();
    }
    protected bool errorVisible;
    protected Category category;

    protected IEnumerable<Category> categoriesForParentId;

    protected async Task FormSubmit()
    {
        try
        {
            await CategoryService.CreateCategory(category);
            DialogService.Close(category);
        }
        catch (Exception ex)
        {
            errorVisible = true;
        }
    }

    protected async Task CancelButtonClick(MouseEventArgs args)
    {
        DialogService.Close(null);
    }
}