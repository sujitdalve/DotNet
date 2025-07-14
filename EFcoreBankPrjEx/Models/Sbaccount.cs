using System;
using System.Collections.Generic;

namespace EFcoreBankPrjEx.Models;

public partial class Sbaccount
{
    public int AccNo { get; set; }

    public string Cname { get; set; } = null!;

    public string Caddress { get; set; } = null!;

    public double CurrentBalance { get; set; }

    public virtual ICollection<Sbtransaction> Sbtransactions { get; set; } = new List<Sbtransaction>();
}
