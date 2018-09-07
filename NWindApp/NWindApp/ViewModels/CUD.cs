using System;
using System.Collections.Generic;
using System.Text;

namespace NWindApp.ViewModels
{
    public class CUD:ViewModelBase
    {

        #region Constructor
        public CUD()
        {
            CreateProductCommand = new CommandDelegate
                ((o) => { return true; },
                async (o) =>
                {
                    var NewProduct = new Entities.Product
                    {
                        ProductName = ProductName_BF,
                        CategoryID = CategoryID_BF,
                        UnitsInStock = UnitsInStock_BF,
                        UnitPrice = UnitPrice_BF
                    };
                    var Proxy = new NWindProxyService.Proxy();
                    NewProduct = await Proxy.CreateProductAsync(NewProduct);
                    ProductID = NewProduct.ProductID;
                });
            UpdateProductCommand = new CommandDelegate
                ((o) => { return true; },
                async (o) =>
                {
                    var CurrentProduct = new Entities.Product
                    {
                        ProductID = ProductID_BF,
                        ProductName = ProductName_BF,
                        CategoryID = CategoryID_BF,
                        UnitsInStock = UnitsInStock_BF,
                        UnitPrice = UnitPrice_BF
                    };
                    var Proxy = new NWindProxyService.Proxy();
                    var Modified = await Proxy.UpdateProductAsync(CurrentProduct);
                });
            DeleteProductCommand = new CommandDelegate
                ((o) => { return true; },
                async (o) =>
                {
                    var Proxy = new NWindProxyService.Proxy();
                    var ISDeleted = await Proxy.DeleteProductAsync(ProductID);
                    if (ISDeleted)
                    {
                        ProductID = 0;
                        ProductName = "";
                        CategoryID = 0;
                        UnitsInStock = 0;
                        UnitPrice = 0;
                    }
                });
        }
        #endregion
        #region Propfulls
        private int ProductID_BF;

        public int ProductID
        {
            get { return ProductID_BF; }
            set { ProductID_BF = value; OnPropertyChanged(); }
        }
        private string ProductName_BF;

        public string ProductName
        {
            get { return ProductName_BF; }
            set
            {
                if (ProductName_BF != value)
                {
                    ProductName_BF = value;
                    OnPropertyChanged();
                }
            }
        }
        private int CategoryID_BF;

        public int CategoryID
        {
            get { return CategoryID_BF; }
            set
            {
                if (CategoryID_BF != value)
                {
                    CategoryID_BF = value;
                    OnPropertyChanged();
                }
            }
        }
        private decimal UnitsInStock_BF;

        public decimal UnitsInStock
        {
            get { return UnitsInStock_BF; }
            set
            {
                if (UnitsInStock_BF != value)
                {
                    UnitsInStock_BF = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal UnitPrice_BF;
        public decimal UnitPrice
        {
            get { return UnitPrice_BF; }
            set
            {
                if (UnitPrice_BF != value)
                {
                    UnitPrice_BF = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion
        #region Props
        public CommandDelegate CreateProductCommand { get; set; }
        public CommandDelegate UpdateProductCommand { get; set; }
        public CommandDelegate DeleteProductCommand { get; set; }
        #endregion

    }
}
