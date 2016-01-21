﻿using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.DAL;
using Lumex.Tech;

namespace Lumex.Project.BLL
{
    public class ProductBLL
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductNameOnly { get; set; }
        public string Barcode { get; set; }
        public string ProductGroupId { get; set; }
        public string ProductVolume { get; set; }
        public decimal VolumeQuantity { get; set; }
        public string Unit { get; set; }
        public decimal ProductRate { get; set; }
        public float VATPercentage { get; set; }
        public string VendorId { get; set; }
        public string additinalInfo { get; set; }
        public string productDesc { get; set; }
        public string productImageName { get; set; }

        public DataTable SaveProduct(List<string> mainProductList)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = product.SaveProduct(this, db);
                //dt.Columns.Add("ProductId");
                if (dt.Rows.Count > 0)
                {
                    ProductId = dt.Rows[0][0].ToString();
                }
                if (mainProductList.Count > 0)
                {
                   
                    product.SaveMainProductOfSubProduct(ProductId, mainProductList, db);

                }
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetProductList()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetProductList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetDeletedProductListByDateRangeAll(string fromDate, string toDate, string search)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetDeletedProductListByDateRangeAll(fromDate, toDate, search, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetActiveProducts()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetActiveProducts(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetAvailableProductListBySalesCenter(string salesCenterId)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetAvailableProductListBySalesCenter(salesCenterId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetAvailableProductListByWarehouse(string warehouseId)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetAvailableProductListByWarehouse(warehouseId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetActiveProductList()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetActiveProductList(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetProductById(string productId)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetProductById(productId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetProductByBarcodeIdName(string productBarcodeIdName)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetProductByBarcodeIdName(productBarcodeIdName, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public bool CheckDuplicateProductByName(string productName,string warehouse,string salescenter)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = product.CheckDuplicateProductByName(productName,warehouse,salescenter, db);
                db.Stop();
                return status;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public bool CheckDuplicateProductByBarcode(string barcode)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                bool status = product.CheckDuplicateProductByBarcode(barcode, db);
                db.Stop();
                return status;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public void UpdateProductActivation(string productId, string activationStatus)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                product.UpdateProductActivation(productId, activationStatus, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public void DeleteProduct(string productId)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                product.DeleteProduct(productId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public void UpdateProduct(List<string> mainProductList,string updateCondition)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt=product.UpdateProduct(this, updateCondition, db);
                product.SaveMainProductOfSubProduct(ProductId, mainProductList, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetProductVolumes()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetProductVolumes(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetProductNames()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetProductNames(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }
        public DataTable GetProductNamesBySalesCenter(string id)
        {
            ProductDAL product = new ProductDAL();
            DataTable dt=new DataTable();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                 dt = product.GetProductNamesBySalesCenter(id,db);
                db.Stop();

                
            }
            catch (Exception)
            {
                //throw;
            }
            return dt;
            //finally
            //{
            //    product = null;
            //}
        }
        public DataTable GetProductNamesByWareHouse(string id)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetProductNamesByWareHouse(id,db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }
        public DataTable GetProductNamesOnly()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetProductNamesOnly(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetProductUnits()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetProductUnits(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetProductBarcodes()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetProductBarcodes(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetProductNamesForSales()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetProductNamesForSales(db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public string salescenter { get; set; }

      

        public DataTable GetActiveProductsByWareHouseorSalesCenterForSales(string Id)
        {
           
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetActiveProductsByWareHouseorSalesCenterForSales(Id,db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetAllProductsBySalesCenter(string Id)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetAllProductsBySalesCenter(Id, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetAllProductsByWareHouse(string Id)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetAllProductsByWareHouse(Id, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetActiveProductsByWareHouseorSalesCenter(string id)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetActiveProductsByWareHouseorSalesCenter(id, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetMainProductList()
        {
            ProductDAL productDal=new ProductDAL();
            DataTable dt=new DataTable();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                dt = productDal.GetMainProductList(this,db);
                db.Stop();

            }
            catch (Exception)
            {
                
                throw;
            }
            return dt;
        }

        public string SecondaryUnit { get; set; }

        public string ProductType { get; set; }

        public string SubProduct { get; set; }

        public string WareHouseId { get; set; }

        public DataTable GetProductListByWareHouseId()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetProductListByWareHouseId(this,db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetMainProductListBySubProduct(string productId)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetMainProductListBySubProduct(productId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetMainProductsByWareHouseForSales()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetMainProductsByWareHouseforSales(this, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public DataTable GetMainProductListWHID(string wareHouseId)
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetMainProductListWHID(wareHouseId, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }

        public string SubProductId { get; set; }

        public DataTable GetMainProductListBySubProductId()
        {
            ProductDAL product = new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start();
                DataTable dt = product.GetMainProductListBySubProductId(this, db);
                db.Stop();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                product = null;
            }
        }
        public void DeleteProductById(string productId)
        {
            ProductDAL productDal=new ProductDAL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                productDal.DeleteProductById(productId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                productDal = null;
            }
        }
    }
}
