using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SportsProDALClassLibrary;

namespace SportsProBLLClassLibrary
{
    public class ProductBLL
    {
        public List<Product> RetrieveProductNameandCode()
        {
            List<Product> lstProdNameandCode = new List<Product>();
            DataTable dtProductDetails = new DataTable();
            ProductDAL prodDal = new ProductDAL();
            dtProductDetails = prodDal.GetProductNameandCode();
            foreach (DataRow dr in dtProductDetails.Rows)
            {
                Product aProduct = new Product();
                aProduct.ProductCode = dr["ProductCode"].ToString();
                aProduct.Name = dr["Name"].ToString();
                lstProdNameandCode.Add(aProduct);
            }
            return lstProdNameandCode;
        }

        public ProductBLL()
        {

        }
    }
}
