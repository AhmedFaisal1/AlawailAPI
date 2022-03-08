namespace AlawailApi.Domain.Helpers
{
    public enum ShippingType
    {
        Own,
        Ours,
        Both
    }

    public enum ShippingStatus
    {
        Waiting,
        Processed,
        Shipped,
        Delivered
    }

    public enum UserType
    {
        Admin,
        Supplier,
        User,
        Shipper
    }
    public enum AdvertisementType
    {
        Single,Multiple
    }
    public enum FilterType{
        Range,Tag
    }
}