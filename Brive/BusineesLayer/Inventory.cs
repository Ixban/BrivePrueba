using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer
{
    public class Inventory
    {
        public static ModelLayer.Result getInventory(int id)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var inventoryConsult = context.getInventoryId(id).First();

                    result.Objects = new List<object>();

                    if (inventoryConsult != null)
                    {
                        result.Correct = true;

                        ModelLayer.Inventory Inventory = new ModelLayer.Inventory();
                        Inventory.id = Convert.ToInt32(inventoryConsult.id.ToString());
                        Inventory.amount = Convert.ToInt32(inventoryConsult.amount);
                        Inventory.product = new ModelLayer.Product();
                        Inventory.product.name = inventoryConsult.productoNombre.ToString();
                        Inventory.product.id = Convert.ToInt32(inventoryConsult.idproduct);
                        Inventory.sucursal = new ModelLayer.Sucursal();
                        Inventory.sucursal.sucursalName = inventoryConsult.sucursalNombre.ToString();
                        Inventory.sucursal.id = Convert.ToInt32(inventoryConsult.idsucursal);
                        result.Object = (Inventory);
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

        public static ModelLayer.Result AddInventory(ModelLayer.Inventory inventory)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var inventoryConsult = context.inventoryAdd(inventory.amount, inventory.sucursal.id, inventory.sucursal.id);

                    if (inventoryConsult != null)
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

        public static ModelLayer.Result updateInventory(ModelLayer.Inventory inventory)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var inventoryConsult = context.inventoryUpdate(inventory.id, inventory.amount, inventory.product.id, inventory.sucursal.id);

                    if (inventoryConsult != null)
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

        public static ModelLayer.Result getInventorys()
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    result.Objects = new List<object>();
                    var inventoryConsult = context.getInventory().ToList();

                    if (inventoryConsult != null)
                    {
                        result.Correct = true;

                        foreach (DataLayer.getInventory_Result inventoryItem in inventoryConsult)
                        {
                            ModelLayer.Inventory Inventory = new ModelLayer.Inventory();
                            Inventory.id = Convert.ToInt32(inventoryItem.id.ToString());
                            Inventory.amount = Convert.ToInt32(inventoryItem.amount);
                            Inventory.product = new ModelLayer.Product();
                            Inventory.product.id = Convert.ToInt32(inventoryItem.idproduct);
                            Inventory.product.name = inventoryItem.productoNombre.ToString();
                            Inventory.sucursal = new ModelLayer.Sucursal();
                            Inventory.sucursal.id = Convert.ToInt32(inventoryItem.idsucursal);
                            Inventory.sucursal.sucursalName = inventoryItem.sucursalNombre.ToString();
                            result.Objects.Add(Inventory);
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

        public static ModelLayer.Result deleteInventory(int id)
        {

            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var inventoryConsult = context.inventoryDelete(id);

                    if (inventoryConsult != null)
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
