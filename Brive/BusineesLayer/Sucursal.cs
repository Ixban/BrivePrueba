using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer
{
    public class Sucursal
    {
        public static ModelLayer.Result getSucursal(int id)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var SucursalConsult = context.getSucursalId(id).First();

                    result.Objects = new List<object>();

                    if (SucursalConsult != null)
                    {
                        result.Correct = true;

                        ModelLayer.Sucursal sucursal = new ModelLayer.Sucursal();
                        sucursal.id = Convert.ToInt32(SucursalConsult.id.ToString());
                        sucursal.sucursalName = SucursalConsult.sucursalname.ToString();
                        sucursal.telefono = Convert.ToInt32(SucursalConsult.telefono);
                        sucursal.direction = SucursalConsult.direction.ToString();
                        sucursal.created = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", SucursalConsult.created));
                        sucursal.edited = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", SucursalConsult.edited));
                        result.Object = (sucursal);
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

        public static ModelLayer.Result AddSucursal(ModelLayer.Sucursal sucursal)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var SucursalConsult = context.sucursalAdd(sucursal.sucursalName, sucursal.telefono, sucursal.direction);

                    if (SucursalConsult != null)
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

        public static ModelLayer.Result UpdateSucursal(ModelLayer.Sucursal sucursal)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var SucursalConsult = context.updateSucursal(sucursal.id, sucursal.sucursalName, sucursal.telefono, sucursal.direction);

                    if (SucursalConsult != null)
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

        public static ModelLayer.Result getSucursales()
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    result.Objects = new List<object>();
                    var SucursalConsult = context.getSucursales().ToList();

                    if (SucursalConsult != null)
                    {
                        result.Correct = true;

                        foreach (DataLayer.getSucursales_Result sucursalItem in SucursalConsult)
                        {
                            ModelLayer.Sucursal sucursal = new ModelLayer.Sucursal();
                            sucursal.id = Convert.ToInt32(sucursalItem.id.ToString());
                            sucursal.sucursalName = sucursalItem.sucursalname.ToString();
                            sucursal.telefono = Convert.ToInt32(sucursalItem.telefono);
                            sucursal.direction = sucursalItem.direction.ToString();
                            sucursal.created = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", sucursalItem.created));
                            sucursal.edited = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", sucursalItem.edited));
                            result.Objects.Add(sucursal);
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

        public static ModelLayer.Result deleteSucursal(int id)
        {

            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var SucursalConsult = context.sucursalDelete(id);

                    if (SucursalConsult != null)
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
