using MRS_Store.Globals;
using MRS_Store.Models;
using MRS_Store.Models.Services;
using MRS_Store.Views.Category;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace MRS_Store.ViewModels
{
    public class CategoryViewModel : ViewModelBase
    {
        #region Common
        /// Common Variables
        /// 
        public CategoryViewModel() : base(nameof(CategoryViewModel))
        {
            Categories = new ObservableCollection<Category>(CategoryTable.GetAll());
        }

        IDataService<Category> CategoryTable = new GenericDataService<Category>(new StoreDbContextFactory());

        private ObservableCollection<Category> _Categories;
        public ObservableCollection<Category> Categories
        {
            get { return _Categories; }
            set { _Categories = value; }
        }

        public Category category = new Category();

        public Int64 ParentCategoryId
        {
            get 
            { 
                if (category.ParentCategoryId != null)
                    return (Int64)category.ParentCategoryId;
                return 0;
            }
            set
            {
                category.ParentCategoryId = value;
            }
        }

        public string CatName
        {
            get { return category.Name; }
            set { category.Name = value; }
        }
        public string CatDesc
        {
            get { return category.Description; }
            set { category.Description = value; }
        }

        public ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (backCommand == null)
                {
                    backCommand = new Command(
                        p => true, // can execute
                        p => Session.Instance.SetNextView(new CategoryView())); // execute function
                }
                return backCommand;
            }
        }
        #endregion

        #region ListView
        /// ListView Variables
        /// 
        private Int64 selectedCategoryId;
        public Int64 SelectedCategoryId
        {
            get { return selectedCategoryId; }
            set
            {
                selectedCategoryId = value;
                category = CategoryTable.Get(selectedCategoryId);
            }
        }

        private string textSearchBox;
        public string TextSearchBox
        {
            get { return textSearchBox; }
            set { textSearchBox = value; }
        }
        private ICommand searshCommand;
        public ICommand SearshCommand
        {
            get
            {
                if (searshCommand == null)
                {
                    searshCommand = new Command(
                        p => true, // can execute
                        p => RefreshCategoriesDataSource(textSearchBox)); // execute function
                }
                return searshCommand;
            }
        }

        private ListViewItem selectedFunction;
        public ListViewItem SelectedFunction
        {
            get { return selectedFunction; }
            set
            {
                selectedFunction = value;
                FunctionSwitcher(selectedFunction.Name);
            }
        }
        private void FunctionSwitcher(string SelectedFunctionName)
        {
            UserControl usc;
            switch (SelectedFunctionName)
            {

                case "Create":
                    usc = new CreateView();
                    break;
                case "Update":

                    usc = new UpdateView();
                    usc.DataContext = new CategoryViewModel { SelectedCategoryId = this.SelectedCategoryId};
                    break;

                case "Delete":
                    DeleteCategory();
                    usc = new CategoryView();
                    break;
                default:
                    usc = new CategoryView();
                    break;
            };
            Session.Instance.SetNextView(usc);
        }

        public void RefreshCategoriesDataSource(string value = "")
        {
            if (String.IsNullOrEmpty(value))
            {
                Categories = new ObservableCollection<Category>(CategoryTable.GetAll());
            }
            else
            {
                Categories = new ObservableCollection<Category>(CategoryTable.GetAll((e) => e.Name.Contains(value) || e.Description.Contains(value) || e.ParentCategory.Name.Contains(value)));

            }
            OnPropertyChanged("Categories");
        }
        #endregion

        #region CreateView
        /// CreateView Variables
        /// 
        private ICommand createCommand;
        public ICommand CreateCommand
        {
            get
            {
                if (createCommand == null)
                {
                    createCommand = new Command(
                        p => true, // can execute
                        p => CreateCategory()); // execute function
                }
                return createCommand;
            }
        }
        public void CreateCategory()
        {
            category.Id = 0;
            CategoryTable.Create(category);
            RefreshCategoriesDataSource();
            Session.Instance.SetNextView(new CategoryView());
        }
        #endregion

        #region UpdateView
        /// UpdateView Variables
        /// 
        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new Command(
                        p => true, // can execute
                        p => UpdateCategory()); // execute function
                }
                return updateCommand;
            }
        }
        public void UpdateCategory()
        {
            CategoryTable.Update(category.Id, category);
            RefreshCategoriesDataSource();
            Session.Instance.SetNextView(new CategoryView());
        }
        #endregion

        #region Delete
        /// Delete Variables
        /// 
        void DeleteCategory()
        {
            _ = CategoryTable.Delete(selectedCategoryId);
            RefreshCategoriesDataSource();
        }
        #endregion

    }
}
