namespace Larmo.Domain.Domain;

public enum OperationType
{
    Deposit = 1,
    Withdraw = 2,
    Transfer = 3
}

//public enum CurrencyType
//{
//    USD = 1,
//    LYD = 2
//}

//public class OperationType
//{
//    public OperationType(Guid id, string nameAr, string nameEn)
//    {
//        Id = id;
//        NameAr = nameAr;
//        NameEn = nameEn;
//    }

//    private OperationType()
//    {
//    }

//    public Guid Id { get; set; }
//    public string NameAr { get; set; }
//    public string NameEn { get; set; }

//    public static List<OperationType> Types =>
//    [
//        new OperationType(new Guid("fb8407fe-c312-44f9-b636-3f5879289340"), "ايداع", "Deposit"),
//        new OperationType(new Guid("678764a6-2850-4ab6-ae4f-5dafe8151c9e"),"سحب", "Withdraw"),
//        new OperationType(new Guid("4f723366-ad55-4f91-9c60-0724f35db278"),"تحويل", "Transfer")
//    ];
//}

//public class CurrencyType
//{
//    public CurrencyType(Guid id, string nameAr, string nameEn)
//    {
//        Id = id;
//        NameAr = nameAr;
//        NameEn = nameEn;
//    }


//    private CurrencyType()
//    {
//    }

//    public Guid Id { get; set; }
//    public string NameAr { get; set; }
//    public string NameEn { get; set; }

//    public static List<CurrencyType> Types =>
//    [
//        new CurrencyType(new Guid("490d2fae-4dc4-4e7d-9b6d-b2b822a08cda"), "دولار امريكي", "USD"),
//        new CurrencyType(new Guid("837b7917-0ff8-478b-a859-6e38d2b884f6"), "دينار ليبي", "LYD")
//    ];
//}

//public class Client
//{
//    public Guid Id { get; set; }
//    public string Name { get; set; }
//    public string profession { get; set; }
//    public string IdentityNumber { get; set; }
//    public string Iban { get; set; }
//}

//public class Organization
//{
//    public Guid Id { get; set; }
//    public string Name { get; set; }
//    public string ScopeOfBusiness { get; set; }
//    public string Iban { get; set; }
//}
