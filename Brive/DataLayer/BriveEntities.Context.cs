﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class briveEntities : DbContext
    {
        public briveEntities()
            : base("name=briveEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<inventory> inventory { get; set; }
        public virtual DbSet<log> log { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<sucursal> sucursal { get; set; }
        public virtual DbSet<users> users { get; set; }
    
        public virtual ObjectResult<getLogs_Result> getLogs()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getLogs_Result>("getLogs");
        }
    
        public virtual ObjectResult<getProduct_Result> getProduct()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProduct_Result>("getProduct");
        }
    
        public virtual ObjectResult<getProductId_Result> getProductId(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProductId_Result>("getProductId", idParameter);
        }
    
        public virtual ObjectResult<getSucursales_Result> getSucursales()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSucursales_Result>("getSucursales");
        }
    
        public virtual ObjectResult<getSucursalId_Result> getSucursalId(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSucursalId_Result>("getSucursalId", idParameter);
        }
    
        public virtual ObjectResult<GetUsuarioId_Result> GetUsuarioId(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUsuarioId_Result>("GetUsuarioId", idParameter);
        }
    
        public virtual ObjectResult<getUsuarios_Result> getUsuarios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getUsuarios_Result>("getUsuarios");
        }
    
        public virtual ObjectResult<LoginUsuario_Result> LoginUsuario(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LoginUsuario_Result>("LoginUsuario", emailParameter);
        }
    
        public virtual int logsAdd(Nullable<int> iduser, string action, string module)
        {
            var iduserParameter = iduser.HasValue ?
                new ObjectParameter("iduser", iduser) :
                new ObjectParameter("iduser", typeof(int));
    
            var actionParameter = action != null ?
                new ObjectParameter("action", action) :
                new ObjectParameter("action", typeof(string));
    
            var moduleParameter = module != null ?
                new ObjectParameter("module", module) :
                new ObjectParameter("module", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("logsAdd", iduserParameter, actionParameter, moduleParameter);
        }
    
        public virtual int productAdd(string name, string sku)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var skuParameter = sku != null ?
                new ObjectParameter("sku", sku) :
                new ObjectParameter("sku", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("productAdd", nameParameter, skuParameter);
        }
    
        public virtual int productDelete(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("productDelete", idParameter);
        }
    
        public virtual int productUpdate(Nullable<int> id, string name, string sku)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var skuParameter = sku != null ?
                new ObjectParameter("sku", sku) :
                new ObjectParameter("sku", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("productUpdate", idParameter, nameParameter, skuParameter);
        }
    
        public virtual int sucursalAdd(string sucursalname, Nullable<int> telefono, string direction)
        {
            var sucursalnameParameter = sucursalname != null ?
                new ObjectParameter("sucursalname", sucursalname) :
                new ObjectParameter("sucursalname", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(int));
    
            var directionParameter = direction != null ?
                new ObjectParameter("direction", direction) :
                new ObjectParameter("direction", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sucursalAdd", sucursalnameParameter, telefonoParameter, directionParameter);
        }
    
        public virtual int sucursalDelete(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sucursalDelete", idParameter);
        }
    
        public virtual int updateSucursal(Nullable<int> id, string sucursalname, Nullable<int> telefono, string direction)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var sucursalnameParameter = sucursalname != null ?
                new ObjectParameter("sucursalname", sucursalname) :
                new ObjectParameter("sucursalname", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(int));
    
            var directionParameter = direction != null ?
                new ObjectParameter("direction", direction) :
                new ObjectParameter("direction", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateSucursal", idParameter, sucursalnameParameter, telefonoParameter, directionParameter);
        }
    
        public virtual int UpdateUsuario(Nullable<int> id, string name, string lastname, string username, string email)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var lastnameParameter = lastname != null ?
                new ObjectParameter("lastname", lastname) :
                new ObjectParameter("lastname", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateUsuario", idParameter, nameParameter, lastnameParameter, usernameParameter, emailParameter);
        }
    
        public virtual int userDelete(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("userDelete", idParameter);
        }
    
        public virtual int UsuarioAdd(string name, string lastname, string username, string email, Nullable<System.DateTime> created, Nullable<System.DateTime> edited)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var lastnameParameter = lastname != null ?
                new ObjectParameter("lastname", lastname) :
                new ObjectParameter("lastname", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var createdParameter = created.HasValue ?
                new ObjectParameter("created", created) :
                new ObjectParameter("created", typeof(System.DateTime));
    
            var editedParameter = edited.HasValue ?
                new ObjectParameter("edited", edited) :
                new ObjectParameter("edited", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioAdd", nameParameter, lastnameParameter, usernameParameter, emailParameter, createdParameter, editedParameter);
        }
    
        public virtual ObjectResult<getInventory_Result> getInventory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getInventory_Result>("getInventory");
        }
    
        public virtual ObjectResult<getInventoryId_Result> getInventoryId(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getInventoryId_Result>("getInventoryId", idParameter);
        }
    
        public virtual int inventoryAdd(Nullable<int> amount, Nullable<int> idProduct, Nullable<int> idSucursal)
        {
            var amountParameter = amount.HasValue ?
                new ObjectParameter("amount", amount) :
                new ObjectParameter("amount", typeof(int));
    
            var idProductParameter = idProduct.HasValue ?
                new ObjectParameter("idProduct", idProduct) :
                new ObjectParameter("idProduct", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("idSucursal", idSucursal) :
                new ObjectParameter("idSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("inventoryAdd", amountParameter, idProductParameter, idSucursalParameter);
        }
    
        public virtual int inventoryDelete(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("inventoryDelete", idParameter);
        }
    
        public virtual int inventoryUpdate(Nullable<int> id, Nullable<int> amount, Nullable<int> idProduct, Nullable<int> idSucursal)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("amount", amount) :
                new ObjectParameter("amount", typeof(int));
    
            var idProductParameter = idProduct.HasValue ?
                new ObjectParameter("idProduct", idProduct) :
                new ObjectParameter("idProduct", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("idSucursal", idSucursal) :
                new ObjectParameter("idSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("inventoryUpdate", idParameter, amountParameter, idProductParameter, idSucursalParameter);
        }
    }
}