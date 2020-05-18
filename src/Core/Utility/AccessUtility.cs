using System.Security.AccessControl;

namespace Discovery
{

    public static class AccessUtility
    {
        public static bool HasAccess(string filePath)
        {
            try
            {
                FileSystemSecurity fileSystemSecurity = new FileSecurity(filePath, AccessControlSections.Access);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}