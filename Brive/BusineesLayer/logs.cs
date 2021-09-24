using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLayer
{
    public class logs
    {
        public static ModelLayer.Result getLogs()
        {
            ModelLayer.Result result = new ModelLayer.Result();

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    result.Objects = new List<object>();
                    var logsConsult = context.getLogs().ToList();

                    if (logsConsult != null)
                    {
                        result.Correct = true;

                        foreach (DataLayer.getLogs_Result logsItem in logsConsult)
                        {
                            ModelLayer.Log log = new ModelLayer.Log();
                            log.id = Convert.ToInt32(logsItem.id.ToString());
                            log.users = new ModelLayer.Users();
                            log.users.id = Convert.ToInt32(logsItem.iduser);
                            log.module = logsItem.module.ToString();
                            log.action = logsItem.action.ToString();
                            log.created = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", logsItem.created));
                            log.edited = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", logsItem.edited));
                            result.Objects.Add(log);
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

        public static ModelLayer.Result AddLogs(ModelLayer.Users user, string action, string module)
        {
            ModelLayer.Result result = new ModelLayer.Result();

            ModelLayer.Users users = user;

            try
            {

                using (DataLayer.briveEntities context = new DataLayer.briveEntities())
                {

                    var logConsult = context.logsAdd(users.id, action, module);

                    if (logConsult != null)
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

    }
}
