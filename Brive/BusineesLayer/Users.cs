using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer
{
    public class Users
    {
        public static ModelLayer.Result LogIn(string username)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var UsuarioConsult = context.LoginUsuario(username);

                    if (UsuarioConsult != null)
                    {
                        result.Correct = true;

                        foreach (DataLayer.LoginUsuario_Result usuarioItem in UsuarioConsult)
                        {
                            ModelLayer.Users usuario = new ModelLayer.Users();
                            usuario.id = Convert.ToInt32(usuarioItem.id.ToString());
                            usuario.name = usuarioItem.name.ToString();
                            usuario.lastName = usuarioItem.lastname.ToString();
                            usuario.userName = usuarioItem.username.ToString();
                            usuario.email = usuarioItem.email.ToString();
                            usuario.password = usuarioItem.password.ToString();
                            //usuario.created = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", usuarioItem.created));
                            //usuario.edited = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", usuarioItem.edited));
                            result.Object = usuario;
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

        public static ModelLayer.Result GetUsuario(int id)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var UsuarioConsult = context.GetUsuarioId(id).First();

                    result.Objects = new List<object>();

                    if (UsuarioConsult != null)
                    {
                        result.Correct = true;

                        ModelLayer.Users usuario = new ModelLayer.Users();
                        usuario.id = Convert.ToInt32(UsuarioConsult.id.ToString());
                        usuario.name = UsuarioConsult.name.ToString();
                        usuario.lastName = UsuarioConsult.lastname.ToString();
                        usuario.userName = UsuarioConsult.username.ToString();
                        usuario.email = UsuarioConsult.email.ToString();
                        usuario.created = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", UsuarioConsult.created));
                        usuario.edited = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", UsuarioConsult.edited));
                        result.Object = (usuario);
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

        public static ModelLayer.Result AddUser(ModelLayer.Users usuario)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var usuarioConsult = context.UsuarioAdd(usuario.name, usuario.lastName, usuario.userName, usuario.email, DateTime.Now, DateTime.Now);

                    if (usuarioConsult != null)
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

        public static ModelLayer.Result UpdateUser(ModelLayer.Users usuario)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var usuarioConsult = context.UpdateUsuario(usuario.id, usuario.name, usuario.lastName, usuario.userName, usuario.email);

                    if (usuarioConsult != null)
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

        public static ModelLayer.Result getUsers()
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    result.Objects = new List<object>();
                    var UsuarioConsult = context.getUsuarios().ToList();

                    if (UsuarioConsult != null)
                    {
                        result.Correct = true;

                        foreach (DataLayer.getUsuarios_Result usuarioItem in UsuarioConsult)
                        {
                            ModelLayer.Users usuario = new ModelLayer.Users();
                            usuario.id = Convert.ToInt32(usuarioItem.id.ToString());
                            usuario.name = usuarioItem.name.ToString();
                            usuario.lastName = usuarioItem.lastname.ToString();
                            usuario.userName = usuarioItem.username.ToString();
                            usuario.email = usuarioItem.email.ToString();
                            usuario.created = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", usuarioItem.created));
                            usuario.edited = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", usuarioItem.edited));
                            result.Objects.Add(usuario);
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

        public static ModelLayer.Result UserDelete(int id)
        {

            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var usuarioConsult = context.userDelete(id);

                    if (usuarioConsult != null)
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
