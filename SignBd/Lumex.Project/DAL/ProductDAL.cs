﻿using System;
using System.Collections.Generic;
using System.Data;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace Lumex.Project.DAL
{
    public class ProductDAL
    {
        public DataTable SaveProduct(ProductBLL product, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductName", product.ProductName.Trim());
                db.AddParameters("@ProductNameOnly", product.ProductNameOnly.Trim());
                db.AddParameters("@Barcode", product.Barcode.Trim());
                db.AddParameters("@ProductGroupId", product.ProductGroupId.Trim());
                db.AddParameters("@ProductVolume", product.ProductVolume.Trim());
                db.AddParameters("@VolumeQuantity", product.VolumeQuantity);
                db.AddParameters("@Unit", product.Unit.Trim());
                db.AddParameters("@SubUnit", product.SecondaryUnit);
                db.AddParameters("@IsMain", product.ProductType);
                db.AddParameters("@ParentProducts", product.SubProduct);
                db.AddParameters("@ProductRate", product.ProductRate);
                db.AddParameters("@VATPercentage", product.VATPercentage);
                db.AddParameters("@VendorId", product.VendorId);
                db.AddParameters("@WareHouse", product.WareHouseId);
                db.AddParameters("@SalesCenter", product.salescenter);
                db.AddParameters("@CreatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@CreatedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@AdditionalInfo", product.additinalInfo.Trim());
                db.AddParameters("@ProduceDes", product.productDesc.Trim());
                db.AddParameters("@ProductImg", product.productImageName.Trim());

                DataTable dt = db.ExecuteDataTable("INSERT_PRODUCT", true);
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

        public DataTable GetProductList(LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UserId", LumexSessionManager.Get("ActiveUserId").ToString());
                DataTable dt = db.ExecuteDataTable("GET_PRODUCTS", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDeletedProductListByDateRangeAll(string fromDate, string toDate, string search, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@FromDate", fromDate.Trim());
                db.AddParameters("@ToDate", toDate.Trim());
                db.AddParameters("@Search", search.Trim());

                DataTable dt = db.ExecuteDataTable("GET_DELETED_PRODUCTS_BY_DATE_RANGE_ALL", true);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveProducts(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_PRODUCTS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetAvailableProductListBySalesCenter(string salesCenterId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SalesCenterId", salesCenterId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_AVAILABLE_PRODUCT_LIST_BY_SALES_CENTER", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetAvailableProductListByWarehouse(string warehouseId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WarehouseId", warehouseId.Trim());
                DataTable dt = db.ExecuteDataTable("GET_AVAILABLE_PRODUCT_LIST_BY_WAREHOUSE", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetActiveProductList(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_ACTIVE_PRODUCT_LIST", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductById(string productId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductId", productId);
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_BY_ID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductByBarcodeIdName(string productBarcodeIdName, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductBarcodeIdName", productBarcodeIdName);
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_BY_BARCODE_ID_NAME", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckDuplicateProductByName(string productName, string warehouse, string salescenter, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@ProductName", productName);
                db.AddParameters("@WareHouse", warehouse);
              //  db.AddParameters("@SalesCenter", salescenter);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_PRODUCT_BY_NAME", true);

                if (dt.Rows.Count > 0)
                {
                    status = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        public bool CheckDuplicateProductByBarcode(string barcode, LumexDBPlayer db)
        {
            bool status = false;

            try
            {
                db.AddParameters("@Barcode", barcode);
                DataTable dt = db.ExecuteDataTable("CHECK_DUPLICATE_PRODUCT_BY_BARCODE", true);

                if (dt.Rows.Count > 0)
                {
                    status = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return status;
        }

        public void UpdateProductActivation(string productId, string activationStatus, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductId", productId);
                db.AddParameters("@IsActive", activationStatus);
                db.AddParameters("@ActivatedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ActivatedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("UPDATE_PRODUCT_ACTIVATION", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteProduct(string productId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductId", productId);
                db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("DELETE_PRODUCT_BY_ID", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable UpdateProduct(ProductBLL product, string updateCondition, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@UpdateCondition", updateCondition.Trim());
                db.AddParameters("@ProductId", product.ProductId.Trim());
                db.AddParameters("@ProductName", product.ProductName.Trim());
                db.AddParameters("@ProductNameOnly", product.ProductNameOnly.Trim());
                db.AddParameters("@Barcode", product.Barcode.Trim());
                db.AddParameters("@ProductGroupId", product.ProductGroupId.Trim());
                db.AddParameters("@ProductVolume", product.ProductVolume.Trim());
                db.AddParameters("@VolumeQuantity", product.VolumeQuantity);
                db.AddParameters("@Unit", product.Unit.Trim());
                db.AddParameters("@VendorId", product.VendorId.Trim());
                db.AddParameters("@ModifiedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                db.AddParameters("@ModifiedFrom", LumexLibraryManager.GetTerminal());
                db.AddParameters("@WareHouse", product.WareHouseId);
                db.AddParameters("@SalesCenter", product.salescenter);
                db.AddParameters("@AdditionalInfo", product.additinalInfo.Trim());
                db.AddParameters("@ProduceDes", product.productDesc.Trim());
                db.AddParameters("@ProductImg", product.productImageName.Trim());
                db.AddParameters("@SubUnit", product.SecondaryUnit.Trim());
                db.AddParameters("@IsMain", product.ProductType.Trim());
                db.AddParameters("@ParentProducts",product.SubProduct);
                DataTable dt=db.ExecuteDataTable("UPDATE_PRODUCT_BY_ID", true);
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

        public DataTable GetProductVolumes(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_VOLUMES", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductNames(LumexDBPlayer db)
        {
            try
            {

                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_NAMES", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductNamesBySalesCenter(string id, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@Id", id);
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_NAMES_BY_SalesCenter", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetProductNamesByWareHouse(string id, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@Id", id);
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_NAMES_BY_WareHouse", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductNamesOnly(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_NAMES_ONLY", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductUnits(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_UNITS", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetProductBarcodes(LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("GET_PRODUCT_BARCODES", false);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable GetProductNamesForSales(LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SCId", LumexSessionManager.Get("UserSalesCenterId").ToString());
                DataTable dt = db.ExecuteDataTable("[GET_PRODUCT_NAMES_AND_ID_BY_SC]", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable GetActiveProductsByWareHouseorSalesCenterForSales(string Id, LumexDBPlayer db)
        {

            db.AddParameters("@ID", Id);
            DataTable dt = db.ExecuteDataTable("[GET_ACTIVE_PRODUCTS_BY_WAREHOUSE_OR_SALES_CENTER_FOR_SALES]", true);
            return dt;

        }

        internal DataTable GetAllProductsBySalesCenter(string Id, LumexDBPlayer db)
        {
            db.AddParameters("@ID", Id);
            DataTable dt = db.ExecuteDataTable("[GET_ALL_PRODUCTS_BY_WH_or_SC_ID_FOR_SALES]", true);
            return dt;
        }

        internal DataTable GetAllProductsByWareHouse(string Id, LumexDBPlayer db)
        {
            db.AddParameters("@ID", Id);
            DataTable dt = db.ExecuteDataTable("[GET_ALL_PRODUCTS_BY_WAREHOUSE_FOR_SALES]", true);
            return dt;
        }

        internal DataTable GetActiveProductsByWareHouseorSalesCenter(string id, LumexDBPlayer db)
        {
            db.AddParameters("@ID", id);
            DataTable dt = db.ExecuteDataTable("[GET_ACTIVE_PRODUCTS_BY_WAREHOUSE_OR_SALES_CENTER]", true);
            return dt;
        }

        internal DataTable GetMainProductList(ProductBLL product ,LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WHId", product.WareHouseId);
                DataTable dt = db.ExecuteDataTable("[GET_PRODUCTS_WH_ID]", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable GetProductListByWareHouseId(ProductBLL productBLL, LumexDBPlayer db)
        {
            try
            {
              
                db.AddParameters("@WHID", productBLL.WareHouseId);
                DataTable dt = db.ExecuteDataTable("GET_PRODUCTS_BY_WHID", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void SaveMainProductOfSubProduct(string ProductId, System.Collections.Generic.List<string> mainProductList, LumexDBPlayer db)
        {
            try
            {
                db.ClearParameters();
                db.AddParameters("@ProductId ", ProductId);

                db.ExecuteNonQuery("DELETE_MAIN_PRODUCT_OF_SUB_PRODUCT", true);

                for (int i = 0; i < mainProductList.Count; i++)
                {
                    db.ClearParameters();
                    db.AddParameters("@ProductId ", ProductId);
                    db.AddParameters("@MainProduct ", mainProductList[i].ToString());

                    db.ExecuteNonQuery("INSERT_MAIN_PRODUCT_OF_SUB_PRODUCT", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        internal DataTable GetMainProductListBySubProduct(string productId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ProductId", productId);
                DataTable dt = db.ExecuteDataTable("GET_MAIN_PRODUCT_LIST_BY_SUB_PRODUCT", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable GetMainProductsByWareHouseforSales(ProductBLL productBLL, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@ID", productBLL.WareHouseId);
                DataTable dt = db.ExecuteDataTable("[GET_MAIN_PRODUCTS_BY_WAREHOUSE_FOR_SALES]", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable GetMainProductListWHID(string wareHouseId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@WHId ", wareHouseId);
                DataTable dt = db.ExecuteDataTable("[GET_PRODUCTS_SUB_BY_WH_ID]", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DataTable GetMainProductListBySubProductId(ProductBLL productBLL, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@SubProductId ", productBLL.SubProductId);
                DataTable dt = db.ExecuteDataTable("[GET_PRODUCTS_MAIN_BY_SUBPRoductID]", true);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void DeleteProductById(string productId, LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@Serial", productId);
               // db.AddParameters("@DeletedBy", LumexSessionManager.Get("ActiveUserId").ToString());
                //db.AddParameters("@DeletedFrom", LumexLibraryManager.GetTerminal());

                db.ExecuteNonQuery("DELETE_PRODUCTS_MAIN_BY_SERIAL", true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
