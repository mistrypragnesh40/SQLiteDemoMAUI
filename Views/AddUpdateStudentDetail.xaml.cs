using SQLiteDemo.ViewModels;

namespace SQLiteDemo.Views;

public partial class AddUpdateStudentDetail : ContentPage
{
    public AddUpdateStudentDetail(AddUpdateStudentDetailViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}