using System;
using System.Collections.Generic;
using System.Text;
using NWindProxyService;
using Entities;

namespace NWindApp.ViewModels
{
    public class Product:ViewModelBase
    {
        #region Constructor
        public Product()
        {
            InitializeViewModel();
        }
        #endregion

        void InitializeViewModel()
        {
            Products = new List<Entities.Product>();
            SearchProductsCommand = new CommandDelegate
                ((o) => { return true; },
                async(o) => 
                {
                    var Proxy = new Proxy();
                    Products = await Proxy.FilterProductsByCategoryIDAsync
                    (CategoryID);
                }
                );
            SearchProductByIDCommand = new CommandDelegate
                ((o) => { return true; },
                async (o) =>
                {
                    if (ProductSelected.ProductID != 0)
                    {
                        var Proxy = new Proxy();
                        var P = await Proxy.RetrieveProductByIdAsync(ProductSelected.ProductID);
                    }
                    
                }
                
                );
        }
        #region Properties
        private int CategoryID_BF;

        public int CategoryID
        {
            get { return CategoryID_BF; }
            set { CategoryID_BF = value;OnPropertyChanged(); }
        }
        private List<Entities.Product> Products_BF;

        public List<Entities.Product> Products
        {
            get { return Products_BF; }
            set { Products_BF = value; OnPropertyChanged(); }
        }
        private Entities.Product ProductSelected_BF;

        public Entities.Product ProductSelected
        {
            get { return ProductSelected_BF; }
            set { ProductSelected_BF = value; OnPropertyChanged(); }
        }

        private string ProductName_BF;

        public string ProductName
        {
            get { return ProductName_BF; }
            set { ProductName_BF = value; }
        }

        private int ProductID_BF;

        public int ProductID
        {
            get { return ProductID_BF; }
            set { ProductID_BF = value; }
        }
        private decimal UnitsInStock_BF;

        public decimal UnitsInStock
        {
            get { return UnitsInStock_BF; }
            set { UnitsInStock_BF = value; }
        }

        private decimal UnitPrice_BF;

        public decimal UnitPrice
        {
            get { return UnitPrice_BF; }
            set { UnitPrice_BF = value; }
        }

        public CommandDelegate SearchProductsCommand { get; set; }
        public CommandDelegate SearchProductByIDCommand { get; set; }
        #endregion
    }
}
