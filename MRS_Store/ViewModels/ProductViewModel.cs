using MRS_Store.Globals;
using MRS_Store.Models;
using MRS_Store.Models.Services;
using MRS_Store.Views;
using MRS_Store.Views.Category;
using MRS_Store.Views.Products;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace MRS_Store.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        #region Common
        /// Common Variables
        /// 
        public ProductViewModel() : base(nameof(ProductViewModel))
        {
            Categories = new ObservableCollection<Category>(CategoryTable.GetAll());
            Products = new ObservableCollection<Product>(ProductTable.GetAll());
        }
        IDataService<Category> CategoryTable = new GenericDataService<Category>(new StoreDbContextFactory());
        IDataService<Product> ProductTable = new GenericDataService<Product>(new StoreDbContextFactory());

        private ObservableCollection<Product> _Products;
        public ObservableCollection<Product> Products
        {
            get { return _Products; }
            set { _Products = value; }
        }
        private ObservableCollection<Category> _Categories;
        public ObservableCollection<Category> Categories
        {
            get { return _Categories; }
            set { _Categories = value; }
        }

        public Product product = new Product();

        public Int64 CategoryId
        {
            get
            {
                if (product.CategoryId != null)
                    return (Int64)product.CategoryId;
                return 0;
            }
            set
            {
                product.CategoryId = value;
            }
        }

        public string ProductName
        {
            get { return product.ProductName; }
            set { product.ProductName = value; }
        }
        public string ProductDesc
        {
            get { return product.Description; }
            set { product.Description = value; }
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
                        p => Session.Instance.SetNextView(new ProductsView())); // execute function
                }
                return backCommand;
            }
        }
        #endregion

        #region ListView
        /// ListView Variables
        /// 
        private Int64 selectedProductId;
        public Int64 SelectedProductId
        {
            get { return selectedProductId; }
            set
            {
                selectedProductId = value;
                product = ProductTable.Get( selectedProductId);
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
                        p => RefreshProductsDataSource(textSearchBox)); // execute function
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
                    usc = new CreateProductView();
                    break;
                case "Update":
                    usc = new UpdateProductView();
                    usc.DataContext = new ProductViewModel { SelectedProductId = this.SelectedProductId };
                    break;

                case "Delete":
                    DeleteProduct();
                    usc = new ProductsView();
                    break;

                case "Category":
                    usc = new CategoryView();
                    break;

                default:
                    usc = new ProductsView();
                    break;
            };
            Session.Instance.SetNextView(usc);
        }

        public void RefreshProductsDataSource(string value = "")
        {
            if (String.IsNullOrEmpty(value))
            {
                Products = new ObservableCollection<Product>(ProductTable.GetAll());
            }
            else
            {
                Products = new ObservableCollection<Product>(ProductTable.GetAll((e) => e.ProductName.Contains(value) || e.Description.Contains(value) || e.Category.Name.Contains(value)));

            }
            OnPropertyChanged("Products");
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
                        p => CreateProduct()); // execute function
                }
                return createCommand;
            }
        }
        public void CreateProduct()
        {
            product.Id = 0;
            ProductTable.Create(product);
            RefreshProductsDataSource();
            Session.Instance.SetNextView(new ProductsView());
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
                        p => UpdateProduct()); // execute function
                }
                return updateCommand;
            }
        }
        public void UpdateProduct()
        {
            ProductTable.Update(product.Id, product);
            RefreshProductsDataSource();
            Session.Instance.SetNextView(new ProductsView()) ;
        }
        #endregion

        #region Delete
        /// Delete Variables
        /// 
        void DeleteProduct()
        {
            _ = ProductTable.Delete(SelectedProductId);
            RefreshProductsDataSource();
        }
        #endregion

    }
}
