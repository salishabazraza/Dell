namespace DocumentRepository.Shared.DataServices
{
    public static class  DataContextHelper
    {
        
        public static DocumentDataRepository GetPOSPortalContext(bool enableAutoSelect = false)
        {
            return (GetNewDataContext("Document-DEV", enableAutoSelect));
        }
        private static DocumentDataRepository GetNewDataContext(string connectionStringName, bool enableAutoSelect)
        {
            DocumentDataRepository repository = new DocumentDataRepository(connectionStringName);
            repository.EnableAutoSelect = enableAutoSelect;
            return (repository);
        }
    }
}
