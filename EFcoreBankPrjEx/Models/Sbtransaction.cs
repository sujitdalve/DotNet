using System;
using System.Collections.Generic;

namespace EFcoreBankPrjEx.Models;

public partial class Sbtransaction
{
    public int Tid { get; set; }

    public DateTime Tdate { get; set; }

    public int AccNo { get; set; }

    public double Amount { get; set; }

    public string TransactionType { get; set; } = null!;

    public virtual Sbaccount AccNoNavigation { get; set; } = null!;
}
