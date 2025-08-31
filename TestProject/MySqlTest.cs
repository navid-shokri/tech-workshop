using System.Text.RegularExpressions;
using Dapper;
using MapsterIntro;
using MySqlConnector;

namespace TestProject;

public class MySqlTest
{
    [Fact]
    public void MYSql()
    {
        var connection =
            new MySqlConnection(
                "server=localhost; port=3006; database=bordar_db; user=bordar_user; password=bordar_pass; Persist Security Info=False; Connect Timeout=300;Allow User Variables=true;");
        connection.Open();

        var str =
            "   SELECT o.Id ,o.TripId ,o.BillingCost,o.LatestStatus ,o.IsRoundTrip ,o.IsQuickTrip ,o.CreatedAt as CreatedAt,o.ETA ,o.OrderBatchId ,o.InvoiceNumber,o.vendorId,o.PaymentType ,o.OriginalDeliveryFee ,o.BikerId,o.BikerPhone,o.BikerName,c.Id as CustomerId,c.Name as CustomerName,c.CustomerPhone,c.latitude,c.longitude,c.Address,p.Amount as DiscountAmount,p.Percentage as DiscountPercentage,p.Type,p.PercentageApplied , j.* from   bordar_db.Orders o left join  bordar_db.Contacts as c on o.ContactId  = c.Id  LEFT JOIN  bordar_db.Pricings as p on p.OrderId = o.Id and p.Type = 0  Join (SELECT ob.OrderBatchId,(@row_number:=@row_number + 1) AS rnk   from ( SELECT  yz.Id orderBatchId from  bordar_db.OrderBatches  yz  JOIN ((SELECT DISTINCT w.OrderBatchId FROM   bordar_db.Orders  w JOIN  bordar_db.OrderBatches   x  On w.OrderBatchId = x.Id Where  w.OrderBatchId <> ''  AND w.VendorId = '100977' ) g) on yz.Id = OrderBatchId  Order By yz.CreatedAt) as ob ) as j  on o.OrderBatchId = j.OrderBatchId,  (SELECT @row_number:=0) as x                  Where rnk between 5 and 6   ";
        /*var d = connection.Query("SELECT o.Id ,o.TripId ,o.BillingCost,o.LatestStatus ,o.IsRoundTrip ,o.IsQuickTrip ,o.CreatedAt " +
                                 "as CreatedAt,o.ETA ,o.OrderBatchId ,o.InvoiceNumber,o.vendorId,o.PaymentType ,o.OriginalDeliveryFee " +
                                 ",o.BikerId,o.BikerPhone,o.BikerName,c.Id as CustomerId,c.Name as CustomerName,c.CustomerPhone,c.latitude," +
                                 "c.longitude,c.Address,p.Amount as DiscountAmount,p.Percentage as DiscountPercentage,p.Type,p.PercentageApplied ," +
                                 " j.* from   bordar_db.Orders o left join  bordar_db.Contacts as c on o.ContactId  = c.Id " +
                                 " LEFT JOIN  bordar_db.Pricings as p on p.OrderId = o.Id" +
                                 " and p.Type = 0 " +
                                 " Join (SELECT ob.OrderBatchId,(@row_number:=@row_number + 1) AS rnk  " +
                                 " from ( SELECT  yz.Id orderBatchId from  bordar_db.OrderBatches  yz " +
                                 "JOIN ((SELECT DISTINCT w.OrderBatchId FROM   bordar_db.Orders  w JOIN  bordar_db.OrderBatches   x " +
                                 " On w.OrderBatchId = x.Id  Where  w.OrderBatchId <> ''  AND w.VendorId = '100977' ) g) on yz.Id = OrderBatchId " +
                                 " Order By yz.CreatedAt) as ob ) " +
                                 "as j  on o.OrderBatchId = j.OrderBatchId, " +
                                 "(SELECT @row_number:=0) as x " +
                                 "  Where rnk  between 4 and 8");*/

        MySqlCommand comm = new MySqlCommand(str, connection);
        var data = comm.ExecuteReader();
        var i = 0;
        while (data.Read())
        {
            i++;
        }

        Assert.Equal(i, 5);
        /*var d = connection.Query<test>(
            "select t.* from (SELECT ob.Id,(@row_number:=@row_number + 1) AS rnk  from OrderBatches as ob,(select @row_number := 0) as x)as t where rnk between 4 and 8");*/
        Console.WriteLine("salam");

    }

    [Fact]
    public void test5()
    {
        var text_to_replace = "lazy_fox has green tail";
        var str = "name.Contains(@1) && family == @2";
        var key = "name";
        var o = Regex.Matches(str.Substring(str.IndexOf(key)), $"\\(*{key}(.*?)\\@\\d\\)*");
        var ot = Regex.Replace(str, $"\\(*{key}(.*?)\\@\\d\\)*", text_to_replace);
        Assert.Contains(ot, text_to_replace);
        Assert.Equal(o.First().Value, "@2");

    }

    [Fact]
    public void riom_be_ei_zendegi()
    {
        var list = new List<string> { "ali", "bita" };
        list.Append("navid");

        Assert.Equal(list.Count, 3);
    }

    [Fact]
    public void salam()
    {
        var currentTenant = Tenant.SnappFood;

        Assert.True(TenantTest.SnappFoodAndBordar.HasFlag(currentTenant));
    }

    [Theory]
    [InlineData("17:45:00", 1065)]
    public void TimeSpanParseTest(string value, double data)
    {
        var t = TimeSpan.Parse(value).TotalMinutes;
        Assert.Equal(t, data);
    }
    
    
    [Fact]
    public void test()
    {
       
            var arr = new int []{0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var o = arr[6..];
           var t = string.Join("," ,o.Select(x=> $"{x}"));
           Assert.StartsWith("5", t);
    }

    [Fact]
    public void Test1()
    {
        List<Relation> relations = new List<Relation> { Relation.Father , Relation.Mother};

        var r = relations.Aggregate((c, i) => c | i);
        Assert.True(r.HasFlag(Relation.Father));
        Assert.False(r.HasFlag(Relation.Dougther));
    }

    [Fact]
    public void testqqq()
    {
        var arr = new int[]
        { 5,3,9,1,7,2,8 };
        var t = arr.Order().ToArray()[..3];

        var tf= t.Sum();
    }
    

    [Fact]
    public void Test2()
    {
        var all = Enum.GetValues<Relation>();
        var flags = Relation.Dougther | Relation.Mother;

        var o = all.Select(f => flags & f)
            .Where(x=>x != Relation.None).ToList();
        Assert.Equal(o.Count, 2);
    }
}




static class  TenantTest
{
    public static Tenant SnappFoodAndBordar = Tenant.SnappFood | Tenant.Bordar;

    public static bool HasBordarAccess(this Tenant currentTenant)
    {
        return SnappFoodAndBordar.HasFlag(currentTenant);
    }
    public static Tenant GetSuperTenant(this Tenant currentTenant) 
    {
        return SnappFoodAndBordar.HasFlag(currentTenant) ? Tenant.Bordar : currentTenant;
    }
}

[Flags]
public enum Tenant
{
    Bordar = 0,
    SnappFood = 1,
    ExpressPlus = 2
}

public class ClassRoom{
    public string TeacherName{ get; set;}
    public DateTime StartDate{get; set;}
    public List<Student> Students {get; set;}
}

public class Student{
    public String Name{get; set;}
    public String Family {get; set;}
    public Address Address{get; set;}
}

public class Address{
    public string City {get; set;}
}



/*  */