using System.Runtime.Serialization;

namespace Almaz.AssetManagement.Web.Endpoints.CategoriesEndpoints.Queries
{
    [Serializable]
    internal class CatalogDatabaseSaveException : Exception
    {
        public CatalogDatabaseSaveException()
        {
        }

        public CatalogDatabaseSaveException(string? message) : base(message)
        {
        }

        public CatalogDatabaseSaveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CatalogDatabaseSaveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}