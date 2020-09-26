
namespace CleanCode.MagicNumbers
{
    public enum DocumentStatus
    {
        Draft = 1,
        Logged = 2
    }

    public class MagicNumbers
    {
        public void ApproveDocument(DocumentStatus status)
        {
            if (status == DocumentStatus.Draft)
            {
                // ...
            }
            else if (status == DocumentStatus.Logged)
            {
                // ...
            }
        }

        public void RejectDoument(DocumentStatus status)
        {
            switch (status)
            {
                case DocumentStatus.Draft:
                    // ...
                    break;
                case DocumentStatus.Logged:
                    // ...
                    break;
            }
        }
    }
}
