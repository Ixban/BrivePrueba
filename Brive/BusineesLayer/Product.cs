using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer
{
    public class Product
    {
        public static ModelLayer.Result getProduct(int id)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var productConsult = context.getProductId(id).First();

                    result.Objects = new List<object>();

                    if (productConsult != null)
                    {
                        result.Correct = true;

                        ModelLayer.Product product = new ModelLayer.Product();
                        product.id = Convert.ToInt32(productConsult.id.ToString());
                        product.name = productConsult.name.ToString();
                        product.sku = productConsult.sku.ToString();
                        product.created = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", productConsult.created));
                        product.edited = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", productConsult.edited));
                        result.Object = (product);
                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No existen registros";
                        //No existen registros
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }

            return result;
        }

        public static ModelLayer.Result AddProduct(ModelLayer.Product product)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var productConsult = context.productAdd(product.name, product.sku);

                    if (productConsult != null)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No existen registros";
                        //No existen registros
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }

            return result;
        }

        public static ModelLayer.Result updateProduct(ModelLayer.Product product)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var productConsult = context.productUpdate(product.id, product.name, product.sku);

                    if (productConsult != null)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No existen registros";
                        //No existen registros
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }

            return result;
        }

        public static ModelLayer.Result getProducts()
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    result.Objects = new List<object>();
                    var productConsult = context.getProduct().ToList();

                    if (productConsult != null)
                    {
                        result.Correct = true;

                        foreach (DataLayer.getProduct_Result ProductItem in productConsult)
                        {
                            ModelLayer.Product product = new ModelLayer.Product();
                            product.id = Convert.ToInt32(ProductItem.id.ToString());
                            product.name = ProductItem.name.ToString();
                            product.sku = ProductItem.sku.ToString();
                            product.created = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", ProductItem.created));
                            product.edited = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", ProductItem.edited));
                            result.Objects.Add(product);
                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No existen registros";
                        //No existen registros
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }

            return result;
        }

        public static ModelLayer.Result deleteProduct(int id)
        {

            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var productConsult = context.productDelete(id);

                    if (productConsult != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.MessageError = "No se pudo realizar la operacion";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.MessageError = ex.Message;
            }

            return result;
        }
    }
}
