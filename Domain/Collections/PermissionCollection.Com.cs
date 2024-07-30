using System.ComponentModel;

namespace Domain.Collections
{
    public partial class PermissionCollection
    {
        [Description("1")]
        public sealed class Com
        {
            [Description("101")]
            public sealed class Tenant
            {
                public const int View = 10101;
                public const int Create = 10102;
                public const int Edit = 10103;
                public const int Delete = 10199;
            }

            [Description("102")]
            public sealed class Product
            {
                public const int View = 10201;
                public const int Create = 10202;
                public const int Edit = 10203;
                public const int Delete = 10299;
            }
        }
    }
}
